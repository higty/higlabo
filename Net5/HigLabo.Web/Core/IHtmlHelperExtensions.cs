using HigLabo.Web.UI;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public static class IHtmlHelperExtensions
    {

        public static HtmlString Text(this IHtmlHelper helper, Boolean condition, String trueText)
        {
            return helper.Text(condition, trueText, "");
        }
        public static HtmlString Text(this IHtmlHelper helper, Boolean condition, String trueText, String falseText)
        {
            if (condition == true)
            {
                return new HtmlString(trueText);
            }
            return new HtmlString(falseText);
        }
        public static HtmlString IsNullText(this IHtmlHelper helper, String text, String textWhenNullOrEmpty)
        {
            if (String.IsNullOrWhiteSpace(text) == true)
            {
                return new HtmlString(textWhenNullOrEmpty);
            }
            return new HtmlString(text);
        }

        public static HtmlString OptionSelected(this IHtmlHelper helper, Boolean condition)
        {
            return helper.Text(condition, "selected=\"selected\"");
        }
        public static HtmlString InputChecked(this IHtmlHelper helper, Boolean condition)
        {
            return helper.Text(condition, "checked=\"checked\"");
        }

        public static async Task HigLaboCommonTemplateRenderPartialAsync(this IHtmlHelper html)
        {
            await html.RenderPartialAsync(HigLaboView.CommonTemplate);
        }
        public static async Task RenderPartialAsync(this IHtmlHelper html, SelectTimePopupPanel panel)
        {
            await html.RenderPartialAsync(HigLaboView.SelectTimePopupPanel, panel);
        }
        public static async Task RenderPartialAsync(this IHtmlHelper html, InputPropertyPanelMessagePanel panel)
        {
            await html.RenderPartialAsync(HigLaboView.InputPropertyPanelMessagePanel, panel);
        }
        public static async Task RenderPartialAsync(this IHtmlHelper html, ValidationResultMessagePanel panel)
        {
            await html.RenderPartialAsync(HigLaboView.ValidationResultMessagePanel, panel);
        }
        public static async Task RenderPartialAsync(this IHtmlHelper html, InputPropertyPanel panel)
        {
            await html.RenderPartialAsync(HigLaboView.InputPropertyPanel, panel);
        }
        public static async Task RenderPartialAsync(this IHtmlHelper html, EditRecordPanelTemplate element)
        {
            await html.RenderPartialAsync(HigLaboView.EditRecordPanelTemplate, element);
        }
    }
}
