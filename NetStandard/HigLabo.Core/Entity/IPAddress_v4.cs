using System;
using System.Collections.Generic;
using System.Linq;

namespace HigLabo.Core
{
    public class IPAddress_v4
    {
        public Int64 Value { get; private set; }
        public Byte Value1 { get; private set; }
        public Byte Value2 { get; private set; }
        public Byte Value3 { get; private set; }
        public Byte Value4 { get; private set; }

        public IPAddress_v4(Byte value1, Byte value2, Byte value3, Byte value4)
        {
            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
            this.Value4 = value4;
            Int64 x = 256;
            this.Value = value1 * x * x * x
                + value2 * x * x
                + value3 * x
                + value4;
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", this.Value1, this.Value2, this.Value3, this.Value4);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) { return false; }

            IPAddress_v4 c = (IPAddress_v4)obj;
            return this.Value == c.Value;
        }
        public override int GetHashCode()
        {
            return (Int32)this.Value;
        }
        /// <summary>
        /// IP Address or IP Address with port number
        /// xxx.xxx.xxx.xxx, xxx.xxx.xxx.xxx:80
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IPAddress_v4 TryCreate(String value)
        {
            if (String.IsNullOrEmpty(value)) { return null; }
            String[] ss = null;
            String ip = "";

            if (value.Contains(":") == true)
            {
                ss = value.Split(':');
                ip = ss[0];
            }
            else
            {
                ip = value;
            }
            ss = ip.Split('.');
            Byte[] xx = new Byte[4];
            if (xx.Length != 4) { return null; }
            for (int i = 0; i < ss.Length; i++)
            {
                if (Byte.TryParse(ss[i], out xx[i]) == false) { return null; }
            }
            return new IPAddress_v4(xx[0], xx[1], xx[2], xx[3]);
        }
        public static IEnumerable<IPAddress_v4> TryCreate(params String[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return TryCreate(values[i]);
            }
        }
    }
}