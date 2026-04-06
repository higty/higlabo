using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HigLabo.Service;

public enum BackgroundCommandServiceState
{
    Ready,
    Executing,
    Suspend,
}
public class BackgroundService : IDisposable, IAsyncDisposable
{
    private sealed class QueuedCommand
    {
        public required Int64 Id { get; init; }
        public required ServiceCommand Command { get; init; }
    }

    public class BackgroundServiceLog
    {
        private Object _LockObject = new Object();
        private List<ServiceCommand> _CommandList = new List<ServiceCommand>();
        internal Int64 _CommandCount = 0;
        internal Int64 _TotalExecutedTicks = 0;

        public Int64 CommandCount
        {
            get { return Interlocked.Read(ref _CommandCount); }
        }
        public Int64 ExecutedTicks
        {
            get { return Interlocked.Read(ref _TotalExecutedTicks); }
        }
        public Int64 MaxCommandCount { get; set; } = 1000;

        internal void AddCommand(ServiceCommand command)
        {
            Interlocked.Increment(ref _CommandCount);
            lock (_LockObject)
            {
                if (_CommandList.Contains(command)) { return; }
                _CommandList.Add(command);
                if (_CommandList.Count > this.MaxCommandCount)
                {
                    var length = _CommandList.Count - this.MaxCommandCount;
                    for (int i = 0; i < length; i++)
                    {
                        _CommandList.RemoveAt(0);
                    }
                }
            }
        }
        public List<ServiceCommand> GetCommandList()
        {
            var l = new List<ServiceCommand>();
            lock (_LockObject)
            {
                foreach (var cm in _CommandList)
                {
                    l.Add(cm);
                }
            }
            return l;
        }
    }
    public event EventHandler<ServiceCommandEventArgs>? Executed;
    public event EventHandler<ServiceCommandEventArgs>? Error;

    private readonly Channel<QueuedCommand> _Channel = Channel.CreateUnbounded<QueuedCommand>(new UnboundedChannelOptions()
    {
        SingleReader = true,
        AllowSynchronousContinuations = false,
    });
    private readonly ConcurrentDictionary<Int64, ServiceCommand> _PendingCommandMap = new();
    private readonly SemaphoreSlim _ResumeSignal = new SemaphoreSlim(0, 1);
    private readonly CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

    private readonly Task _ProcessingTask;
    private ServiceCommand? _CurrentCommand = null;
    private Int64 _ExecutingCommandCount = 0;
    private Int64 _NextCommandId = 0;
    private Int64 _IsSuspend = 0;
    private Int64 _IsDisposed = 0;

    public String Name { get; private set; }
    public BackgroundCommandServiceState State
    {
        get
        {
            if (Volatile.Read(ref _IsDisposed) == 1) { return BackgroundCommandServiceState.Ready; }
            if (_CurrentCommand != null) { return BackgroundCommandServiceState.Executing; }
            if (_PendingCommandMap.IsEmpty == false) { return BackgroundCommandServiceState.Executing; }
            if (_IsSuspend == 1) { return BackgroundCommandServiceState.Suspend; }
            return BackgroundCommandServiceState.Ready;
        }
    }
    public Int32 DelaySecondsPerCommand { get; set; }
    public Int32 CommandCount
    {
        get
        {
            return _PendingCommandMap.Count + (Int32)Interlocked.Read(ref _ExecutingCommandCount);
        }
    }
    public BackgroundServiceLog Log { get; set; } = new BackgroundServiceLog();

