import { $ } from "./HtmlElementQuery.js";
export class DataView {
    initialize() {
        $("body").on("click", "[data-view-load]", this.load_Click.bind(this));
        $("body").on("click", "[data-view] [page-number-increment]", this.pageNumberIncrement_Click.bind(this));
        $("body").on("click", "[show-data-view-view-panel]", this.showViewPanel_Click.bind(this));
        $("body").on("click", "[show-data-view-detail-panel]", this.showDetailPanel_Click.bind(this));
        $("body").on("click", "[show-data-view-right-panel]", this.showRightPanel_Click.bind(this));
        $("body").on("click", "[data-view-view-panel]", this.rightView_Hide.bind(this));
        $("body").on("click", "[data-view-detail-panel]", this.rightView_Hide.bind(this));
        $("body").on("click", "[data-view-select-all]", this.selectAll_Click.bind(this));
        document.body.addEventListener('htmx:afterRequest', this.afterRequest.bind(this));
    }
    showViewPanel(dataViewPanel) {
        $(dataViewPanel).find("[data-view-view-panel]").removeClass("display-none");
        $(dataViewPanel).find("[data-view-detail-panel]").setInnerHtml("").addClass("display-none");
        $(dataViewPanel).find("[data-view-right-panel]").setInnerHtml("").addClass("display-none");
    }
    showDetailPanel(dataViewPanel) {
        $(dataViewPanel).find("[data-view-view-panel]").addClass("display-none");
        $(dataViewPanel).find("[data-view-detail-panel]").removeClass("display-none");
        $(dataViewPanel).find("[data-view-right-panel]").addClass("display-none");
    }
    showRightPanel(dataViewPanel) {
        $(dataViewPanel).find("[data-view-right-panel]").setInnerHtml($("#loading-panel-template").getInnerHtml()).removeClass("display-none");
    }
    showViewPanel_Click(target, e) {
        this.showViewPanel($(target).getFirstParent("[data-view]").getFirstElement());
    }
    showDetailPanel_Click(target, e) {
        this.showDetailPanel($(target).getFirstParent("[data-view]").getFirstElement());
    }
    showRightPanel_Click(target, e) {
        this.showRightPanel($(target).getFirstParent("[data-view]").getFirstElement());
        e.preventDefault();
    }
    rightView_Hide(target, e) {
        const dataViewPanel = $(target).getFirstParent("[data-view]").getFirstElement();
        $(dataViewPanel).find("[data-view-right-panel]").addClass("display-none");
    }
    selectAll_Click(target, e) {
        const checked = $(target).isChecked();
        const dataViewPanel = $(target).getFirstParent("[data-view]").getFirstElement();
        $(dataViewPanel).find("input[type='checkbox'][name='Selected']").setChecked(checked);
    }
    load_Click(target, e) {
        const dataViewPanel = $(target).getFirstParent("[data-view]").getFirstElement();
        this.loadData(dataViewPanel);
    }
    pageNumberIncrement_Click(target, e) {
        const dataViewPanel = $(target).getFirstParent("[data-view]").getFirstElement();
        const pageNumberPanel = $(dataViewPanel).find("[name='PageNumber']");
        const increment = parseInt($(target).getAttribute("page-number-increment"));
        let newPageNumber = parseInt($(pageNumberPanel).getInnerText()) + increment;
        if (newPageNumber < 1) {
            newPageNumber = 1;
        }
        $(pageNumberPanel).setInnerText(newPageNumber.toString());
        this.loadData(dataViewPanel);
    }
    loadData(dataViewPanel) {
        const htmx = window["htmx"];
        if (htmx != null) {
            const rpl = $(dataViewPanel).find("[data-view-record-list-panel]").getFirstElement();
            $(rpl).setInnerHtml($("#loading-panel-template").getInnerHtml()).setScrollTop(0);
            htmx.trigger(rpl, "load-record-list");
        }
    }
    afterRequest(e) {
        const dataViewPanel = $(e.target).getFirstParent("[data-view]").getFirstElement();
        if ($(e.target).getAttribute("data-view-delete") == "true") {
            const statusCode = e.detail.xhr.status.toString();
            if (statusCode == 0 || statusCode.startsWith("2")) {
                this.loadData(dataViewPanel);
            }
        }
        if ($(e.target).getAttribute("data-view-record-list-panel") == "true") {
            this.showViewPanel(dataViewPanel);
        }
    }
}
//# sourceMappingURL=DataView.js.map