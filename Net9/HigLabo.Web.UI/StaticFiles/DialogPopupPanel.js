import { $ } from "./HtmlElementQuery.js";
export class DialogPopupPanel {
    issueRequest = null;
    dropRequest = null;
    dialog = document.getElementById("dialog-popup-panel");
    initialize() {
        document.addEventListener("htmx:confirm", this.confirm.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-yes]", this.confirmYesButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-no]", this.confirmNoButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel", this.panel_Click.bind(this));
        this.dialog?.addEventListener("cancel", e => this.confirmNoButton_Click(this.dialog, e));
        this.dialog?.addEventListener("close", () => {
            if (this.dialog.open == false) {
                this.dropRequest?.();
                this.issueRequest = null;
                this.dropRequest = null;
            }
        });
    }
    showModal(element, text = element.getAttribute("hx-confirm")) {
        $(this.dialog).findDescendants("[text]").setInnerText(text);
        if ($(element).getAttribute("confirm-yes-text") != "") {
            $(this.dialog).findDescendants("[confirm-yes]").setInnerText($(element).getAttribute("confirm-yes-text"));
        }
        if ($(element).getAttribute("confirm-no-text") != "") {
            $(this.dialog).findDescendants("[confirm-no]").setInnerText($(element).getAttribute("confirm-no-text"));
        }
        this.dialog.showModal();
    }
    confirm(e) {
        if (this.dialog == null) {
            return;
        }
        e.preventDefault();
        const ctx = e.detail.ctx;
        const bt = ctx.sourceElement;
        if (bt.getAttribute("stop-propagation") == "true") {
            const tev = ctx.sourceEvent;
            if (tev?.stopImmediatePropagation)
                tev.stopImmediatePropagation();
            if (tev?.stopPropagation)
                tev.stopPropagation();
        }
        if (ctx.sourceEvent?.type == "execute") {
            e.detail.issueRequest();
            return;
        }
        if (this.dialog.open) {
            e.detail.dropRequest();
            return;
        }
        this.issueRequest = e.detail.issueRequest;
        this.dropRequest = e.detail.dropRequest;
        this.showModal(bt, ctx.confirm);
    }
    confirmYesButton_Click(target, e) {
        const issueRequest = this.issueRequest;
        this.issueRequest = null;
        this.dropRequest = null;
        this.dialog.close();
        issueRequest?.();
    }
    confirmNoButton_Click(target, e) {
        const dropRequest = this.dropRequest;
        this.issueRequest = null;
        this.dropRequest = null;
        this.dialog.close();
        dropRequest?.();
    }
    panel_Click(target, e) {
        const rect = this.dialog.getBoundingClientRect();
        if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
            this.confirmNoButton_Click(target, e);
        }
    }
}
//# sourceMappingURL=DialogPopupPanel.js.map