    public BackgroundService(String name, Int32 threadSleepSecondsPerCommand)
    {
        this.Name = name;
        this.DelaySecondsPerCommand = threadSleepSecondsPerCommand;
        _ProcessingTask = Task.Run(this.ProcessLoopAsync);
    }
    private async Task ProcessLoopAsync()
    {
        var cancellationToken = _CancellationTokenSource.Token;
        var scheduledCommandQueue = new PriorityQueue<QueuedCommand, DateTimeOffset>();

        try
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await this.WaitWhileSuspendedAsync(cancellationToken).ConfigureAwait(false);
                var queuedCommand = await this.DequeueNextCommandAsync(scheduledCommandQueue, cancellationToken).ConfigureAwait(false);
                if (queuedCommand == null) { continue; }

                _PendingCommandMap.TryRemove(queuedCommand.Id, out _);
                var cm = queuedCommand.Command;

                try
                {
                    var sw = Stopwatch.StartNew();
                    cm.StartTime = DateTimeOffset.Now;
                    _CurrentCommand = cm;
                    Interlocked.Exchange(ref _ExecutingCommandCount, 1);
                    await cm.ExecuteAsync().ConfigureAwait(false);
                    cm.EndTime = DateTimeOffset.Now;
                    sw.Stop();

                    this.Log.AddCommand(cm);
                    Interlocked.Add(ref this.Log._TotalExecutedTicks, sw.ElapsedTicks);
                    this.Executed?.Invoke(this, new ServiceCommandEventArgs(cm, null));
                }
                catch (Exception ex)
                {
                    cm.EndTime = DateTimeOffset.Now;
                    try
                    {
                        this.Error?.Invoke(this, new ServiceCommandEventArgs(cm, ex));
                    }
                    catch { }
                }
                finally
                {
                    _CurrentCommand = null;
                    Interlocked.Exchange(ref _ExecutingCommandCount, 0);
                }

                if (this.DelaySecondsPerCommand > 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(this.DelaySecondsPerCommand), cancellationToken).ConfigureAwait(false);
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            _CurrentCommand = null;
            Interlocked.Exchange(ref _ExecutingCommandCount, 0);
        }
    }
    private async ValueTask WaitWhileSuspendedAsync(CancellationToken cancellationToken)
    {
        while (Volatile.Read(ref _IsSuspend) == 1)
        {
            await _ResumeSignal.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
    private async ValueTask<QueuedCommand?> DequeueNextCommandAsync(PriorityQueue<QueuedCommand, DateTimeOffset> scheduledCommandQueue, CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested == false)
        {
            if (scheduledCommandQueue.TryPeek(out _, out var nextScheduleTime))
            {
                var delay = nextScheduleTime - DateTimeOffset.Now;
                if (delay <= TimeSpan.Zero)
                {
                    return scheduledCommandQueue.Dequeue();
                }

                var waitToReadTask = _Channel.Reader.WaitToReadAsync(cancellationToken).AsTask();
                var delayTask = Task.Delay(delay, cancellationToken);
                var completedTask = await Task.WhenAny(waitToReadTask, delayTask).ConfigureAwait(false);
                if (completedTask == delayTask)
                {
                    continue;
                }

                if (await waitToReadTask.ConfigureAwait(false))
                {
                    while (_Channel.Reader.TryRead(out var queuedCommand))
                    {
                        this.BufferCommand(scheduledCommandQueue, queuedCommand);
                    }
                }
                continue;
            }

            var queued = await _Channel.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);
            this.BufferCommand(scheduledCommandQueue, queued);
            if (scheduledCommandQueue.TryPeek(out _, out nextScheduleTime) == false || nextScheduleTime <= DateTimeOffset.Now)
            {
                if (scheduledCommandQueue.Count > 0)
                {
                    return scheduledCommandQueue.Dequeue();
                }
            }
        }
        return null;
    }
    private void BufferCommand(PriorityQueue<QueuedCommand, DateTimeOffset> scheduledCommandQueue, QueuedCommand queuedCommand)
    {
        var scheduleTime = queuedCommand.Command.ScheduleTime ?? DateTimeOffset.MinValue;
        scheduledCommandQueue.Enqueue(queuedCommand, scheduleTime);
    }
    public void Suspend()
    {
        Interlocked.Exchange(ref _IsSuspend, 1);
    }
    public void Resume()
    {
        if (Interlocked.Exchange(ref _IsSuspend, 0) == 1)
        {
            if (_ResumeSignal.CurrentCount == 0)
            {
                _ResumeSignal.Release();
            }
        }
    }
    public void AddCommand(ServiceCommand command)
    {
        ThrowIfDisposed();

        var queuedCommand = new QueuedCommand()
        {
            Id = Interlocked.Increment(ref _NextCommandId),
            Command = command,
        };
        _PendingCommandMap[queuedCommand.Id] = command;
        _Channel.Writer.TryWrite(queuedCommand);
    }
    public void AddCommand(IEnumerable<ServiceCommand> commandList)
    {
        ThrowIfDisposed();

        foreach (var command in commandList)
        {
            if (command == null) { continue; }
            var queuedCommand = new QueuedCommand()
            {
                Id = Interlocked.Increment(ref _NextCommandId),
                Command = command,
            };
            _PendingCommandMap[queuedCommand.Id] = command;
            _Channel.Writer.TryWrite(queuedCommand);
        }
    }

    public ServiceCommand? GetCurrentCommand()
    {
        return _CurrentCommand;
    }
    public List<ServiceCommand> GetCommandList()
    {
        var l = new List<KeyValuePair<Int64, ServiceCommand>>(_PendingCommandMap);
        l.Sort((x, y) => x.Key.CompareTo(y.Key));

        var result = new List<ServiceCommand>(l.Count);
        foreach (var item in l)
        {
            result.Add(item.Value);
        }
        return result;
    }
    public async ValueTask StopAsync()
    {
        if (Interlocked.Exchange(ref _IsDisposed, 1) == 1) { return; }

        _CancellationTokenSource.Cancel();
        _Channel.Writer.TryComplete();
        this.Resume();
        await _ProcessingTask.ConfigureAwait(false);

        _ResumeSignal.Dispose();
        _CancellationTokenSource.Dispose();
        _PendingCommandMap.Clear();
    }
    public void Dispose()
    {
        this.StopAsync().AsTask().GetAwaiter().GetResult();
    }
    public ValueTask DisposeAsync()
    {
        return this.StopAsync();
    }
    private void ThrowIfDisposed()
    {
        if (Volatile.Read(ref _IsDisposed) == 1)
        {
            throw new ObjectDisposedException(nameof(BackgroundService));
        }
    }
}
