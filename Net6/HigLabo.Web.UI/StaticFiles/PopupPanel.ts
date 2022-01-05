import { $, $fromJson, HtmlElementQuery } from "./HtmlElementQuery.js";

export class PopupPanel {
    public setPosition(popupPanel: Element, e: MouseEvent) {
        
        $(popupPanel).setStyle("left", e.clientX + "px");
        $(popupPanel).setStyle("top", e.clientY + "px");
        $(popupPanel).setStyle("display", "initial");

        this.ensureInsideWindow(popupPanel);
    }
    public show(popupPanel: Element, offsetPanel: Element) {
        var offset = $(offsetPanel).getOffset();
        var top = offset.top + $(offsetPanel).getOuterHeight();

        $(popupPanel).setStyle("left", offset.left + "px");
        $(popupPanel).setStyle("top", top + "px");
        $(popupPanel).setStyle("display", "initial");

        this.ensureInsideWindow(popupPanel, offsetPanel);
    }
    public ensureInsideWindow(popupPanel: Element, offsetPanel?: Element) {
        const pl = $(popupPanel);
        const offset = pl.getOffset();
        let left = offset.left;
        let top = offset.top;
        const windowMaxWidth = window.innerWidth;
        const windowMaxHeight = window.innerHeight + $(window).getScrollTop() - 24;
        const width = pl.getOuterWidth();
        const height = pl.getOuterHeight();

        if (left + width > windowMaxWidth - 10) {
            left = windowMaxWidth - width - 20;
            pl.setStyle("left", left + "px");
        }
        else {
            if (left < 0) {
                left = 0;
            }
            pl.setStyle("left", left + "px");
        }

        if (offsetPanel == null) {
            if (top + height > windowMaxHeight) {
                var top1 = windowMaxHeight - height;
                if (top1 > 0) {
                    pl.setStyle("top", top1 + "px");
                }
                else {
                    pl.setStyle("top", windowMaxHeight - pl.getOuterHeight() + "px");
                }
            }
            else {
                pl.setStyle("top", top + "px");
            }
        }
        else {
            if (top + height > windowMaxHeight) {
                var top1 = top - pl.getInnerHeight() - $(offsetPanel).getOuterHeight() - 2;//Adjust border width
                if (top1 > 0) {
                    pl.setStyle("top", top1 + "px");
                }
                else {
                    pl.setStyle("top", windowMaxHeight - pl.getOuterHeight() + "px");
                }
            }
            else {
                pl.setStyle("top", top + "px");
            }
        }
    }

}