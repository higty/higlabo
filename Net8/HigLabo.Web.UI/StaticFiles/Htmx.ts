export class Htmx {
    private htmx = window["htmx"];

    public process(element: Element) {
        this.htmx.process(element);
    }

    public trigger(selector, event: string) {
        this.htmx.trigger(selector, event);
    }
}