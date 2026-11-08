import { HtmlElementQuery } from "./HtmlElementQuery.js";
export class Htmx {
    static _initialized = false;
    initialize() {
        if (Htmx._initialized) {
            return;
        }
        HtmlElementQuery.subscribeHtmlRemoving(elementList => {
            const htmx = this.getHtmx();
            if (htmx == null || elementList.length == 0) {
                return;
            }
            if (typeof htmx.__cleanup !== "function") {
                throw new Error("Htmx cleanup requires the unminified htmx 4.0.0 source.");
            }
            for (const element of elementList) {
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
    getHtmx() {
        return window["htmx"];
    }
    process(selectorOrElement, force = false) {
        const htmx = this.getHtmx();
        if (htmx == null) {
            return;
        }
        if (typeof selectorOrElement === "string") {
            document.querySelectorAll(selectorOrElement).forEach(el => {
                htmx.process(el, force);
            });
        }
        else if (selectorOrElement instanceof Element || selectorOrElement instanceof ShadowRoot) {
            htmx.process(selectorOrElement, force);
        }
    }
    trigger(selector, event) {
        try {
            const htmx = this.getHtmx();
            if (htmx == null) {
                return;
            }
            const element = typeof selector === "string" ? document.querySelector(selector) : selector;
            if (element?.isConnected != true) {
                return;
            }
            htmx.trigger(element, event);
        }
        catch { }
    }
}
//# sourceMappingURL=Htmx.js.map