import { $ } from "./HtmlElementQuery.js";
export class RecordListComponent {
    initialize() {
        $("body").on("click", "[hig-component] [hig-add]", this.add_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-detail]", this.detail_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-right]", this.right_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-list-view]", this.rightView_Hide.bind(this));
        $("body").on("click", "[hig-component] [hig-detail-view]", this.rightView_Hide.bind(this));
        $("body").on("click", "[hig-component] [hig-select-all]", this.selectAll_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-load]", this.load_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-page-number-increment]", this.pageNumberIncrement_Click.bind(this));
        $("body").on("click", "[hig-component] [hig-list]", this.saveCancel_Click.bind(this));
        document.body.addEventListener('htmx:afterRequest', this.afterRequest.bind(this));
    }
    showListView(componentPanel) {
        $(componentPanel).find("[hig-list-view]").removeClass("display-none");
        $(componentPanel).find("[hig-detail-view]").setInnerHtml("").addClass("display-none");
        $(componentPanel).find("[hig-right-view]").setInnerHtml("").addClass("display-none");
    }
    showEditView(componentPanel) {
        $(componentPanel).find("[hig-list-view]").addClass("display-none");
        $(componentPanel).find("[hig-detail-view]").removeClass("display-none");
        $(componentPanel).find("[hig-right-view]").addClass("display-none");
    }
    showRightView(componentPanel) {
        $(componentPanel).find("[hig-right-view]").setInnerHtml($("#loading-panel-template").getInnerHtml()).removeClass("display-none");
    }
    add_Click(target, e) {
        this.showEditView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
    detail_Click(target, e) {
        this.showEditView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
    right_Click(target, e) {
        this.showRightView($(target).getFirstParent("[hig-component]").getFirstElement());
        e.preventDefault();
    }
    rightView_Hide(target, e) {
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        $(componentPanel).find("[hig-right-view]").addClass("display-none");
    }
    selectAll_Click(target, e) {
        const checked = $(target).isChecked();
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        $(componentPanel).find("input[type='checkbox'][name='Selected']").setChecked(checked);
    }
    load_Click(target, e) {
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        this.loadData(componentPanel);
    }
    pageNumberIncrement_Click(target, e) {
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        const pageNumberPanel = $(componentPanel).find("[name='PageNumber']");
        const increment = parseInt($(target).getAttribute("hig-page-number-increment"));
        let newPageNumber = parseInt($(pageNumberPanel).getInnerText()) + increment;
        if (newPageNumber < 1) {
            newPageNumber = 1;
        }
        $(pageNumberPanel).setInnerText(newPageNumber.toString());
        this.loadData(componentPanel);
    }
    loadData(componentPanel) {
        const htmx = window["htmx"];
        if (htmx != null) {
            const rpl = $(componentPanel).find("[hig-record-list-panel]").getFirstElement();
            $(rpl).setInnerHtml($("#loading-panel-template").getInnerHtml()).setScrollTop(0);
            htmx.trigger(rpl, "load-record-list");
        }
    }
    afterRequest(e) {
        const componentPanel = $(e.target).getFirstParent("[hig-component]").getFirstElement();
        if ($(e.target).getAttribute("hig-save") == "true") {
            const statusCode = e.detail.xhr.status.toString();
            if (statusCode == 0 || statusCode.startsWith("2")) {
                this.loadData(componentPanel);
            }
        }
        if ($(e.target).getAttribute("hig-record-list-panel") == "true") {
            this.showListView(componentPanel);
        }
    }
    saveCancel_Click(target, e) {
        this.showListView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
}
//# sourceMappingURL=RecordListComponent.js.map