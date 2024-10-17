import { $ } from "./HtmlElementQuery.js";

export class RecordListComponent {
    public initialize() {
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

    public showListView(componentPanel: Element) {
        $(componentPanel).find("[hig-list-view]").removeClass("display-none");
        $(componentPanel).find("[hig-detail-view]").setInnerHtml("").addClass("display-none");
        $(componentPanel).find("[hig-right-view]").setInnerHtml("").addClass("display-none");
    }
    public showEditView(componentPanel: Element) {
        $(componentPanel).find("[hig-list-view]").addClass("display-none");
        $(componentPanel).find("[hig-detail-view]").removeClass("display-none");
        $(componentPanel).find("[hig-right-view]").addClass("display-none");
    }
    public showRightView(componentPanel: Element) {
        $(componentPanel).find("[hig-right-view]").setInnerHtml($("#loading-panel-template").getInnerHtml()).removeClass("display-none");
    }

    private add_Click(target: Element, e: Event) {
        this.showEditView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
    private detail_Click(target: Element, e: Event) {
        this.showEditView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
    private right_Click(target: Element, e: Event) {
        this.showRightView($(target).getFirstParent("[hig-component]").getFirstElement());
        e.preventDefault();
    }
    private rightView_Hide(target: Element, e: Event) {
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        $(componentPanel).find("[hig-right-view]").addClass("display-none");
    }
    private selectAll_Click(target: Element, e: Event) {
        const checked = $(target).isChecked();
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        $(componentPanel).find("input[type='checkbox'][name='Selected']").setChecked(checked);
    }
    private load_Click(target: Element, e: Event) {
        const componentPanel = $(target).getFirstParent("[hig-component]").getFirstElement();
        this.loadData(componentPanel);
    }
    private pageNumberIncrement_Click(target: Element, e: Event) {
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
    private loadData(componentPanel: Element) {
        const htmx = window["htmx"];
        if (htmx != null) {
            const rpl = $(componentPanel).find("[hig-record-list-panel]").getFirstElement();
            $(rpl).setInnerHtml($("#loading-panel-template").getInnerHtml()).setScrollTop(0);
            htmx.trigger(rpl, "load-record-list");
        }
    }

    private afterRequest(e: any) {
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
    private saveCancel_Click(target: Element, e: Event) {
        this.showListView($(target).getFirstParent("[hig-component]").getFirstElement());
    }
}