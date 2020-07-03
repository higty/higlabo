using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HigLabo.Web.Mvc
{
    public static class ControllerExtensions
    {
        public static String ToHtml(this Controller controller, ViewType viewType, String viewPath, Object model)
        {
            using (var sw = new StringWriter())
            {
                controller.Render(viewType, viewPath, model, sw);
                return sw.ToString();
            }
        }
        public static void Render(this Controller controller, ViewType viewType, String viewPath, Object model, TextWriter writer)
        {
            var cx = controller.ControllerContext;
            if (cx == null)
            {
                cx = CreateControllerContext(controller);
            }
            ViewEngineResult viewEngineResult = null;
            switch (viewType)
            {
                case ViewType.View: viewEngineResult = ViewEngines.Engines.FindView(cx, viewPath, null); break;
                case ViewType.PartialView: viewEngineResult = ViewEngines.Engines.FindPartialView(cx, viewPath); break;
                default: throw new InvalidOperationException();
            }
            if (viewEngineResult == null)
            {
                throw new InvalidOperationException("View not found");
            }
            var view = viewEngineResult.View;
            cx.Controller.ViewData.Model = model;
            var ctx = new ViewContext(cx, view, cx.Controller.ViewData, cx.Controller.TempData, writer);
            view.Render(ctx, writer);
        }
        private static ControllerContext CreateControllerContext(Controller controller)
        {
            if (HttpContext.Current == null) throw new InvalidOperationException("HttpContext unavailable");

            var routeData = new RouteData();
            if (routeData.Values.ContainsKey("controller") == false && routeData.Values.ContainsKey("Controller") == false)
            {
                routeData.Values.Add("controller", controller.GetType().Name.ToLower().Replace("controller", ""));
            }
            return new ControllerContext(new HttpContextWrapper(HttpContext.Current), routeData, controller);
        }
    }
}
