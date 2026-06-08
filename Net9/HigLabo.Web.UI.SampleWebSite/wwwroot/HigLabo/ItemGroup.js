import { $ } from "./HtmlElementQuery.js";
export class ItemGroup {
    initialize() {
        $("body").on("click", "[item-group][item-group-id]", this.item_Click.bind(this));
        $("body").on("change", "input[item-group]", this.item_ValueChange.bind(this));
        $("body").on("change", "select[item-group]", this.item_Change.bind(this));
    }
    item_Click(target, e) {
        const groupName = $(target).getAttribute("item-group");
        const itemIdList = this.getItemIdList($(target).getAttribute("item-group-id"));
        if (itemIdList.length != 1) {
            return;
        }
        this.changeCurrentItem(groupName, itemIdList[0]);
    }
    item_ValueChange(target, e) {
        const groupName = $(target).getAttribute("item-group");
        if ($(target).getAttribute("type") == "checkbox") {
            this.changeCurrentItem(groupName, $(target).isChecked().toString());
        }
        else {
            this.changeCurrentItem(groupName, $(target).getValue());
        }
    }
    item_Change(target, e) {
        const groupName = $(target).getAttribute("item-group");
        const itemId = $(target).getSelectedValue();
        this.changeCurrentItem(groupName, itemId);
    }
    setCurrentItem(target) {
        const groupName = $(target).getAttribute("item-group");
        if (target.tagName == "INPUT") {
            if ($(target).getAttribute("type") == "checkbox") {
                this.changeCurrentItem(groupName, $(target).isChecked().toString());
            }
            else {
                this.changeCurrentItem(groupName, $(target).getValue());
            }
        }
        else if (target.tagName == "SELECT") {
            this.changeCurrentItem(groupName, $(target).getSelectedValue());
        }
        else {
            this.changeCurrentItem(groupName, $(target).getAttribute("item-group-id"));
        }
    }
    changeCurrentItem(groupName, itemId) {
        const selectedItemIdList = this.getItemIdList(itemId);
        $("[item-group='" + groupName + "'][item-group-id]").forEach(element => {
            $(element).removeAttribute("current");
            const itemGroupIdList = this.getItemIdList($(element).getAttribute("item-group-id"));
            if (itemGroupIdList.some(id => selectedItemIdList.includes(id)) == true) {
                $(element).setAttribute("current", "true");
            }
        });
    }
    getItemIdList(value) {
        return value
            .split(",")
            .map(id => id.trim())
            .filter(id => id.length > 0);
    }
}
//# sourceMappingURL=ItemGroup.js.map