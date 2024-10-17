export class Htmx {
    private htmx = window["htmx"];

    public trigger(selector: string, event: string) {
        this.htmx.trigger(selector, event);
    }
}