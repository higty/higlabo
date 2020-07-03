using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace HigLabo.Net.Internal
{
    public class PipeStream : Stream
    {
        private Queue<byte> _Buffer = new Queue<byte>();
        private ManualResetEvent _WriteEvent;
        private ManualResetEvent _ReadEvent;
        private bool _Flushed = false;
        private long _MaxBufferLength = 1 * MB;
        private bool _BlockLastRead = false;
        private int _ReadWriteTimeout;
        private long _TotalWrite = 0;
        public const long KB = 1024;
        public const long MB = KB * 1024;
        public long MaxBufferLength
        {
            get { return _MaxBufferLength; }
            set { _MaxBufferLength = value; }
        }
        public bool BlockLastReadBuffer
        {
            get
            {
                return _BlockLastRead;
            }
            set
            {
                _BlockLastRead = value;
                if (!_BlockLastRead)
                    _WriteEvent.Set();
            }
        }
        public PipeStream(int readWriteTimeout)
        {
            this._ReadWriteTimeout = readWriteTimeout;
            _WriteEvent = new ManualResetEvent(false);
            _ReadEvent = new ManualResetEvent(false);
        }
        public override void Flush()
        {
            _Flushed = true;
            _WriteEvent.Set(); // signal any waiting read events.
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset != 0)
                throw new NotImplementedException("Offsets with value of non-zero are not supported");
            if (buffer == null)
                throw new ArgumentException("Buffer is null");
            if (offset + count > buffer.Length)
                throw new ArgumentException("The sum of offset and count is greater than the buffer length. ");
            if (offset < 0 || count < 0)
                throw new ArgumentOutOfRangeException("offset or count is negative.");
            if (BlockLastReadBuffer && count >= _MaxBufferLength)
                throw new ArgumentException("count > _MaxBufferLength");

            if (count == 0)
                return 0;

            int readLength;

            while ((Length < count && !_Flushed) ||
                   (Length < (count + 1) && BlockLastReadBuffer))
            {
                _WriteEvent.Reset(); // turn off an existing write signal
                _ReadEvent.Set(); // signal any waiting reads, preventing deadlock
                _WriteEvent.WaitOne(this._ReadWriteTimeout, false); // wait until a write occurs
            }
            lock (_Buffer)
            {
                // fill the read buffer
                readLength = ReadToBuffer(buffer, offset, count);
                _ReadEvent.Set();
            }
            return readLength;
        }
        protected virtual int ReadToBuffer(byte[] buffer, int offset, int count)
        {
            int readLength = 0;

            for (; readLength < count && Length > 0; readLength++)
            {
                buffer[readLength] = _Buffer.Dequeue();
            }

            return readLength;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentException("Buffer is null");
            if (offset + count > buffer.Length)
                throw new ArgumentException("The sum of offset and count is greater than the buffer length. ");
            if (offset < 0 || count < 0)
                throw new ArgumentOutOfRangeException("offset or count is negative.");
            if (count == 0)
                return;
            while (Length >= _MaxBufferLength)
            {
                _ReadEvent.Reset();
                _WriteEvent.Set(); // release any blocked read events
                _ReadEvent.WaitOne(this._ReadWriteTimeout, false);
            }
            lock (_Buffer)
            {
                _Flushed = false; // if it were flushed before, it soon will not be.

                WriteToBuffer(buffer, offset, count);

                this._TotalWrite += count;

                _WriteEvent.Set(); // signal that write has occured
            }
        }
        protected virtual void WriteToBuffer(byte[] buffer, int offset, int count)
        {
            // queue up the buffer data
            for (int i = offset; i < count; i++)
            {
                _Buffer.Enqueue(buffer[i]);
            }
        }
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override long Length
        {
            get
            {
                return _Buffer.Count;
            }
        }
        public override long Position
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _Buffer.Clear();
            TotalWrite = 0;

            (_WriteEvent as IDisposable).Dispose();
            (_ReadEvent as IDisposable).Dispose();
        }
        public long TotalWrite
        {
            get
            {
                return _TotalWrite;
            }
            set
            {
                _TotalWrite = value;
            }
        }
    }
}
