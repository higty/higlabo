import { $ } from "./HtmlElementQuery.js";
export class PopuPanel {
    initialize() {
        $(document).on("click", "body", this.body_Click.bind(this));
    }
    body_Click(target, e) {
        this.hidePopupPanel(e);
    }
    hidePopupPanel(e) {
        if ($(e.target).getParent("dialog").getElementCount() > 0) {
            return;
        }
        if (e.detail == 0) {
            return;
        }
        if (document.activeElement.tagName == "INPUT") {
            return;
        }
        if (document.activeElement.tagName == "TEXTAREA") {
            return;
        }
        if ($(e.target).getAttribute("prevent-hide") == "true") {
            return;
        }
        const pp = $("[popup-panel]").getElementList();
        pp.forEach(popupPanel => {
            if ($(popupPanel).getAttribute("prevent-hide") == "true") {
                return;
            }
            if ($(popupPanel).hasClass("display-none") == false &&
                $(popupPanel).hasAttribute("processing") == false) {
                const rect = popupPanel.getBoundingClientRect();
                if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                    $(popupPanel).addClass("display-none");
                }
            }
        });
    }
}
//# sourceMappingURL=Popup.js.map