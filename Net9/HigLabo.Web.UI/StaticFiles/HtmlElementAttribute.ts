import { $ } from "./HtmlElementQuery.js";

export class HtmlElementAttribute {
    public initialize() {
        $("body").on("click", "[set-checkbox-on]", this.setCheckboxOn_Click.bind(this));
        $("body").on("change", "input[type='check'][bind-checkbox]", this.bindCheckbox_Change.bind(this));
        $("body").on("click", "[set-attribute]", this.setAttribute_Click.bind(this));
        $("body").on("click", "[toggle-attribute]", this.toggleAttribute_Click.bind(this));
        $("body").on("change", "[bind-attribute]", this.bindAttribute_Click.bind(this));
    }
    private setCheckboxOn_Click(target: Element, e: MouseEvent) {
        const selector = $(target).getAttribute("target-selector");
        const checked = true;
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector).getElementList();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else {
            const pl = $(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
    }
    private bindCheckbox_Change(target: Element, e: Event) {
        const selector = $(target).getAttribute("target-selector");
        const checked = $(target).isChecked();
        const targetMethod = $(target).getAttribute("target-selector-method");
        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector).getElementList();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
        else {
            const pl = $(selector).getFirstElement();
            $(pl).find("input[type='checkbox']").setChecked(checked);
        }
    }
    private setAttribute_Click(target: Element, e: Event) {
        const aName = $(target).getAttribute("set-attribute");
        const v = $(target).getAttribute("set-attribute-value");
        const targetMethod = $(target).getAttribute("target-selector-method");
        const selector = $(target).getAttribute("target-selector");

        if (targetMethod == "parent") {
            const pl = $(target).getFirstParent(selector).getFirstElement();
            $(pl).setAttribute(aName, v);
        }
        else if (targetMethod == "nearest") {
            const pl = $(target).getNearest(selector).getFirstElement();
            $(pl).setAttribute(aName, v);
        }
        else if (targetMethod == "find") {
            const pl = $(target).find(selector).getFirstElement();
            $(pl).setAttribute(aName, v);
        }
        else {
            const pl = $(selector).getFirstElement();
            $(pl).setAttribute(aName, v);
        }
    }
    private toggleAttribute_Click(target: Element, e: Event) {
        const aName = $(target).getAttribute("toggle-attribute");
        const ss = $(target).getAttribute("toggle-attribute-value").split(",");
        if (ss.length < 2) { return; }
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
    private bindAttribute_Click(target: Element, e: Event) {
        const aName = $(target).getAttribute("bind-attribute");
        let aValue = "";
        if (target.tagName == "INPUT" || target.tagName == "TEXTAREA") {
            if ($(target).getAttribute("type") == "checkbox") {
                aValue = $(target).isChecked().toString();
            }
            else {
                aValue = $(target).getValue();
            }
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


}