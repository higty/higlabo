import { $ } from "./HtmlElementQuery.js";
export class HtmlElementQueryTrigger {
    initialize() {
        $("body").on("click", "[hig-trigger='click']", this.hig_Click.bind(this));
        $("body").on("change", "[hig-trigger='change']", this.hig_Click.bind(this));
    }
    hig_Click(target, e) {
        const selectorList = $(target).getAttribute("hig-target");
        const ss = selectorList.split(',');
        for (var i = 0; i < ss.length; i++) {
            let selector = ss[i].trim();
            let q = $(selector);
            if (selector.startsWith("parent ")) {
                q = $(target).getFirstParent(selector);
            }
            else if (selector.startsWith("nearest ")) {
                q = $(target).getNearest(selector);
            }
            else if (selector.startsWith("find ")) {
                q = $(target).find(selector);
            }
            const functionName = $(target).getAttribute("hig-function");
            const f = q[functionName];
            if (f == null) {
                return;
            }
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
//# sourceMappingURL=HtmlElementQueryTrigger.js.map