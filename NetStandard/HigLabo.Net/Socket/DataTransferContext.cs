using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using HigLabo.Core;

namespace HigLabo.Net.Internal
{
	/// <summary>
    /// Represent context of request and response process and provide data about context.
    /// </summary>
    public class DataTransferContext : IDisposable
    {
		private static BufferManager _BufferManager = new BufferManager(256, 8192);
		private DateTime _StartTime = DateTime.Now;
		private Byte[] _Buffer;
        private Stream _Stream = null;
        private Exception _Exception = null;
		private Boolean _Timeout = false;
		private Encoding _Encoding = Encoding.UTF8;
		private Boolean _IsDisposed = false;
		/// <summary>
		/// 
		/// </summary>
		public static BufferManager BufferManager
		{
            get { return _BufferManager; }
			set { _BufferManager = value; }
		}
        /// <summary>
        /// 
        /// </summary>
        internal protected Stream Stream
        {
            get { return _Stream; }
        }
        /// <summary>
        /// 
        /// </summary>
        internal protected DateTime StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		protected Encoding Encoding
		{
			get { return _Encoding; }
			set { _Encoding = value; }
		}
        /// <summary>
        /// 
        /// </summary>
        internal protected Byte[] Buffer
        {
            get
            {
                this.ValidateDisposed();
                return _Buffer;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }
        /// <summary>
        /// 
        /// </summary>
		public Boolean Timeout
		{
			get { return _Timeout; }
			set { _Timeout = value; }
		}
		internal DataTransferContext(Stream stream, Encoding encoding)
		{
            _Stream = stream;
            _Encoding = encoding;
			_Buffer = DataTransferContext.BufferManager.CheckOut();
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal protected Byte[] GetData()
        {
            _Stream.Position = 0;
            return _Stream.ToByteArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal protected String GetText()
        {
            return this.Encoding.GetString(this.GetData());
        }
        private void ValidateDisposed()
        {
            if (this._IsDisposed == true) throw new ObjectDisposedException("DataTransferContext");
        }
        /// 終了処理を実行し、システムリソースを解放します。
		/// <summary>
		/// dipose and release system resoures.
		/// 終了処理を実行し、システムリソースを解放します。
		/// </summary>
		public void Dispose()
		{
			GC.SuppressFinalize(this);
			this.Dispose(true);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		protected void Dispose(Boolean disposing)
		{
			if (disposing)
			{
				if (this._IsDisposed == false &&
					this._Buffer != null)
				{
					DataTransferContext.BufferManager.CheckIn(this._Buffer);
                    _Buffer = null;
                    this._IsDisposed = true;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		~DataTransferContext()
		{
			this.Dispose(false);
		}
    }
}
