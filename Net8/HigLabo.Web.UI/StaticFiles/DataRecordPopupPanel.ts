import { $ } from "./HtmlElementQuery.js";
import { Htmx } from "./Htmx.js";

export class DataRecordPopupPanel {
    private dataRecordPopupPanel = document.getElementById("data-record-popup-panel");
    private currentPanel: Element;
    private targetPanel: Element;
    private htmx = new Htmx();

    public selected = new Array<DataRecordSelectedEvent>();

    public initialize() {
        $("body").on("click", "[show-data-record-popup-panel]", this.panel_Click.bind(this));
        $("body").on("keydown", "[show-data-record-popup-panel]", this.panel_Keydown.bind(this));

        $("body").on("click", "[selection-mode='Template'] [add-template]", this.addTemplate_Click.bind(this));

        $("body").on("click", "#data-record-popup-panel [search-button]", this.searchButton_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [search-textbox]", this.searchTextbox_Keydown.bind(this));

        $("body").on("click", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Keydown.bind(this));
        $("body").on("click", "[data-record-panel] [delete-record]", this.dataRecordIcon_Click.bind(this));
        $("body").on("keydown", "[data-record-panel] [delete-record]", this.dataRecordIcon_Keydown.bind(this));

        $("body").on("click", "#data-record-popup-panel [close-button]", this.closeButton_Click.bind(this));
        $("body").on("click", "[close-data-record-popup-panel]", this.closeButton_Click.bind(this));


        document.body.addEventListener('htmx:configRequest', (e: any) => {
            if (e.target == this.dataRecordPopupPanel) {
                //最初にHTMLに出力した時のhx-postが使用される。
                //data-record-popup-panelのhx-postの値は空文字。動的に変更された値が反映されない。
                //JavaScriptでhx-postの属性値を書き換えても反映されないのでここでセット。
                e.detail.path = this.dataRecordPopupPanel.getAttribute("hx-post");
            }
        });
        document.body.addEventListener('htmx:afterSwap', (e: any) => {
            if (e.target == $(this.dataRecordPopupPanel).find("[record-list-panel]").getFirstElement()) {
                this.setPanelPosition(this.currentPanel.getBoundingClientRect());
            }
        });
        $("body").click(this.body_Click.bind(this));

    }
    public AddSelectedEventHandler(handler: DataRecordSelectedEvent) {
        this.selected.push(handler);
    }
    private OnSelected(e: DataRecordSelectedEventArgs) {
        for (var i = 0; i < this.selected.length; i++) {
            try {
                this.selected[i](e);
            }
            catch { }
        }
    }

    private panel_Click(element: Element, e: Event) {
        //if ($(e.target).getAttribute("add-panel") != "true") { return; }
        if ($(e.target).hasAttribute("href") == true) { return; }
        if ($(e.target).hasAttribute("delete-record") == true) { return; }

        if (element.getAttribute("prevent-default") == "true") {
            e.preventDefault();
        }
        this.show(element);
        e.stopPropagation();
    }
    private panel_Keydown(element: Element, e: KeyboardEvent) {
        if (e.key == "Enter") {
            if (element.getAttribute("prevent-default") == "true") {
                e.preventDefault();
            }
            this.show(element);
        }
    }
    private show(element: Element) {
        if ($(element).getAttribute("target-panel-type") == "input-record-list-panel") {
            this.currentPanel = $(element.parentElement).getFirstElement();
            this.targetPanel = $(this.currentPanel).find("[record-list-panel]").getFirstElement();
        }
        else {
            this.currentPanel = $(element).getFirstElement();
            this.targetPanel = this.currentPanel;
        }

        $(this.dataRecordPopupPanel).setAttribute("selection-mode", $(this.currentPanel).getAttribute("selection-mode"));
        $(this.dataRecordPopupPanel).setAttribute("hx-post", $(this.currentPanel).getAttribute("hx-post"));
        $(this.dataRecordPopupPanel).find("[search-textbox]").setValue("");

        if ($(this.dataRecordPopupPanel).getAttribute("search-default-list") == "true") {
            const loadingTemplateId = $(this.currentPanel).getAttribute("loading-template-id");
            if (loadingTemplateId == "") {
                $(this.dataRecordPopupPanel).find("[record-list-panel]").setInnerHtml($("#loading-panel-template").getInnerHtml());
            }
            else {
                $(this.dataRecordPopupPanel).find("[record-list-panel]").setInnerHtml($(loadingTemplateId).getInnerHtml());
            }
        }
        else {
            $(this.dataRecordPopupPanel).find("[record-list-panel]").setInnerHtml("");
        }
        if ($(element).hasAttribute("template-id")) {
            const html = $("#" + $(element).getAttribute("template-id")).getInnerHtml();
            $(this.dataRecordPopupPanel).find("[record-list-panel]").setInnerHtml(html);
            this.htmx.process(this.dataRecordPopupPanel);
        }

        const allowSearch = $(this.currentPanel).getAttribute("allow-search") == "true";
        if (allowSearch) {
            $(this.dataRecordPopupPanel).find("[search-panel]").removeClass("display-none");
        }
        else {
            $(this.dataRecordPopupPanel).find("[search-panel]").addClass("display-none");
        }
        if ($(this.currentPanel).getAttribute("footer-visible") == "false") {
            $(this.dataRecordPopupPanel).find("[footer-panel]").addClass("display-none");
        }

        const rect = this.currentPanel.getBoundingClientRect();

        $(this.dataRecordPopupPanel).setAttribute("processing", "true");
        $(this.dataRecordPopupPanel).removeClass("display-none");

        if ($(this.currentPanel).hasAttribute("panel-width")) {
            $(this.dataRecordPopupPanel).setStyle("width", $(this.currentPanel).getAttribute("panel-width"));
        }
        else {
            $(this.dataRecordPopupPanel).setStyle("width", rect.width + "px");
        }
        this.setPanelPosition(rect);

        setTimeout(function () {
            $(this.dataRecordPopupPanel).removeAttribute("processing");
            const tx = $(this.dataRecordPopupPanel).find("[search-textbox]").getFirstElement();
            if (allowSearch == true || tx != null) {
                $(tx).setFocus();
            }
            else {
                $(this.dataRecordPopupPanel).find("[tabindex]").setFocus();
            }
            this.setPanelPosition(this.currentPanel.getBoundingClientRect());
        }.bind(this), 100);

        if ($(this.dataRecordPopupPanel).getAttribute("search-default-list") == "true") {
            this.htmx.trigger("#data-record-popup-panel", "search");
        }
    }
    private setPanelPosition(rect: DOMRect) {
        const scrollBarAdjustWidth = 20;
        if (this.dataRecordPopupPanel.getAttribute("selection-mode") == "Multiple" ||
            rect.x + $(this.dataRecordPopupPanel).getOuterWidth() > window.innerWidth) {
            if ($(this.dataRecordPopupPanel).getOuterWidth() > window.innerWidth) {
                $(this.dataRecordPopupPanel).setStyle("left", "0px");
            }
            else {
                $(this.dataRecordPopupPanel).setStyle("left", (window.innerWidth - $(this.dataRecordPopupPanel).getInnerWidth() - scrollBarAdjustWidth) + "px");
            }
        }
        else {
            $(this.dataRecordPopupPanel).setStyle("left", rect.x + "px");
        }

        if ((rect.y + rect.height) + $(this.dataRecordPopupPanel).getOuterHeight() > window.innerHeight) {
            if ($(this.dataRecordPopupPanel).getOuterHeight() > window.innerHeight) {
                $(this.dataRecordPopupPanel).setStyle("top", "0px");
            }
            else {
                $(this.dataRecordPopupPanel).setStyle("top", (window.innerHeight - $(this.dataRecordPopupPanel).getOuterHeight()) + "px");
            }
        }
        else {
            if (this.dataRecordPopupPanel.getAttribute("selection-mode") == "Multiple") {
                if (rect.y < 0) {
                    $(this.dataRecordPopupPanel).setStyle("top", "0px");
                }
                else {
                    $(this.dataRecordPopupPanel).setStyle("top", rect.y + "px");

                }
            }
            else {
                $(this.dataRecordPopupPanel).setStyle("top", (rect.y + rect.height) + "px");
            }
        }
    }

    private addTemplate_Click(target: Element, e: Event) {
        const rpl = $(target).getFirstParent("[selection-mode='Template']").find("[record-list-panel]").getFirstElement();
        const templateId = "#" + $(target).getAttribute("template-id");
        const html = $(templateId).getInnerHtml();
        const div = document.createElement("div");
        div.innerHTML = html;
        rpl.insertAdjacentElement("beforeend", div.children[0]);
    }

    private searchButton_Click(element: Element, e: Event) {
        this.htmx.trigger("#data-record-popup-panel", "search");
    }
    private searchTextbox_Keydown(element: Element, e: KeyboardEvent) {
        if (e.key == "Enter") {
            this.htmx.trigger("#data-record-popup-panel", "search");
        }
        if (e.key == "Escape") {
            this.hide();
        }
        if (e.key == "ArrowDown") {
            const pl = $(this.dataRecordPopupPanel).find("[record-list-panel] [data-record-panel]").getFirstElement();
            if (pl != null) {
                $(pl).setFocus();
                $(this.dataRecordPopupPanel).find("[record-list-panel]").setScrollTop(0);
                e.preventDefault();
            }
        }
    }

    private dataRecordPanel_Click(element: Element, e: Event) {
        if ($(e.target).hasAttribute("href") == true) { return; }
        if ($(e.target).hasAttribute("delete-record") == true) { return; }

        let pl = $(e.target).getFirstElement();
        if ($(pl).hasAttribute("data-record-panel") == false) {
            pl = $(pl).getParent("[data-record-panel]").getFirstElement();
        }
        this.recordSelected(pl);
    }
    private dataRecordPanel_Keydown(element: Element, e: KeyboardEvent) {
        const recordListPanel = $(e.target).getFirstParent("[record-list-panel]").getFirstElement();

        if (e.key == "Escape") {
            $(this.dataRecordPopupPanel).find("[search-textbox]").setFocus();
        }
        else if (e.key == "Enter") {
            this.recordSelected(element);
        }
        else if (e.key == "ArrowUp") {
            const pl = $(element).getSibling("Previous").getLastElement();
            if (pl == null) {
                $($(recordListPanel).find("[data-record-panel]").getLastElement()).setFocus();
            }
            else {
                $(pl).setFocus();
            }
        }
        else if (e.key == "ArrowDown") {
            const pl = $(element).getSibling("Next").getFirstElement();
            if (pl == null) {
                $(recordListPanel).find("[data-record-panel]").setFocus();
            }
            else {
                $(pl).setFocus();
            }
        }
    }
    private recordSelected(panel: Element) {
        const pl = panel;
        const e = new DataRecordSelectedEventArgs();
        e.panel = panel;
        e.currentPanel = this.currentPanel;
        e.targetPanel = this.targetPanel;

        if ($(this.dataRecordPopupPanel).getAttribute("selection-mode") == "Single") {
            if (this.targetPanel != null) {
                $(this.targetPanel).setInnerHtml("");
                $(this.targetPanel).setInnerHtml($(pl).getOuterHtml());
                $(this.targetPanel).setFocus();
            }
            $(this.dataRecordPopupPanel).addClass("display-none");
            this.targetPanel = null;
        }
        if ($(this.dataRecordPopupPanel).getAttribute("selection-mode") == "Multiple") {
            $(this.targetPanel).appendInnerHtml($(pl).getOuterHtml());
            $(this.targetPanel).setScrollTop(100000);

            const recordListPanel = $(pl).getFirstParent("[record-list-panel]").getFirstElement();

            const plNext = $(pl).getSibling("Next").getFirstElement();
            if (plNext == null) {
                $(recordListPanel).find("[data-record-panel]").setFocus();
            }
            else {
                $(plNext).setFocus();
            }

            $(pl).remove();
            if ($(recordListPanel).find("[data-record-panel]").getElementCount() == 0) {
                $(this.dataRecordPopupPanel).find("[search-textbox]").setFocus();
            }
        }
        this.OnSelected(e);
    }

    private dataRecordIcon_Click(element: Element, e: Event) {
        $(element).getFirstParent("[data-record-panel]").remove();
    }
    private dataRecordIcon_Keydown(element: Element, e: KeyboardEvent) {
        if (e.key == "Enter") {
            $(element).getFirstParent("[data-record-panel]").remove();
        }
    }

    public closeButton_Click(element: Element, e: Event) {
        this.hide();
    }
    private hide() {
        $(this.targetPanel).setFocus();
        $(this.dataRecordPopupPanel).addClass("display-none");
        this.targetPanel = null;
    }

    private body_Click(e: MouseEvent) {
        if (e.detail == 0) { return; }

        if ($(this.dataRecordPopupPanel).hasClass("display-none") == false && 
            $(this.dataRecordPopupPanel).hasAttribute("processing") == false) {
            const rect = this.dataRecordPopupPanel.getBoundingClientRect();
            if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                $(this.dataRecordPopupPanel).addClass("display-none");
                this.targetPanel = null;
            }
        }
    }
}
export class DataRecordSelectedEventArgs {
    public panel: Element;
    public currentPanel: Element;
    public targetPanel: Element;
}
export type DataRecordSelectedEvent = (e: DataRecordSelectedEventArgs) => void;
