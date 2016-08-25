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
using Newtonsoft.Json.Linq;

namespace HigLabo.Web.Mvc
{
    public class WebApiMultiParameterBinding : HttpParameterBinding
    {
        private const String CacheKeyPrefix = "WebApiMultiParameterBinding";
        public List<ParameterDataProvider> DataProviders { get; private set; }
        public JsonSerializer JsonSerializer { get; set; }
        public Boolean IsUnifyLineFeed { get; set; }

        public WebApiMultiParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            this.DataProviders = new List<ParameterDataProvider>();
            this.JsonSerializer = new JsonSerializer();
            this.IsUnifyLineFeed = true;
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Dictionary<String, String> d = new Dictionary<string, string>();
            String s = null;

            foreach (var item in this.DataProviders)
            {
                var ds = this.GetDataSource(actionContext, item);
                foreach (var key in ds.Keys)
                {
                    if (d.ContainsKey(key) == true) { continue; }
                    d[key] = ds[key];
                }
                if (ds.ContainsKey(Descriptor.ParameterName) == true)
                {
                    s = ds[Descriptor.ParameterName];
                    break;
                }
            }
            
            Object pValue = null;

            if (Descriptor.ParameterType == typeof(String))
            {
                if (this.IsUnifyLineFeed == true)
                {
                    pValue = s.UnifyLineFeed();
                }
                else
                {
                    pValue = s;
                }
            }
            else if (Descriptor.ParameterType == typeof(Boolean) || Descriptor.ParameterType == typeof(Boolean?)) { pValue = s.ToBoolean(); }
            else if (Descriptor.ParameterType == typeof(Guid) || Descriptor.ParameterType == typeof(Guid?)) { pValue = s.ToGuid(); }
            else if (Descriptor.ParameterType == typeof(Int16) || Descriptor.ParameterType == typeof(Int16?)) { pValue = s.ToInt16(); }
            else if (Descriptor.ParameterType == typeof(Int32) || Descriptor.ParameterType == typeof(Int32?)) { pValue = s.ToInt32(); }
            else if (Descriptor.ParameterType == typeof(Int64) || Descriptor.ParameterType == typeof(Int64?)) { pValue = s.ToInt64(); }
            else if (Descriptor.ParameterType == typeof(UInt16) || Descriptor.ParameterType == typeof(UInt16?)) { pValue = s.ToUInt16(); }
            else if (Descriptor.ParameterType == typeof(UInt32) || Descriptor.ParameterType == typeof(UInt32?)) { pValue = s.ToUInt32(); }
            else if (Descriptor.ParameterType == typeof(UInt64) || Descriptor.ParameterType == typeof(UInt64?)) { pValue = s.ToUInt64(); }
            else if (Descriptor.ParameterType == typeof(Byte) || Descriptor.ParameterType == typeof(Byte?)) { pValue = s.ToByte(); }
            else if (Descriptor.ParameterType == typeof(SByte) || Descriptor.ParameterType == typeof(SByte?)) { pValue = s.ToSByte(); }
            else if (Descriptor.ParameterType == typeof(Single) || Descriptor.ParameterType == typeof(Single?)) { pValue = s.ToSingle(); }
            else if (Descriptor.ParameterType == typeof(Double) || Descriptor.ParameterType == typeof(Double?)) { pValue = s.ToDouble(); }
            else if (Descriptor.ParameterType == typeof(Decimal) || Descriptor.ParameterType == typeof(Decimal?)) { pValue = s.ToDecimal(); }
            else if (Descriptor.ParameterType == typeof(DateTime) || Descriptor.ParameterType == typeof(DateTime?)) { pValue = s.ToDateTime(); }
            else if (Descriptor.ParameterType == typeof(DateTimeOffset) || Descriptor.ParameterType == typeof(DateTimeOffset?)) { pValue = s.ToDateTimeOffset(); }
            else if (Descriptor.ParameterType.IsEnum) { pValue = s.ToEnum(Descriptor.ParameterType); }
            else if (Descriptor.ParameterType.IsInheritanceFrom(typeof(Nullable<>)) == true)
            {
                var tp = Descriptor.ParameterType.GetGenericArguments()[0];
                if (tp.IsEnum)
                {
                    pValue = s.ToEnum(tp);
                }
            }
            else if (Descriptor.ParameterType.IsInheritanceFrom(typeof(IEnumerable<>)))
            {
                if (s.Trim().StartsWith("["))
                {
                    var oo = JsonConvert.DeserializeObject(s.Trim());
                    if (oo is JArray)
                    {
                        Type tp = Descriptor.ParameterType.GetGenericArguments()[0];
                        var ltp = typeof(List<>).MakeGenericType(tp);
                        var md = ltp.GetMethod("Add");
                        var pp = Activator.CreateInstance(ltp);
                        foreach (var o in oo as JArray)
                        {
                            if (o is JObject)
                            {
                                var dd = new Dictionary<String, String>();
                                var jo = o as JObject;
                                foreach (var property in jo.Properties())
                                {
                                    dd[property.Name] = jo[property.Name].ToString();
                                }
                                var o1 = Activator.CreateInstance(tp);
                                dd.Map(o1);
                                md.Invoke(pp, new Object[] { o1 });
                            }
                        }
                        pValue = pp;
                    }
                }
            }
            else if (Descriptor.ParameterType.IsPrimitive || Descriptor.ParameterType.IsValueType)
            {
                try
                {
                    pValue = Convert.ChangeType(s, Descriptor.ParameterType);
                }
                catch { }
            }
            else if (Descriptor.ParameterType.IsClass)
            {
                try
                {
                    var o = Activator.CreateInstance(Descriptor.ParameterType);
                    d.Map(o);
                    pValue = o;
                }
                catch { }
            }

            if (pValue == null && Descriptor.DefaultValue != null)
            {
                pValue = Descriptor.DefaultValue;
            }
            if (pValue == null)
            {
                if (Descriptor.ParameterType.IsInheritanceFrom(typeof(Nullable<>)) ||
                    Descriptor.ParameterType.IsClass)
                {
                    this.SetValue(actionContext, pValue);
                }
            }
            else
            {
                this.SetValue(actionContext, pValue);
            }

            TaskCompletionSource<Object> tcs = new TaskCompletionSource<Object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
        protected Dictionary<String, String> GetDataSource(HttpActionContext context, ParameterDataProvider provider)
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
            var bd = new WebApiMultiParameterBinding(descriptor);
            bd.DataProviders.Add(new ParameterDataProviderFromHttpRouteData());
            bd.DataProviders.Add(new ParameterDataProviderFromQueryString());
            bd.DataProviders.Add(new ParameterDataProviderFromRequestHeader());
            bd.DataProviders.Add(new ParameterDataProviderFromRequestBody());

            return bd;
        }
    }
}
