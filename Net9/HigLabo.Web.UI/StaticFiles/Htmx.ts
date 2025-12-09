export class Htmx {
    private htmx = window["htmx"];

    public process(selectorOrElement: Element | string) {
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

    public trigger(selector, event: string) {
        this.htmx.trigger(selector, event);
    }
}