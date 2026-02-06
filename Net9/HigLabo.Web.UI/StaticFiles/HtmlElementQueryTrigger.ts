import { $ } from "./HtmlElementQuery.js";

export class HtmlElementQueryTrigger {
    public initialize() {
        $("body").on("click", "[hig-trigger='click']", this.hig_Click.bind(this));
        $("body").on("change", "[hig-trigger='change']", this.hig_Click.bind(this));
    }
    private hig_Click(target: Element, e: MouseEvent) {
        const selectorList = $(target).getAttribute("hig-target");
        const ss = selectorList.split(',');

        for (let i = 0; i < ss.length; i++) {
            const raw = ss[i];
            let selector = raw.trim();
            if (selector.length === 0) continue;

            let q: any;

            if (selector.startsWith("parent ")) {
                selector = selector.substring("parent ".length).trim();
                q = $(target).getFirstParent(selector);
            }
            else if (selector.startsWith("nearest ")) {
                selector = selector.substring("nearest ".length).trim();
                q = $(target).getNearest(selector);
            }
            else if (selector.startsWith("find ")) {
                selector = selector.substring("find ".length).trim();
                q = $(target).find(selector);
            }
            else {
                q = $(selector);
            }

            const functionName = $(target).getAttribute("hig-function");
            const f = (q as any)[functionName] as Function;
            if (f == null) return;

            try {
                const a = JSON.parse($(target).getAttribute("hig-args"));
                f.apply(q, Array.isArray(a) ? a : [a]);
            }
            catch {
                f.apply(q, [$(target).getAttribute("hig-args")]);
            }
        }
    }
}