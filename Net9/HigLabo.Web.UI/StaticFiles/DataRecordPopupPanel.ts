import { $ } from "./HtmlElementQuery.js";
import { Htmx } from "./Htmx.js";

export class DataRecordPopupPanel {
    private currentPanel: Element;
    private targetPanel: Element;
    private htmx = new Htmx();

    public selected = new Array<DataRecordSelectedEvent>();

    public initialize() {
        $("body").on("click", "[show-data-record-popup-panel]", this.panel_Click.bind(this));
        $("body").on("keydown", "[show-data-record-popup-panel]", this.panel_Keydown.bind(this));

        $("body").on("click", "[selection-mode='Template'] > [add-template]", this.addTemplate_Click.bind(this));
        $("body").on("keydown", "[selection-mode='Template'] > [add-template]", this.addTemplate_Keydown.bind(this));

        $("body").on("click", "#data-record-popup-panel [search-button]", this.searchButton_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [search-textbox]", this.searchTextbox_Keydown.bind(this));

        $("body").on("click", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Keydown.bind(this));
        $("body").on("click", "[data-record-panel] [delete-record]", this.dataRecordIcon_Click.bind(this));
        $("body").on("keydown", "[data-record-panel] [delete-record]", this.dataRecordIcon_Keydown.bind(this));

        $("body").on("click", "#data-record-popup-panel [close-button]", this.closeButton_Click.bind(this));
        $("body").on("click", "[close-data-record-popup-panel]", this.closeButton_Click.bind(this));

        document.body.addEventListener('htmx:afterSwap', (e: any) => {
            if (e.target == $(this.getDataRecordPopupPanel()).find("[record-list-panel]").getFirstElement()) {
                this.setPanelPosition(this.currentPanel.getBoundingClientRect());
            }
        });
        $("body").click(this.body_Click.bind(this));

    }
    private getDataRecordPopupPanel() {
        return document.getElementById("data-record-popup-panel");
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
        if ($(window).getInnerWidth() < 600) {
            this.show(element, false);
        }
        else {
            this.show(element, true);
        }
        e.stopPropagation();
    }
    private panel_Keydown(element: Element, e: KeyboardEvent) {
        if (e.key == "Enter") {
            if (element.getAttribute("prevent-default") == "true") {
                e.preventDefault();
            }
            this.show(element, true);
        }
    }
    private show(element: Element, isSetFocusToTextbox: boolean) {
        const dpl = this.getDataRecordPopupPanel();
        if ($(element).getAttribute("target-panel-type") == "input-record-list-panel") {
            this.currentPanel = $(element.parentElement).getFirstElement();
            this.targetPanel = $(this.currentPanel).find("[record-list-panel]").getFirstElement();
        }
        else {
            this.currentPanel = $(element).getFirstElement();
            this.targetPanel = this.currentPanel;
        }
        if ($(element).hasAttribute("hx-include")) {
            $(dpl).setAttribute("hx-include", "#data-record-popup-panel [parameter-panel]," + $(element).getAttribute("hx-include"));
        }
        else {
            $(dpl).setAttribute("hx-include", "#data-record-popup-panel [parameter-panel]");
        }
        $(dpl).setAttribute("selection-mode", $(this.currentPanel).getAttribute("selection-mode"));
        $(dpl).setAttribute("hx-post", $(this.currentPanel).getAttribute("hx-post"));
        this.htmx.process(dpl);
        $(dpl).find("[search-textbox]").setValue("");

        if ($(dpl).getAttribute("search-default-list") == "true") {
            const loadingTemplateId = $(this.currentPanel).getAttribute("loading-template-id");
            if (loadingTemplateId == "") {
                $(dpl).find("[record-list-panel]").setInnerHtml($("#loading-panel-template").getInnerHtml());
            }
            else {
                $(dpl).find("[record-list-panel]").setInnerHtml($(loadingTemplateId).getInnerHtml());
            }
        }
        else {
            $(dpl).find("[record-list-panel]").setInnerHtml("");
        }
        if ($(element).hasAttribute("template-id")) {
            const html = $("#" + $(element).getAttribute("template-id")).getInnerHtml();
            $(dpl).find("[record-list-panel]").setInnerHtml(html);
            this.htmx.process(dpl);
        }

        const allowSearch = $(this.currentPanel).getAttribute("allow-search") == "true";
        if (allowSearch) {
            $(dpl).find("[search-panel]").removeClass("display-none");
        }
        else {
            $(dpl).find("[search-panel]").addClass("display-none");
        }
        if ($(this.currentPanel).getAttribute("footer-visible") == "false") {
            $(dpl).find("[footer-panel]").addClass("display-none");
        }

        const rect = this.currentPanel.getBoundingClientRect();

        $(dpl).setAttribute("processing", "true");
        $(dpl).removeClass("display-none");

        if ($(this.currentPanel).hasAttribute("panel-width")) {
            $(dpl).setStyle("width", $(this.currentPanel).getAttribute("panel-width"));
        }
        else {
            $(dpl).setStyle("width", rect.width + "px");
        }
        this.setPanelPosition(rect);

        setTimeout(function () {
            $(dpl).removeAttribute("processing");
            const tx = $(dpl).find("[search-textbox]").getFirstElement();
            if (isSetFocusToTextbox == true) {
                if (allowSearch == true || tx != null) {
                    $(tx).setFocus();
                }
            }
            else {
                $(dpl).find("[tabindex]").setFocus();
            }
            this.setPanelPosition(this.currentPanel.getBoundingClientRect());
        }.bind(this), 100);

        if ($(dpl).getAttribute("search-default-list") == "true") {
            this.htmx.trigger("#data-record-popup-panel", "search");
        }
    }
    private setPanelPosition(rect: DOMRect) {
        const dpl = this.getDataRecordPopupPanel();
        const scrollBarAdjustWidth = 20;
        if (dpl.getAttribute("selection-mode") == "Multiple" ||
            rect.x + $(dpl).getOuterWidth() > window.innerWidth) {
            if ($(dpl).getOuterWidth() > window.innerWidth) {
                $(dpl).setStyle("left", "0px");
            }
            else {
                $(dpl).setStyle("left", (window.innerWidth - $(dpl).getInnerWidth() - scrollBarAdjustWidth) + "px");
            }
        }
        else {
            $(dpl).setStyle("left", rect.x + "px");
        }

        if ((rect.y + rect.height) + $(dpl).getOuterHeight() > window.innerHeight) {
            if ($(dpl).getOuterHeight() > window.innerHeight) {
                $(dpl).setStyle("top", "0px");
            }
            else {
                $(dpl).setStyle("top", (window.innerHeight - $(dpl).getOuterHeight()) + "px");
            }
        }
        else {
            if (dpl.getAttribute("selection-mode") == "Multiple") {
                if (rect.y < 0) {
                    $(dpl).setStyle("top", "0px");
                }
                else {
                    $(dpl).setStyle("top", rect.y + "px");

                }
            }
            else {
                $(dpl).setStyle("top", (rect.y + rect.height) + "px");
            }
        }
    }

    private addTemplate_Click(target: Element, e: Event) {
        const rpl = $(target).getFirstParent("[selection-mode='Template']").find("[record-list-panel]").getFirstElement();
        const templateId = "#" + $(target).getAttribute("template-id");
        this.addTemplate(rpl, templateId);
    }
    private addTemplate_Keydown(target: Element, e: KeyboardEvent) {
        if (e.key == "Enter") {
            const rpl = $(target).getFirstParent("[selection-mode='Template']").find("[record-list-panel]").getFirstElement();
            const templateId = "#" + $(target).getAttribute("template-id");
            this.addTemplate(rpl, templateId);
        }
    }
    private addTemplate(recordListPanel: Element, templateId: string) {
        const rpl = recordListPanel;
        const html = $(templateId).getInnerHtml();
        const templatePanel = document.createElement("div");
        templatePanel.innerHTML = html;
        rpl.insertAdjacentElement("beforeend", templatePanel.children[0]);
        const div = rpl.children[rpl.children.length - 1];
        div.scrollIntoView();
        $(div).find("input[type='text']").setFocus();
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
            const pl = $(this.getDataRecordPopupPanel()).find("[record-list-panel] [data-record-panel]").getFirstElement();
            if (pl != null) {
                $(pl).setFocus();
                $(this.getDataRecordPopupPanel()).find("[record-list-panel]").setScrollTop(0);
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
            $(this.getDataRecordPopupPanel()).find("[search-textbox]").setFocus();
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
        const dpl = this.getDataRecordPopupPanel();
        const pl = panel;
        const e = new DataRecordSelectedEventArgs();
        e.panel = panel;
        e.currentPanel = this.currentPanel;
        e.targetPanel = this.targetPanel;

        if ($(dpl).getAttribute("selection-mode") == "Single") {
            if (this.targetPanel != null) {
                $(this.targetPanel).setInnerHtml("");
                $(this.targetPanel).setInnerHtml($(pl).getOuterHtml());
                $(this.targetPanel).setFocus();
            }
            $(dpl).addClass("display-none");
            this.targetPanel = null;
        }
        if ($(dpl).getAttribute("selection-mode") == "Multiple") {
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
                $(dpl).find("[search-textbox]").setFocus();
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
        $(this.getDataRecordPopupPanel()).addClass("display-none");
        this.targetPanel = null;
    }

    private body_Click(e: MouseEvent) {
        if (e.detail == 0) { return; }
        const dpl = this.getDataRecordPopupPanel();

        if ($(dpl).hasClass("display-none") == false && 
            $(dpl).hasAttribute("processing") == false) {
            const rect = dpl.getBoundingClientRect();
            if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                $(dpl).addClass("display-none");
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
