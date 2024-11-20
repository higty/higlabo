export class Htmx {
    htmx = window["htmx"];
    process(element) {
        this.htmx.process(element);
    }
    trigger(selector, event) {
        this.htmx.trigger(selector, event);
    }
}
//# sourceMappingURL=Htmx.js.map