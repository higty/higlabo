import { $ } from "./HtmlElementQuery.js";

export class AccordionPanel {
    public initialize() {
        $("body").on("click", "[accordion-panel] [toggle]", this.toggle_Click.bind(this));
    }
    private toggle_Click(target: Element, e: Event) {
        const pl = $(target).getFirstParent("[accordion-panel]").getFirstElement();
        $(pl).toggleAttributeValue("toggle-state", "Visible", "Hidden");
    }
}