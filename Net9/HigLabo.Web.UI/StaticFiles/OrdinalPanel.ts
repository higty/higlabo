import { $ } from "./HtmlElementQuery.js";

export class OrdinalPanel {
    private dragElement: Element;
    private dragStartTimeTicks: number;
    private offsetX: number;
    private offsetY: number;

    public constructor() {
        this.dragStartTimeTicks = new Date().getTime();
    }
    public initialize() {
        $("body").on("mousedown", "[ordinal-panel]", this.dragStart.bind(this));
        $("body").mousemove(this.drag.bind(this));
        $("body").mouseup(this.dragEnd.bind(this));
    }
    private dragStart(target: Element, e: MouseEvent) {
        this.dragElement = target;
        this.dragStartTimeTicks = new Date().getTime();
        this.offsetX = e.offsetX;
        this.offsetY = e.offsetY;
        this.clearTextSelection();
        if ($(e.target).getTagName() == "IMG") {
            e.preventDefault();
            this.dragElement = null;
        }
    }
    private drag(e: MouseEvent) {
        if (this.dragElement == null) { return; }

        const nowTicks = new Date().getTime();
        if (this.dragStartTimeTicks == null || nowTicks - this.dragStartTimeTicks < 300) { return; }

        const pl = this.dragElement;
        $(pl).setStyle("width", $(pl).getOuterWidth() + "px");
        $(pl).setAttribute("draging", "true");
        $(pl).setStyle("left", (e.clientX - 80) + "px");
        $(pl).setStyle("top", (e.clientY - this.offsetY) + "px");

        const pp = $("[ordinal-panel]").getElementList();
        pp.forEach(targetPanel => {
            const rect = targetPanel.getBoundingClientRect();
            if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                $(targetPanel).removeAttribute("drop-mouse-over");
            }
            else {
                $(targetPanel).setAttribute("drop-mouse-over", "true");
            }
        });
        this.clearTextSelection();
    }
    private dragEnd(e: MouseEvent) {
        const pl = this.dragElement;
        const nowTicks = new Date().getTime();
        if (this.dragStartTimeTicks == null || nowTicks - this.dragStartTimeTicks < 300) {
            this.dragElement = null;
        }
        if (this.dragElement != null) {
            this.dragElement = null;

            const pp = $("[ordinal-panel]").getElementList();
            pp.forEach(targetPanel => {
                const rect = targetPanel.getBoundingClientRect();
                if (rect.left > e.clientX || rect.left + rect.width < e.clientX || rect.top > e.clientY || rect.top + rect.height < e.clientY) {
                }
                else {
                    $(targetPanel).insertAdjacentElement("afterend", pl);
                }
            });
            pp.forEach(targetPanel => {
                $(targetPanel).removeAttribute("drop-mouse-over");
            });
        }

        $(pl).removeAttribute("draging");
        $(pl).removeStyle("left");
        $(pl).removeStyle("top");
        $(pl).removeStyle("width");

    }
    public clearTextSelection() {
        try {
            if (window.getSelection) {
                if (window.getSelection().empty) {
                    window.getSelection().empty();
                }
                else if (window.getSelection().removeAllRanges) {
                    window.getSelection().removeAllRanges();
                }
            }
        }
        catch { }
    }
}