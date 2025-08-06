import { $ } from "./HtmlElementQuery.js";

export class DialogPopupPanel {
    private currentElement: Element;
    public dialog = document.getElementById("dialog-popup-panel") as HTMLDialogElement;

    public initialize() {
        document.addEventListener("htmx:confirm", this.confirm.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-yes]", this.confirmYesButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel [confirm-no]", this.confirmNoButton_Click.bind(this));
        $("body").on("click", "#dialog-popup-panel", this.panel_Click.bind(this));
    }
    public showModal(element: HTMLElement) {
        this.currentElement = element;
        const text = element.getAttribute("hx-confirm");
        $(this.dialog).find("[text]").setInnerText(text);
        if ($(element).getAttribute("confirm-yes-text") != "") {
            $(this.dialog).find("[confirm-yes]").setInnerText($(element).getAttribute("confirm-yes-text"));
        }
        if ($(element).getAttribute("confirm-no-text") != "") {
            $(this.dialog).find("[confirm-no]").setInnerText($(element).getAttribute("confirm-no-text"));
        }
        this.dialog.showModal();
    }
    private confirm(e: any) {
        e.preventDefault();
        e.stopPropagation();

        const bt = e.target as HTMLElement;
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
    private confirmYesButton_Click(target: Element, e: Event) {
        const htmx = window["htmx"];
        if (htmx != null && this.currentElement != null) {
            htmx.trigger(this.currentElement, "execute");
        }
        const dialog = document.getElementById("dialog-popup-panel") as HTMLDialogElement;
        dialog.close();
    }
    private confirmNoButton_Click(target: Element, e: Event) {
        const dialog = document.getElementById("dialog-popup-panel") as HTMLDialogElement;
        dialog.close();
    }
    private panel_Click(target: Element, e: MouseEvent) {
        const rect = this.dialog.getBoundingClientRect();
        if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
            this.dialog.close();
        }
    }
}