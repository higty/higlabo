import { $ } from "./HtmlElementQuery.js";
export class FullWindowPopupPanel {
    dialog = document.getElementById("full-window-popup-panel");
    initialize() {
        $(document).on("click", "[show-full-window-popup-panel]", this.showFullWindowPopupPanel_Click.bind(this));
        $("body").on("click", "#full-window-popup-panel [close]", this.closeButton_Click.bind(this));
        $("body").on("click", "#full-window-popup-panel", this.panel_Click.bind(this));
    }
    showFullWindowPopupPanel_Click(target, e) {
        this.showModal();
    }
    showModal() {
        const pl = document.getElementById("loading-panel-template");
        if (pl != null) {
            $("#full-window-popup-panel-content-panel").setInnerHtml(pl.innerHTML);
        }
        this.dialog.showModal();
    }
    panel_Click(target, e) {
        const rect = this.dialog.getBoundingClientRect();
        if (e.detail == 0) {
            return;
        }
        if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
            this.close();
        }
    }
    closeButton_Click(target, e) {
        this.close();
    }
    close() {
        $("#full-window-popup-panel-content-panel").setInnerHtml("");
        this.dialog.close();
    }
}
//# sourceMappingURL=FullWindowPopupPanel.js.map