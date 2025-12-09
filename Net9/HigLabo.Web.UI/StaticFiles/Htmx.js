export class Htmx {
    htmx = window["htmx"];
    process(selectorOrElement) {
        if (typeof selectorOrElement === "string") {
            document.querySelectorAll(selectorOrElement).forEach(el => {
                this.htmx.process(el);
            });
        }
        else if (selectorOrElement instanceof Element) {
            this.htmx.process(selectorOrElement);
        }
        else {
            this.htmx.process();
        }
    }
    trigger(selector, event) {
        this.htmx.trigger(selector, event);
    }
}
//# sourceMappingURL=Htmx.js.map