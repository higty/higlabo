import { $ } from "./HtmlElementQuery.js";
export class HtmlElementAttribute {
    initialize() {
        $("body").on("click", "[set-checkbox-on]", this.setCheckboxOn_Click.bind(this));
        $("body").on("change", "input[type='check'][bind-checkbox]", this.bindCheckbox_Change.bind(this));
        $("body").on("change", "[bind-attribute]", this.bindAttribute_Click.bind(this));
        $("body").on("click", "[toggle-attribute]", this.toggle_Click.bind(this));
    }
    setCheckboxOn_Click(target, e) {
        const selector = $(target).getAttribute("target-selector");
        const checked = true;
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else {
            const pl = $(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
    }
    bindCheckbox_Change(target, e) {
        const selector = $(target).getAttribute("target-selector");
        const checked = $(target).isChecked();
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else {
            const pl = $(selector);
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
    }
    bindAttribute_Click(target, e) {
        const aName = $(target).getAttribute("bind-attribute");
        let aValue = "";
        if (target.tagName == "INPUT" || target.tagName == "TEXTAREA") {
            aValue = $(target).getValue();
        }
        else if (target.tagName == "SELECT") {
            aValue = $(target).getSelectedValue();
        }
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
        const targetMethod = $(target).getAttribute("target-selector-method");
        const selector = $(target).getAttribute("target-selector");
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