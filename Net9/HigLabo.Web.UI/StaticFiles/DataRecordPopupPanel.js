import { $ } from "./HtmlElementQuery.js";
import { Htmx } from "./Htmx.js";
import { ItemGroup } from "./ItemGroup.js";
export class DataRecordPopupPanel {
    currentPanel = null;
    targetPanel = null;
    positionPanel = null;
    htmx = new Htmx();
    itemGroup = new ItemGroup();
    selected = new Array();
    initialize() {
        $("body").on("click", "[show-data-record-popup-panel]", this.panel_Click.bind(this));
        $("body").on("keydown", "[show-data-record-popup-panel]", this.panel_Keydown.bind(this));
        $("body").on("click", "[selection-mode='Template'][add-type='Template'] > [add-template]", this.addTemplate_Click.bind(this));
        $("body").on("keydown", "[selection-mode='Template'][add-type='Template'] > [add-template]", this.addTemplate_Keydown.bind(this));
        $("body").on("click", "#data-record-popup-panel [search-button]", this.searchButton_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [search-textbox]", this.searchTextbox_Keydown.bind(this));
        $("body").on("click", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Click.bind(this));
        $("body").on("keydown", "#data-record-popup-panel [data-record-panel]", this.dataRecordPanel_Keydown.bind(this));
        $("body").on("click", "[data-record-panel] [delete-record]", this.dataRecordIcon_Click.bind(this));
        $("body").on("keydown", "[data-record-panel] [delete-record]", this.dataRecordIcon_Keydown.bind(this));
        $("body").on("click", "#data-record-popup-panel [close-button]", this.closeButton_Click.bind(this));
        $("body").on("click", "[close-data-record-popup-panel]", this.closeButton_Click.bind(this));
        document.body.addEventListener("htmx:afterSwap", (e) => {
            const dpl = this.getDataRecordPopupPanel();
            if (dpl == null) {
                return;
            }
            if ($(dpl).hasClass("display-none")) {
                return;
            }
            if (this.positionPanel == null) {
                return;
            }
            const recordListPanel = $(dpl).find("[record-list-panel]").getFirstElement();
            if (e.target == recordListPanel) {
                if (this.isVisible(this.positionPanel) == false) {
                    return;
                }
                this.setPanelPosition(this.positionPanel.getBoundingClientRect());
            }
        });
        $("body").click(this.body_Click.bind(this));
        this.AddSelectedEventHandler(this.dataRecordPopupPanel_Selected.bind(this));
    }
    getDataRecordPopupPanel() {
        return document.getElementById("data-record-popup-panel");
    }
    AddSelectedEventHandler(handler) {
        this.selected.push(handler);
    }
    OnSelected(e) {
        for (let i = 0; i < this.selected.length; i++) {
            try {
                this.selected[i](e);
            }
            catch { }
        }
    }
    panel_Click(element, e) {
        if ($(e.target).hasAttribute("href") == true) {
            return;
        }
        if ($(e.target).hasAttribute("delete-record") == true) {
            return;
        }
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
    panel_Keydown(element, e) {
        if (e.key == "Enter") {
            if (element.getAttribute("prevent-default") == "true") {
                e.preventDefault();
            }
            this.show(element, true);
        }
    }
    show(element, isSetFocusToTextbox) {
        const dpl = this.getDataRecordPopupPanel();
        if (dpl == null) {
            return;
        }
        this.positionPanel = this.getPositionPanel(element);
        if ($(element).getAttribute("target-panel-type") == "input-record-list-panel") {
            this.currentPanel = $(element.parentElement).getFirstElement();
            this.targetPanel = $(this.currentPanel).find("[record-list-panel]").getFirstElement();
        }
        else {
            this.currentPanel = $(element).getFirstElement();
            this.targetPanel = this.currentPanel;
        }
        if (this.currentPanel == null || this.targetPanel == null || this.positionPanel == null) {
            return;
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
        else {
            $(dpl).find("[footer-panel]").removeClass("display-none");
        }
        $(dpl).setAttribute("processing", "true");
        $(dpl).removeClass("display-none");
        const positionRect = this.positionPanel.getBoundingClientRect();
        if ($(this.currentPanel).hasAttribute("panel-width")) {
            $(dpl).setStyle("width", $(this.currentPanel).getAttribute("panel-width"));
        }
        else {
            $(dpl).setStyle("width", positionRect.width + "px");
        }
        this.setPanelPosition(positionRect);
        setTimeout(function () {
            if (this.positionPanel == null) {
                return;
            }
            if ($(dpl).hasClass("display-none")) {
                return;
            }
            $(dpl).removeAttribute("processing");
            const tx = $(dpl).find("[search-textbox]").getFirstElement();
            if (isSetFocusToTextbox == true && allowSearch) {
                $(tx).setFocus();
            }
            else {
                $(dpl).find("[tabindex]").setFocus();
            }
            if (this.isVisible(this.positionPanel)) {
                this.setPanelPosition(this.positionPanel.getBoundingClientRect());
            }
        }.bind(this), 100);
        if ($(dpl).getAttribute("search-default-list") == "true") {
            this.htmx.trigger("#data-record-popup-panel", "search");
        }
    }
    getPositionPanel(element) {
        const anchor = $(element).getFirstParent("[popup-position-panel]").getFirstElement();
        if (anchor != null) {
            return anchor;
        }
        return element;
    }
    isVisible(element) {
        if (element == null) {
            return false;
        }
        const style = getComputedStyle(element);
        if (style.display == "none") {
            return false;
        }
        if (style.visibility == "hidden") {
            return false;
        }
        const rect = element.getBoundingClientRect();
        return rect.width > 0 || rect.height > 0;
    }
    setPanelPosition(rect) {
        const dpl = this.getDataRecordPopupPanel();
        if (dpl == null) {
            return;
        }
        const scrollBarAdjustWidth = 20;
        const popupWidth = $(dpl).getOuterWidth();
        const popupHeight = $(dpl).getOuterHeight();
        let left = 0;
        let top = 0;
        if (dpl.getAttribute("selection-mode") == "Multiple" ||
            rect.x + popupWidth > window.innerWidth) {
            if (popupWidth > window.innerWidth) {
                left = 0;
            }
            else {
                left = window.innerWidth - $(dpl).getInnerWidth() - scrollBarAdjustWidth;
            }
        }
        else {
            left = rect.x;
        }
        if ((rect.y + rect.height) + popupHeight > window.innerHeight) {
            if (popupHeight > window.innerHeight) {
                top = 0;
            }
            else {
                top = window.innerHeight - popupHeight;
            }
        }
        else {
            if (dpl.getAttribute("selection-mode") == "Multiple") {
                if (rect.y < 0) {
                    top = 0;
                }
                else {
                    top = rect.y;
                }
            }
            else {
                top = $(window).getScrollTop() + rect.y + rect.height;
            }
        }
        if (left < 0) {
            left = 0;
        }
        if (top < 0) {
            top = 0;
        }
        $(dpl).setStyle("left", left + "px");
        $(dpl).setStyle("top", top + "px");
    }
    addTemplate_Click(target, e) {
        const rpl = $(target).getFirstParent("[selection-mode='Template']").find("[record-list-panel]").getFirstElement();
        const templateId = "#" + $(target).getAttribute("template-id");
        this.addTemplate(rpl, templateId);
    }
    addTemplate_Keydown(target, e) {
        if (e.key == "Enter") {
            const rpl = $(target).getFirstParent("[selection-mode='Template']").find("[record-list-panel]").getFirstElement();
            const templateId = "#" + $(target).getAttribute("template-id");
            this.addTemplate(rpl, templateId);
        }
    }
    addTemplate(recordListPanel, templateId) {
        const rpl = recordListPanel;
        const html = $(templateId).getInnerHtml();
        const templatePanel = document.createElement("div");
        templatePanel.innerHTML = html;
        rpl.insertAdjacentElement("beforeend", templatePanel.children[0]);
        const div = rpl.children[rpl.children.length - 1];
        this.htmx.process(div);
        div.scrollIntoView();
        $(div).find("input[type='text']").setFocus();
    }
    searchButton_Click(element, e) {
        this.htmx.trigger("#data-record-popup-panel", "search");
    }
    searchTextbox_Keydown(element, e) {
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
    dataRecordPanel_Click(element, e) {
        if ($(e.target).hasAttribute("href") == true) {
            return;
        }
        if ($(e.target).hasAttribute("delete-record") == true) {
            return;
        }
        let pl = $(e.target).getFirstElement();
        if ($(pl).hasAttribute("data-record-panel") == false) {
            pl = $(pl).getParent("[data-record-panel]").getFirstElement();
        }
        this.recordSelected(pl);
    }
    dataRecordPanel_Keydown(element, e) {
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
                e.preventDefault();
            }
        }
        else if (e.key == "ArrowDown") {
            const pl = $(element).getSibling("Next").getFirstElement();
            if (pl == null) {
                $(recordListPanel).find("[data-record-panel]").setFocus();
            }
            else {
                $(pl).setFocus();
                e.preventDefault();
            }
        }
    }
    recordSelected(panel) {
        const dpl = this.getDataRecordPopupPanel();
        if (dpl == null || this.currentPanel == null) {
            return;
        }
        const pl = panel;
        const e = new DataRecordSelectedEventArgs();
        e.panel = panel;
        e.currentPanel = this.currentPanel;
        e.targetPanel = this.targetPanel;
        if ($(dpl).getAttribute("selection-mode") == "Single") {
            if (this.targetPanel != null) {
                $(this.targetPanel).setInnerHtml("");
                $(this.targetPanel).setInnerHtml($(pl).getOuterHtml());
                const cc = $(this.targetPanel).getChildElementList();
                $(cc).removeAttribute("tabindex");
                $(this.targetPanel).setFocus();
            }
            $(dpl).addClass("display-none");
            this.targetPanel = null;
            this.positionPanel = null;
        }
        if ($(dpl).getAttribute("selection-mode") == "Multiple") {
            if (this.targetPanel == null) {
                return;
            }
            $(this.targetPanel).appendInnerHtml($(pl).getOuterHtml());
            const cc = $(this.targetPanel).getChildElementList();
            $(cc).removeAttribute("tabindex");
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
        this.itemGroup.setCurrentItem(pl);
        this.OnSelected(e);
    }
    dataRecordPopupPanel_Selected(e) {
        if (e.currentPanel == null) {
            return;
        }
        if (e.currentPanel.hasAttribute("record-selected-nearest-target")) {
            const pl = $(e.currentPanel).getNearest(e.currentPanel.getAttribute("record-selected-nearest-target")).getFirstElement();
            if (pl != null) {
                this.htmx.trigger(pl, "record-selected");
            }
        }
    }
    dataRecordIcon_Click(element, e) {
        $(element).getFirstParent("[data-record-panel]").remove();
    }
    dataRecordIcon_Keydown(element, e) {
        if (e.key == "Enter") {
            $(element).getFirstParent("[data-record-panel]").remove();
        }
    }
    closeButton_Click(element, e) {
        this.hide();
    }
    hide() {
        if (this.targetPanel != null) {
            $(this.targetPanel).setFocus();
        }
        const dpl = this.getDataRecordPopupPanel();
        if (dpl != null) {
            $(dpl).addClass("display-none");
        }
        this.targetPanel = null;
        this.positionPanel = null;
    }
    body_Click(e) {
        if (e.detail == 0) {
            return;
        }
        const dpl = this.getDataRecordPopupPanel();
        if (dpl == null) {
            return;
        }
        if ($(dpl).hasClass("display-none") == false &&
            $(dpl).hasAttribute("processing") == false) {
            const rect = dpl.getBoundingClientRect();
            if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                $(dpl).addClass("display-none");
                this.targetPanel = null;
                this.positionPanel = null;
            }
        }
    }
}
export class DataRecordSelectedEventArgs {
    panel;
    currentPanel;
    targetPanel;
}
//# sourceMappingURL=DataRecordPopupPanel.js.map