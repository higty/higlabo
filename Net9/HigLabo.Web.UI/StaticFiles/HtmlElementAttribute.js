import { $ } from "./HtmlElementQuery.js";
export class HtmlElementAttribute {
    initialize() {
        $("body").on("click", "[set-attribute]", this.setAttribute_Click.bind(this));
        $("body").on("click", "[toggle-attribute]", this.toggle_Click.bind(this));
    }
    setAttribute_Click(target, e) {
        const aName = $(target).getAttribute("set-attribute");
        const aValue = $(target).getAttribute("set-attribute-value");
        const selector = $(target).getAttribute("target-selector");
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector).getFirstElement();
            $(pl).setAttribute(aName, aValue);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector).getFirstElement();
            $(pl).setAttribute(aName, aValue);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector).getFirstElement();
            $(pl).setAttribute(aName, aValue);
        }
        else {
            const pl = $(selector).getFirstElement();
            $(pl).setAttribute(aName, aValue);
        }
    }
    toggle_Click(target, e) {
        const aName = $(target).getAttribute("toggle-attribute");
        const ss = $(target).getAttribute("toggle-attribute-value").split(",");
        if (ss.length < 2) {
            return;
        }
        const selector = $(target).getAttribute("target-selector");
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector).getFirstElement();
            $(pl).toggleAttributeValue(aName, ss[0], ss[1]);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector).getFirstElement();
            $(pl).toggleAttributeValue(aName, ss[0], ss[1]);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector).getFirstElement();
            $(pl).toggleAttributeValue(aName, ss[0], ss[1]);
        }
        else {
            const pl = $(selector).getFirstElement();
            $(pl).toggleAttributeValue(aName, ss[0], ss[1]);
        }
    }
}
//# sourceMappingURL=HtmlElementAttribute.js.map