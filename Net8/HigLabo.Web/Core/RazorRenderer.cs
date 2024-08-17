using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
	public class RazorRenderer(IHttpContextAccessor contextAccessor, IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    {
		private IHttpContextAccessor _contextAccessor = contextAccessor;
		private IRazorViewEngine _viewEngine = viewEngine;
		private ITempDataProvider _tempDataProvider = tempDataProvider;
		private IServiceProvider _serviceProvider = serviceProvider;

        public async ValueTask<string> ToHtmlAsync(string viewName)
        {
            var d = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            return await ToHtmlAsync(viewName, d);
        }
        public async ValueTask<string> ToHtmlAsync<TModel>(string viewName, TModel model)
		{
            var d = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            d.Model = model;
			return await ToHtmlAsync(viewName, d as ViewDataDictionary);
        }
		public async ValueTask<string> ToHtmlAsync(string viewName, ViewDataDictionary viewData)
		{
			var context = _contextAccessor.HttpContext;
			if (context == null) { throw new InvalidOperationException(); }

			var actionContext = new ActionContext(context, context.GetRouteData(), new ActionDescriptor());
			var tempData = new TempDataDictionary(context, _tempDataProvider);

			using (var output = new StringWriter())
			{
				var partialView = FindView(actionContext, viewName);
				var viewContext = new ViewContext(actionContext, partialView, viewData, tempData, output, new HtmlHelperOptions());
				await partialView.RenderAsync(viewContext);
				return output.ToString();
			}
        }
        public async ValueTask WriteHtmlAsync(HttpContext context, string viewName)
        {
            await WriteHtmlAsync(context.Response, viewName);
        }
        public async ValueTask WriteHtmlAsync(HttpResponse response, string viewName)
        {
            var d = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            var html = await ToHtmlAsync(viewName, d);
            await response.WriteAsync(html);
        }
        public async ValueTask WriteHtmlAsync<TModel>(HttpContext context, string viewName, TModel model)
        {
            await WriteHtmlAsync(context.Response, viewName, model);
		}
		public async ValueTask WriteHtmlAsync<TModel>(HttpResponse response, string viewName, TModel model)
		{
			var html = await ToHtmlAsync(viewName, model);
			await response.WriteAsync(html);
        }
		
		private IView FindView(ActionContext actionContext, string viewName)
		{
			var getPartialResult = _viewEngine.GetView(null, viewName, false);
			if (getPartialResult.Success)
			{
				return getPartialResult.View;
			}
			var findPartialResult = _viewEngine.FindView(actionContext, viewName, false);
			if (findPartialResult.Success)
			{
				return findPartialResult.View;
			}
			var searchedLocations = getPartialResult.SearchedLocations.Concat(findPartialResult.SearchedLocations);
			var errorMessage = string.Join(Environment.NewLine
				, new[] { $"Unable to find partial '{viewName}'. The following locations were searched:" }.Concat(searchedLocations)); ;
			throw new InvalidOperationException(errorMessage);
		}
	}
}
