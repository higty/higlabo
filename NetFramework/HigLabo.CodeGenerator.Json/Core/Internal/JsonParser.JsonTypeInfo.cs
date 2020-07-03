using System;

namespace HigLabo.CodeGenerator.Json
{
    public partial class JsonParser
    {
        public enum JsonTypeInfo
        {
            Unknown,
            String,
            Boolean,
            Int32,
            Int64,
            Double,
            DateTime,
            Object,
            Array,
            Dictionary,
        }
    }
}
