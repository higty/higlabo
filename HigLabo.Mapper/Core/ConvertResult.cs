using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ConvertResult<T>
    {
        public Boolean Success { get; set; }
        public T Value { get; set; }

        public ConvertResult()
        {
            this.Success = false;
        }
        public ConvertResult(Boolean success, T value)
        {
            this.Success = success;
            this.Value = value;
        }
    }
    public class ConvertResult
    {
        public static ConvertResult<T> Create<T>(Nullable<T> value)
            where T : struct
        {
            if (value.HasValue == true)
            {
                return new ConvertResult<T>(true, value.Value);
            }
            return new ConvertResult<T>();
        }
    }
}
