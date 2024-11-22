using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web;

	public class WebApiActionResultDefaultSetting
	{
		public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();
	}
	public class WebApiActionResult : WebApiResult<object>, IActionResult
	{
		public static readonly WebApiActionResultDefaultSetting DefaultSetting = new WebApiActionResultDefaultSetting();

		public WebApiActionResult(string dataType, object data)
			: this(System.Net.HttpStatusCode.OK, dataType, data)
		{
		}

		public WebApiActionResult(HttpStatusCode statusCode, string dataType, object? data)
		{
			base.HttpStatus = statusCode;
			this.DataType = dataType;
			this.Data = data;
		}

		public async Task ExecuteResultAsync(ActionContext context)
		{
			var cx = context.HttpContext;
			cx.Response.ContentType = "application/json";
			cx.Response.StatusCode = (int)base.HttpStatusCode;
			string s = JsonConvert.SerializeObject(this, DefaultSetting.JsonSerializerSettings);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await cx.Response.Body.WriteAsync(bytes, 0, bytes.Length);
			await cx.Response.Body.FlushAsync();
		}
	}
