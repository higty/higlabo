import { $ } from "./HtmlElementQuery.js";
export class ItemGroup {
    initialize() {
        $("body").on("click", "[item-group][item-group-id]", this.item_Click.bind(this));
    }
    item_Click(target, e) {
        this.setCurrentItem(target);
    }
    setCurrentItem(target) {
        const itemId = $(target).getAttribute("item-group-id");
        const itemGroupName = $(target).getAttribute("item-group");
        $("[item-group='" + itemGroupName + "'][item-group-id]").removeAttribute("current");
        $("[item-group='" + itemGroupName + "'][item-group-id='" + itemId + "']").setAttribute("current", "true");
    }
}
//# sourceMappingURL=ItemGroup.js.map