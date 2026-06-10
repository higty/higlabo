import { $ } from "./HtmlElementQuery.js";
export class AccordionPanel {
    initialize() {
        $("body").on("click", "[accordion-panel] [toggle]", this.toggle_Click.bind(this));
    }
    toggle_Click(target, e) {
        const pl = $(target).getFirstParent("[accordion-panel]").getFirstElement();
        $(pl).toggleAttributeValue("toggle-state", "Visible", "Hidden");
    }
}
//# sourceMappingURL=AccordionPanel.js.map