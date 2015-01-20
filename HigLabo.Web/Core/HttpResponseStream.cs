using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class HttpResponseStream : Stream
    {
        private readonly Stream _Stream;
        private Int64 _Length;

        /// <summary>
        /// 派生クラスでオーバーライドされた場合は、現在のストリームが読み取りをサポートするかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// ストリームが読み込みをサポートしている場合は true。それ以外の場合は false。
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override Boolean CanRead
        {
            get { return _Stream.CanRead; }
        }
        /// <summary>
        /// 派生クラスでオーバーライドされた場合は、現在のストリームがシークをサポートするかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// ストリームがシークをサポートしている場合は <c>true</c>。それ以外の場合は <c>false</c>。
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override Boolean CanSeek
        {
            get { return _Stream.CanSeek; }
        }
        /// <summary>
        /// 派生クラスでオーバーライドされた場合は、現在のストリームが書き込みをサポートするかどうかを示す値を取得します。
        /// </summary>
        /// <returns>
        /// ストリームが書き込みをサポートしている場合は <c>true</c>。それ以外の場合は <c>false</c>。
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override Boolean CanWrite
        {
            get { return _Stream.CanWrite; }
        }
        /// <summary>
        /// 派生クラスでオーバーライドされた場合は、ストリームの長さをバイト単位で取得します。
        /// </summary>
        /// <returns>
        /// ストリーム長 (バイト単位) を表す long 値。
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">Stream から派生したクラスがシークをサポートしていません。</exception><exception cref="T:System.ObjectDisposedException">ストリームが閉じられた後でメソッドが呼び出されました。</exception><filterpriority>1</filterpriority>
        public override Int64 Length
        {
            get { return _Length; }
        }
        /// <summary>
        /// 派生クラスでオーバーライドされた場合は、現在のストリーム内の位置を取得または設定します。
        /// </summary>
        /// <returns>
        /// ストリーム内の現在位置。
        /// </returns>
        /// <exception cref="T:System.IO.IOException">I/O エラーが発生しました。</exception><exception cref="T:System.NotSupportedException">ストリームがシークをサポートしていません。</exception><exception cref="T:System.ObjectDisposedException">ストリームが閉じられた後でメソッドが呼び出されました。</exception><filterpriority>1</filterpriority>
        public override Int64 Position
        {
            get { return _Stream.Position; }
            set { _Stream.Position = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public HttpResponseStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");

            _Stream = stream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public override long Seek(Int64 offset, SeekOrigin origin)
        {
            return _Stream.Seek(offset, origin);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            _Stream.Flush();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength(Int64 value)
        {
            _Stream.SetLength(value);
            _Length = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(Byte[] buffer, Int32 offset, Int32 count)
        {
            _Stream.Write(buffer, offset, count);
            _Length += count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public override IAsyncResult BeginWrite(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, object state)
        {
            _Length += count;
            return base.BeginWrite(buffer, offset, count, callback, state);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            try
            {
                _Stream.Close();
            }
            catch { }

            base.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count)
        {
            return _Stream.Read(buffer, offset, count);
        }
    }
}
