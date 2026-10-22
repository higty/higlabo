import { $ } from "./HtmlElementQuery.js";
export class DataView {
    initialize() {
        $("body").on("click", "[data-view-load]", this.load_Click.bind(this));
        $("body").on("click", "[data-view-paging-panel] [page-number-increment]", this.pageNumberIncrement_Click.bind(this));
        $("body").on("focusout", "[data-view-paging-panel] [name='PageNumber']", this.pageNumber_Blur.bind(this));
        $("body").on("click", "[show-data-view-view-panel]", this.showViewPanel_Click.bind(this));
        $("body").on("click", "[show-data-view-detail-panel]", this.showDetailPanel_Click.bind(this));
        $("body").on("click", "[show-data-view-right-panel]", this.showRightPanel_Click.bind(this));
        $("body").on("click", "[data-view-view-panel]", this.rightView_Hide.bind(this));
        $("body").on("click", "[data-view-detail-panel]", this.rightView_Hide.bind(this));
        $("body").on("click", "[data-view-select-all]", this.selectAll_Click.bind(this));
        document.addEventListener('htmx:finally:request', this.afterRequest.bind(this));
    }
    showViewPanel(dataViewPanel) {
        $(dataViewPanel).findDescendants("[data-view-view-panel]").removeClass("display-none");
        $(dataViewPanel).findDescendants("[data-view-detail-panel]").setInnerHtml("").addClass("display-none");
        $(dataViewPanel).findDescendants("[data-view-right-panel]").setInnerHtml("").addClass("display-none");
    }
    showDetailPanel(dataViewPanel) {
        $(dataViewPanel).findDescendants("[data-view-view-panel]").addClass("display-none");
        $(dataViewPanel).findDescendants("[data-view-detail-panel]").removeClass("display-none");
        $(dataViewPanel).findDescendants("[data-view-right-panel]").addClass("display-none");
    }
    showRightPanel(dataViewPanel) {
        $(dataViewPanel).findDescendants("[data-view-right-panel]").setInnerHtml($("#loading-panel-template").getInnerHtml()).removeClass("display-none");
    }
    showViewPanel_Click(target, e) {
        this.showViewPanel($(target).findAncestors("[data-view]").getFirstElement());
    }
    showDetailPanel_Click(target, e) {
        this.showDetailPanel($(target).findAncestors("[data-view]").getFirstElement());
    }
    showRightPanel_Click(target, e) {
        this.showRightPanel($(target).findAncestors("[data-view]").getFirstElement());
        e.preventDefault();
    }
    rightView_Hide(target, e) {
        const dataViewPanel = $(target).findAncestors("[data-view]").getFirstElement();
        $(dataViewPanel).findDescendants("[data-view-right-panel]").addClass("display-none");
    }
    selectAll_Click(target, e) {
        const checked = $(target).isChecked();
        const dataViewPanel = $(target).findAncestors("[data-view]").getFirstElement();
        $(dataViewPanel).findDescendants("input[type='checkbox'][name='Selected']").setChecked(checked);
    }
    load_Click(target, e) {
        const dataViewPanel = $(target).findAncestors("[data-view]").getFirstElement();
        this.loadData(dataViewPanel);
    }
    pageNumber_Blur(target, e) {
        const dataViewPanel = $(target).findAncestors("[data-view]").getFirstElement();
        this.loadData(dataViewPanel);
    }
    pageNumberIncrement_Click(target, e) {
        const dataViewPanel = $(target).findAncestors("[data-view]").getFirstElement();
        const pageNumberPanel = $(dataViewPanel).findDescendants("[name='PageNumber']");
        const increment = parseInt($(target).getAttribute("page-number-increment"));
        let newPageNumber = parseInt($(pageNumberPanel).getValue()) + increment;
        if (newPageNumber < 1) {
            newPageNumber = 1;
        }
        if (isNaN(newPageNumber)) {
            newPageNumber = 1;
        }
        $(pageNumberPanel).setValue(newPageNumber.toString());
        this.loadData(dataViewPanel);
    }
    loadData(dataViewPanel) {
        const htmx = window["htmx"];
        if (htmx != null) {
            const rpl = $(dataViewPanel).findDescendants("[data-view-record-list-panel]").getFirstElement();
            $(rpl).setInnerHtml($("#loading-panel-template").getInnerHtml()).setScrollTop(0);
            htmx.trigger(rpl, "data-view-load");
        }
    }
    afterRequest(e) {
        const ctx = e.detail.ctx;
        const statusCode = ctx.response?.status;
        if (statusCode == null || statusCode < 200 || statusCode >= 300 || ctx.status !== "swapped") {
            return;
        }
        const sourceElement = ctx.sourceElement;
        const dataViewPanel = $(sourceElement).findAncestors("[data-view]").getFirstElement();
        if ($(sourceElement).getAttribute("data-view-save") == "true") {
            this.loadData(dataViewPanel);
        }
        if ($(sourceElement).getAttribute("data-view-record-list-panel") == "true") {
            this.showViewPanel(dataViewPanel);
        }
    }
}
//# sourceMappingURL=DataView.js.map