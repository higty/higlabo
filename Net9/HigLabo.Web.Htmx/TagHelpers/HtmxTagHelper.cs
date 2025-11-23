using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web
{
    /// <summary>
    /// Exposes htmx hx-* attributes as Razor TagHelper properties for IntelliSense support.
    /// </summary>
    [HtmlTargetElement(Attributes = HtmxAttributeNames)]
    public class HtmxTagHelper : TagHelper
    {
        private const string HtmxAttributeNames =
            "hx-get,hx-post,hx-put,hx-patch,hx-delete," +
            "hx-target,hx-swap,hx-swap-oob,hx-trigger," +
            "hx-push-url,hx-replace-url," +
            "hx-select,hx-select-oob,hx-vals," +
            "hx-boost,hx-confirm," +
            "hx-disable,hx-disabled-elt," +
            "hx-disinherit,hx-inherit," +
            "hx-encoding,hx-ext,hx-headers," +
            "hx-history,hx-history-elt," +
            "hx-include,hx-indicator," +
            "hx-params,hx-preserve,hx-prompt," +
            "hx-sync";

        /// <summary>Issues an AJAX GET request to the given URL and swaps the response.</summary>
        [HtmlAttributeName("hx-get")]
        public string? HxGet { get; set; }
        /// <summary>Issues an AJAX POST request to the given URL and swaps the response.</summary>
        [HtmlAttributeName("hx-post")]
        public string? HxPost { get; set; }
        /// <summary>Issues an AJAX PUT request to the given URL and swaps the response.</summary>
        [HtmlAttributeName("hx-put")]
        public string? HxPut { get; set; }
        /// <summary>Issues an AJAX PATCH request to the given URL and swaps the response.</summary>
        [HtmlAttributeName("hx-patch")]
        public string? HxPatch { get; set; }
        /// <summary>Issues an AJAX DELETE request to the given URL and swaps the response.</summary>
        [HtmlAttributeName("hx-delete")]
        public string? HxDelete { get; set; }
        /// <summary>CSS selector for the element that receives the swapped response.</summary>
        [HtmlAttributeName("hx-target")]
        public string? HxTarget { get; set; }
        /// <summary>Controls how and where the response content is inserted.</summary>
        [HtmlAttributeName("hx-swap")]
        public string? HxSwap { get; set; }
        /// <summary>Marks content that should be swapped out-of-band elsewhere.</summary>
        [HtmlAttributeName("hx-swap-oob")]
        public string? HxSwapOob { get; set; }
        /// <summary>Defines events or polling rules that trigger the request.</summary>
        [HtmlAttributeName("hx-trigger")]
        public string? HxTrigger { get; set; }
        /// <summary>Pushes a new URL into browser history on request completion.</summary>
        [HtmlAttributeName("hx-push-url")]
        public string? HxPushUrl { get; set; }
        /// <summary>Replaces the current browser URL on request completion.</summary>
        [HtmlAttributeName("hx-replace-url")]
        public string? HxReplaceUrl { get; set; }
        /// <summary>Controls whether responses are stored in the htmx history cache.</summary>
        [HtmlAttributeName("hx-history")]
        public string? HxHistory { get; set; }
        /// <summary>Limits history snapshots to this element's subtree.</summary>
        [HtmlAttributeName("hx-history-elt")]
        public string? HxHistoryElt { get; set; }
        /// <summary>Selects a subset of response HTML for swapping.</summary>
        [HtmlAttributeName("hx-select")]
        public string? HxSelect { get; set; }
        /// <summary>Selects response fragments for out-of-band swapping.</summary>
        [HtmlAttributeName("hx-select-oob")]
        public string? HxSelectOob { get; set; }
        /// <summary>Adds extra JSON values to be submitted with the request.</summary>
        [HtmlAttributeName("hx-vals")]
        public string? HxVals { get; set; }
        /// <summary>Enhances standard links/forms with htmx behavior.</summary>
        [HtmlAttributeName("hx-boost")]
        public string? HxBoost { get; set; }
        /// <summary>Shows a confirmation dialog before sending the request.</summary>
        [HtmlAttributeName("hx-confirm")]
        public string? HxConfirm { get; set; }
        /// <summary>Displays a prompt dialog and submits the entered value.</summary>
        [HtmlAttributeName("hx-prompt")]
        public string? HxPrompt { get; set; }
        /// <summary>CSS selector for request indicator elements.</summary>
        [HtmlAttributeName("hx-indicator")]
        public string? HxIndicator { get; set; }
        /// <summary>Disables htmx on this element and its descendants.</summary>
        [HtmlAttributeName("hx-disable")]
        public string? HxDisable { get; set; }
        /// <summary>Marks elements to be disabled while a request is active.</summary>
        [HtmlAttributeName("hx-disabled-elt")]
        public string? HxDisabledElt { get; set; }
        /// <summary>Prevents specified attributes from being inherited by children.</summary>
        [HtmlAttributeName("hx-disinherit")]
        public string? HxDisinherit { get; set; }
        /// <summary>Forces inheritance of attributes by child elements.</summary>
        [HtmlAttributeName("hx-inherit")]
        public string? HxInherit { get; set; }
        /// <summary>Overrides the encoding used when sending request data.</summary>
        [HtmlAttributeName("hx-encoding")]
        public string? HxEncoding { get; set; }
        /// <summary>Enables one or more htmx extensions on the element.</summary>
        [HtmlAttributeName("hx-ext")]
        public string? HxExt { get; set; }
        /// <summary>Adds custom HTTP headers to the request.</summary>
        [HtmlAttributeName("hx-headers")]
        public string? HxHeaders { get; set; }
        /// <summary>Includes values from other elements in the request.</summary>
        [HtmlAttributeName("hx-include")]
        public string? HxInclude { get; set; }
        /// <summary>Controls which parameters are submitted in the request.</summary>
        [HtmlAttributeName("hx-params")]
        public string? HxParams { get; set; }
        /// <summary>Marks elements to be preserved and not swapped.</summary>
        [HtmlAttributeName("hx-preserve")]
        public string? HxPreserve { get; set; }
        /// <summary>Controls synchronization/queuing/cancellation of requests.</summary>
        [HtmlAttributeName("hx-sync")]
        public string? HxSync { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            SetIfNotNull(output, "hx-get", HxGet);
            SetIfNotNull(output, "hx-post", HxPost);
            SetIfNotNull(output, "hx-put", HxPut);
            SetIfNotNull(output, "hx-patch", HxPatch);
            SetIfNotNull(output, "hx-delete", HxDelete);
            SetIfNotNull(output, "hx-target", HxTarget);
            SetIfNotNull(output, "hx-swap", HxSwap);
            SetIfNotNull(output, "hx-swap-oob", HxSwapOob);
            SetIfNotNull(output, "hx-trigger", HxTrigger);
            SetIfNotNull(output, "hx-push-url", HxPushUrl);
            SetIfNotNull(output, "hx-replace-url", HxReplaceUrl);
            SetIfNotNull(output, "hx-history", HxHistory);
            SetIfNotNull(output, "hx-history-elt", HxHistoryElt);
            SetIfNotNull(output, "hx-select", HxSelect);
            SetIfNotNull(output, "hx-select-oob", HxSelectOob);
            SetIfNotNull(output, "hx-vals", HxVals);
            SetIfNotNull(output, "hx-boost", HxBoost);
            SetIfNotNull(output, "hx-confirm", HxConfirm);
            SetIfNotNull(output, "hx-prompt", HxPrompt);
            SetIfNotNull(output, "hx-indicator", HxIndicator);
            SetIfNotNull(output, "hx-disable", HxDisable);
            SetIfNotNull(output, "hx-disabled-elt", HxDisabledElt);
            SetIfNotNull(output, "hx-disinherit", HxDisinherit);
            SetIfNotNull(output, "hx-inherit", HxInherit);
            SetIfNotNull(output, "hx-encoding", HxEncoding);
            SetIfNotNull(output, "hx-ext", HxExt);
            SetIfNotNull(output, "hx-headers", HxHeaders);
            SetIfNotNull(output, "hx-include", HxInclude);
            SetIfNotNull(output, "hx-params", HxParams);
            SetIfNotNull(output, "hx-preserve", HxPreserve);
            SetIfNotNull(output, "hx-sync", HxSync);
        }

        private static void SetIfNotNull(TagHelperOutput output, string name, string? value)
        {
            if (value != null)
            {
                output.Attributes.SetAttribute(name, value);
            }
        }
    }
}
