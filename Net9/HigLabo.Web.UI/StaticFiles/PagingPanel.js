import { $ } from "./HtmlElementQuery.js";
import { Htmx } from "./Htmx.js";
export class PagingPanel {
    htmx = new Htmx();
    initialize() {
        $(document).on("click", "[paging-panel] [page-index-increment]", this.pageIndexIncrement_Click.bind(this));
        $(document).on("change", "[paging-panel] input[type='text'][name='PageNumber']", this.pageNumber_Change.bind(this));
    }
    pageIndexIncrement_Click(target, e) {
        const pl = $(target).getFirstParent("[paging-panel]").getFirstElement();
        const tx = $(pl).find("input[type='text'][name='PageNumber']").getFirstElement();
        const pageIndex = parseInt($(tx).getValue()) - 1;
        const maxPageIndex = parseInt($(pl).find("[max-page-number]").getInnerText());
        const increment = parseInt($(target).getAttribute("page-index-increment"));
        let newPageIndex = pageIndex + increment;
        this.setPageIndex(pl, newPageIndex, maxPageIndex);
        this.htmx.trigger($(pl).find("[page-index-panel]").getFirstElement(), "page-index-change");
    }
    pageNumber_Change(target, e) {
        const pl = $(target).getFirstParent("[paging-panel]").getFirstElement();
        const tx = $(pl).find("input[type='text'][name='PageNumber']").getFirstElement();
        let newPageIndex = parseInt($(tx).getValue()) - 1;
        const maxPageIndex = parseInt($(pl).find("[max-page-number]").getInnerText());
        this.setPageIndex(pl, newPageIndex, maxPageIndex);
        this.htmx.trigger($(pl).find("[page-index-panel]").getFirstElement(), "page-index-change");
    }
    setPageIndex(pagingPanel, pageIndex, maxPageIndex) {
        const pl = pagingPanel;
        const tx = $(pl).find("input[type='text'][name='PageNumber']").getFirstElement();
        const hidden = $(pl).find("[page-index-panel] input[type='hidden'][name='PageIndex']").getFirstElement();
        if (pageIndex >= maxPageIndex) {
            pageIndex = maxPageIndex - 1;
        }
        if (pageIndex < 0 || isNaN(pageIndex)) {
            pageIndex = 0;
        }
        $(hidden).setValue(pageIndex.toString());
        $(tx).setValue((pageIndex + 1).toString());
        $(pl).find("[increment='-1']").setValue(Math.max(pageIndex - 1, 0).toString());
        $(pl).find("[increment='1']").setValue((pageIndex + 1).toString());
    }
    setMaxPageIndex(pagingPanel, pageIndex, maxPageIndex) {
        const pl = pagingPanel;
        const tx = $(pl).find("input[type='text'][name='PageNumber']").getFirstElement();
        $(pl).find("[max-page-number]").setInnerText(maxPageIndex.toString());
        $(tx).setValue(pageIndex.toString());
        this.setPageIndex(pl, pageIndex, maxPageIndex);
    }
}
//# sourceMappingURL=PagingPanel.js.map