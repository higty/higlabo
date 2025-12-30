import { $ } from "./HtmlElementQuery.js";

export class ItemGroup {
    public initialize() {
        $("body").on("click", "[item-group][item-group-id]", this.item_Click.bind(this));
    }
    private item_Click(target: Element, e: MouseEvent) {
        this.setCurrentItem(target);
    }
    public setCurrentItem(target: Element) {
        const itemId = $(target).getAttribute("item-group-id");
        const itemGroupName = $(target).getAttribute("item-group");

        $("[item-group='" + itemGroupName + "'][item-group-id]").removeAttribute("current");
        $("[item-group='" + itemGroupName + "'][item-group-id='" + itemId + "']").setAttribute("current", "true");
    }
}