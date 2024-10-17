import { $ } from "./HtmlElementQuery.js";

export class FullWindowPopupPanel {
    public dialog = document.getElementById("full-window-popup-panel") as HTMLDialogElement;

    public initialize() {
        $(document).on("click", "[show-full-window-popup-panel]", this.showFullWindowPopupPanel_Click.bind(this));
        $("body").on("click", "#full-window-popup-panel [close]", this.closeButton_Click.bind(this));
        $("body").on("click", "#full-window-popup-panel", this.panel_Click.bind(this));
    }
    private showFullWindowPopupPanel_Click(target: Element, e: Event) {
        this.showModal();
    }
    public showModal() {
        const pl = document.getElementById("loading-panel-template");
        $("#full-window-popup-panel-content-panel").setInnerHtml(pl.innerHTML);
        this.dialog.showModal();
    }
    private panel_Click(target: Element, e: MouseEvent) {
        const rect = this.dialog.getBoundingClientRect();
        if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
            this.dialog.close();
        }
    }
    private closeButton_Click(target: Element, e: Event) {
        this.dialog.close();
    }
}