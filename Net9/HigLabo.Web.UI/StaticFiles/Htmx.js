export class Htmx {
    getHtmx() {
        return window["htmx"];
    }
    process(selectorOrElement) {
        const htmx = this.getHtmx();
        if (htmx == null) {
            return;
        }
        if (typeof selectorOrElement === "string") {
            document.querySelectorAll(selectorOrElement).forEach(el => {
                htmx.process(el);
            });
        }
        else if (selectorOrElement instanceof Element) {
            htmx.process(selectorOrElement);
        }
        else {
            htmx.process();
        }
    }
    trigger(selector, event) {
        try {
            const htmx = this.getHtmx();
            if (htmx == null) {
                return;
            }
            htmx.trigger(selector, event);
        }
        catch { }
    }
}
//# sourceMappingURL=Htmx.js.map