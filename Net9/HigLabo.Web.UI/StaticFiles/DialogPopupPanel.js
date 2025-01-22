import { $ } from "./HtmlElementQuery.js";
export class DialogPopupPanel {
    currentElement;
    dialog = document.getElementById("dialog-popup-panel");
    initialize() {
        document.addEventListener("htmx:confirm", this.confirm.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-yes]", this.confirmYesButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-no]", this.confirmNoButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel", this.panel_Click.bind(this));
    }
    showModal(element) {
        this.currentElement = element;
        const text = element.getAttribute("hx-confirm");
        $(this.dialog).find("[text]").setInnerText(text);
        this.dialog.showModal();
    }
    confirm(e) {
        e.preventDefault();
        e.stopPropagation();
        const bt = e.target;
        if (bt.hasAttribute("hx-confirm") == false) {
            e.detail.issueRequest(true);
            return;
        }
        if (e.detail.triggeringEvent.type == "execute") {
            e.detail.issueRequest(true);
        }
        else {
            this.showModal(bt);
        }
    }
    confirmYesButton_Click(target, e) {
        const htmx = window["htmx"];
        if (htmx != null && this.currentElement != null) {
            htmx.trigger(this.currentElement, "execute");
        }
        const dialog = document.getElementById("dialog-popup-panel");
        dialog.close();
    }
    confirmNoButton_Click(target, e) {
        const dialog = document.getElementById("dialog-popup-panel");
        dialog.close();
    }
    panel_Click(target, e) {
        const rect = this.dialog.getBoundingClientRect();
        if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
            this.dialog.close();
        }
    }
}
//# sourceMappingURL=DialogPopupPanel.js.map