using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using HigLabo.Core;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace HigLabo.Web.Mvc
{
    public class WebApiMultiParameterBinding : HttpParameterBinding
    {
        private const String CacheKeyPrefix = "WebApiMultiParameterBinding";
        public List<ParameterDataProvider> DataProviders { get; private set; }
        public JsonSerializer JsonSerializer { get; set; }

        public WebApiMultiParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            this.DataProviders = new List<ParameterDataProvider>();
            this.JsonSerializer = new JsonSerializer();
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Dictionary<String, String> d = null;
            String s = null;

            foreach (var item in this.DataProviders)
            {
                d = this.GetDataSource(actionContext, item);
                if (d.ContainsKey(Descriptor.ParameterName) == true)
                {
                    s = d[Descriptor.ParameterName];
                    break;
                }
            }
            if (s != null)
            {
                Object pValue = null;

                if (Descriptor.ParameterType == typeof(String)) { pValue = s; }
                if (Descriptor.ParameterType == typeof(Guid)) { pValue = s.ToGuid(); }
                if (Descriptor.ParameterType == typeof(Int16)) { pValue = s.ToInt16(); }
                if (Descriptor.ParameterType == typeof(Int32)) { pValue = s.ToInt32(); }
                if (Descriptor.ParameterType == typeof(Int64)) { pValue = s.ToInt64(); }
                if (Descriptor.ParameterType == typeof(UInt16)) { pValue = s.ToUInt16(); }
                if (Descriptor.ParameterType == typeof(UInt32)) { pValue = s.ToUInt32(); }
                if (Descriptor.ParameterType == typeof(UInt64)) { pValue = s.ToUInt64(); }
                if (Descriptor.ParameterType == typeof(Byte)) { pValue = s.ToByte(); }
                if (Descriptor.ParameterType == typeof(SByte)) { pValue = s.ToSByte(); }
                if (Descriptor.ParameterType == typeof(Single)) { pValue = s.ToSingle(); }
                if (Descriptor.ParameterType == typeof(Double)) { pValue = s.ToDouble(); }
                if (Descriptor.ParameterType == typeof(Decimal)) { pValue = s.ToDecimal(); }
                if (Descriptor.ParameterType == typeof(DateTime)) { pValue = s.ToDateTime(); }
                if (Descriptor.ParameterType == typeof(DateTimeOffset)) { pValue = s.ToDateTimeOffset(); }
                if (Descriptor.ParameterType.IsEnum) {  }
                if (Descriptor.ParameterType.IsPrimitive || Descriptor.ParameterType.IsValueType)
                {
                    try
                    {
                        pValue = Convert.ChangeType(s, Descriptor.ParameterType);
                    }
                    catch { }
                }
                if (pValue == null)
                {
                    try
                    {
                        pValue = this.JsonSerializer.Deserialize(new StringReader(s), Descriptor.ParameterType);
                    }
                    catch { }
                }
                this.SetValue(actionContext, pValue);
            }

            TaskCompletionSource<Object> tcs = new TaskCompletionSource<Object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
        private Dictionary<String, String> GetDataSource(HttpActionContext context, ParameterDataProvider provider)
        {
            var req = context.Request;
            Object o = null;
            var cacheKey = CacheKeyPrefix + provider.GetCacheKey();

            if (req.Properties.TryGetValue(cacheKey, out o)) { return o as Dictionary<String, String>; }

            var d = provider.GetDataSource(context);
            req.Properties.Add(cacheKey, d);

            return d;
        }

        public static WebApiMultiParameterBinding Create(HttpParameterDescriptor descriptor)
        {
            var md = descriptor.ActionDescriptor.SupportedHttpMethods;
            if (md.Contains(HttpMethod.Post) || md.Contains(HttpMethod.Put))
            {
                var bd = new WebApiMultiParameterBinding(descriptor);
                bd.DataProviders.Add(new ParameterDataProviderFromQueryString());
                bd.DataProviders.Add(new ParameterDataProviderFromRequestHeader());
                bd.DataProviders.Add(new ParameterDataProviderFromRequestBody());

                return bd;
            }
            return null;
        }
    }
}
