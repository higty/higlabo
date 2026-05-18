export class Htmx {
    private getHtmx() {
        return window["htmx"];
    }

    public process(selectorOrElement: Element | string) {
        const htmx = this.getHtmx();
        if (htmx == null) { return; }

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

    public trigger(selector, event: string) {
        try {
            const htmx = this.getHtmx();
            if (htmx == null) { return; }
            htmx.trigger(selector, event);
        }
        catch { }
    }
}
