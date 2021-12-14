using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net
{
	/// <summary>
	/// A manager to handle buffers for the socket connections
	/// </summary>
	/// <remarks>
	/// When used in an async call a buffer is pinned. Large numbers of pinned buffers
	/// cause problem with the GC (in particular it causes heap fragmentation).
	///
	/// This class maintains a set of large segments and gives clients pieces of these
	/// segments that they can use for their buffers. The alternative to this would be to
    /// create many small arrays which it then maintains. This methodology should be slightly
	/// better than the many small array methodology because in creating only a few very
	/// large Objects it will force these Objects to be placed on the LOH. Since the
	/// Objects are on the LOH they are at this time not subject to compacting which would
	/// require an update of all GC roots as would be the case with lots of smaller arrays
	/// that were in the normal heap.
	/// </remarks>
    public class BufferManager
    {
        private Int32 _PoolSize = 512; // initial size of the pool
        private Int32 _BufferSize = 1024; // size of the buffers
        private Int32 _DequeueRetryCount = 4;
        private Queue<Byte[]> _Buffers;
        private Object _LockObject = new Object();

        public Int32 DequeueRetryCount
        {
            get { return _DequeueRetryCount; }
            set { _DequeueRetryCount = value; }
        }
        public Int32 BufferCount
        {
            get
            {
                lock (_LockObject)
                {
                    return _Buffers.Count;
                }
            }
        }
        public BufferManager()
        {
            this.Initialize();
        }
        public BufferManager(Int32 poolSize, Int32 bufferSize)
        {
            this._PoolSize = poolSize;
            this._BufferSize = bufferSize;
            this.Initialize();
        }

        private void Initialize()
        {
            _Buffers = new Queue<Byte[]>(_PoolSize);
            for (int i = 0; i < _PoolSize; i++)
            {
                _Buffers.Enqueue(new byte[_BufferSize]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Byte[] CheckOut()
        {
            Int32 count = 1;

            while (true)
            {
                if (_Buffers.Count > 0)
                {
                    lock (_LockObject)
                    {
                        if (_Buffers.Count > 0)
                        {
                            return _Buffers.Dequeue();
                        }
                    }
                }
                count += 1;
                if (count > _DequeueRetryCount) { break; }
#if !NETFX_CORE
                System.Threading.Thread.Sleep(100);
#endif
            }
            throw new InvalidOperationException("Buffer dequeue failed.You must be set more pool size.Or some class may not CheckIn buffer ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void CheckIn(byte[] buffer)
        {
            lock (_LockObject)
            {
                _Buffers.Enqueue(buffer);
            }
        }
    }
}