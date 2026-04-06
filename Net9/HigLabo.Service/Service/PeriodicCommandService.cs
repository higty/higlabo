using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Service;

public class PeriodicCommandService : IDisposable, IAsyncDisposable
{
    private readonly ConcurrentDictionary<PeriodicCommand, Byte> _CommandMap = new();
    private readonly CancellationTokenSource _CancellationTokenSource = new();
    private Task _ProcessingTask;

    private Int64 _IsDisposed = 0;
    private PeriodicTimer? _Timer = null;

    public event EventHandler<ServiceCommandEventArgs>? Error;
    public String Name { get; set; } = "";
    public Boolean IsStarted { get; private set; } = false;
    public Boolean Available { get; set; } = true;
    public Int32 IntervalSeconds { get; set; } = 60;

    public PeriodicCommandService(String name)
    {
        this.Name = name;
        _ProcessingTask = Task.Run(this.ProcessLoopAsync);
    }
    private async Task ProcessLoopAsync()
    {
        var cancellationToken = _CancellationTokenSource.Token;

        try
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                this.ResetTimer();
                this.IsStarted = true;

                try
                {
                    while (await _Timer!.WaitForNextTickAsync(cancellationToken).ConfigureAwait(false))
                    {
                        if (this.Available == false) { continue; }

                        var utcNow = DateTime.UtcNow;
                        foreach (var item in _CommandMap.Keys)
                        {
                            try
                            {
                                if (item.IsExecute(utcNow))
                                {
                                    item.Service.AddCommand(item);
                                }
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    this.Error?.Invoke(this, new ServiceCommandEventArgs(item, ex));
                                }
                                catch { }
                                this.WriteLog(ex.ToString());
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (ObjectDisposedException) when (cancellationToken.IsCancellationRequested == false)
                {
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            this.IsStarted = false;
            _Timer?.Dispose();
        }
    }
    private void ResetTimer()
    {
        var intervalSeconds = this.IntervalSeconds;
        if (intervalSeconds <= 0)
        {
            intervalSeconds = 1;
        }

        var nextInterval = TimeSpan.FromSeconds(intervalSeconds);
        if (_Timer == null)
        {
            _Timer = new PeriodicTimer(nextInterval);
            return;
        }

        if (_Timer.Period != nextInterval)
        {
            _Timer.Dispose();
            _Timer = new PeriodicTimer(nextInterval);
        }
    }
    private void WriteLog(string text)
    {
        System.Diagnostics.Trace.WriteLine($"{DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss.fff")} {this.Name} {text}");
    }
    public void AddCommand(PeriodicCommand command)
    {
        ThrowIfDisposed();
        _CommandMap.TryAdd(command, 0);
    }
    public void AddCommand(IEnumerable<PeriodicCommand> commandList)
    {
        ThrowIfDisposed();
        foreach (var command in commandList)
        {
            _CommandMap.TryAdd(command, 0);
        }
    }
    public async ValueTask StopAsync()
    {
        if (Interlocked.Exchange(ref _IsDisposed, 1) == 1) { return; }

        _CancellationTokenSource.Cancel();
        _Timer?.Dispose();
        await _ProcessingTask.ConfigureAwait(false);

        _CancellationTokenSource.Dispose();
        _CommandMap.Clear();
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
            throw new ObjectDisposedException(nameof(PeriodicCommandService));
        }
    }
}
