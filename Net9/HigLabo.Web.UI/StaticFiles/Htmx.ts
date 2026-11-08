import { HtmlElementQuery } from "./HtmlElementQuery.js";

export class Htmx {
    private static _initialized = false;

    // Call during application startup, before updating htmx-enabled HTML.
    public initialize() {
        if (Htmx._initialized) { return; }

        HtmlElementQuery.subscribeHtmlRemoving(elementList => {
            const htmx = this.getHtmx();
            if (htmx == null || elementList.length == 0) { return; }
            if (typeof htmx.__cleanup !== "function") {
                throw new Error("Htmx cleanup requires the unminified htmx 4.0.0 source.");
            }
            for (const element of elementList) {
                // Reset removed elements too, so they can be processed again if reinserted.
                htmx.__cleanup(element, true);
            }
        });
        HtmlElementQuery.subscribeHtmlChanged(elementList => {
            for (const element of elementList) {
                this.process(element);
            }
        });
        Htmx._initialized = true;
    }

    private getHtmx() {
        return window["htmx"];
    }

    public process(selectorOrElement: Element | ShadowRoot | string, force: boolean = false) {
        const htmx = this.getHtmx();
        if (htmx == null) { return; }

        if (typeof selectorOrElement === "string") {
            document.querySelectorAll(selectorOrElement).forEach(el => {
                htmx.process(el, force);
            });
        }
        else if (selectorOrElement instanceof Element || selectorOrElement instanceof ShadowRoot) {
            htmx.process(selectorOrElement, force);
        }
    }

    public trigger(selector: Element | Document | string, event: string) {
        try {
            const htmx = this.getHtmx();
            if (htmx == null) { return; }
            const element = typeof selector === "string" ? document.querySelector(selector) : selector;
            if (element?.isConnected != true) { return; }
            htmx.trigger(element, event);
        }
        catch { }
    }
}
