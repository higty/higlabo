import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";

export default class SelectTimePopupPanel {
    private _durationPanel: HTMLElement;
    private _endTimePanel: HTMLElement;
    private _funcList: Array<SelectTimePopupPanelChanged> = new Array<SelectTimePopupPanelChanged>();

    public panel: HTMLElement;
    public textBox: HTMLInputElement;
    public endTimeTextBox: HTMLInputElement;
    public selectDuration: boolean = false;
    public selectEndTime: boolean = false;
    public startTime: string;
    public endTime: string;

    constructor() {
        this.panel = document.getElementById("SelectTimePopupPanel");
        this._durationPanel = document.getElementById("SelectDurationPopupPanel");
        this._endTimePanel = document.getElementById("SelectEndTimePopupPanel");
    }
    public initialize() {
        $(document).on("click", "input[time-picker]", this.textBox_Click.bind(this));
        $("input[time-picker]").keydown(this.textBox_Keydown.bind(this));

        $("#SelectTimePopupPanelShowAllChekBox").change(this.showAllChekBox_Change.bind(this));
        $(this.panel).on("click", "[minute-panel]", this.minutePanel_Click.bind(this));
        $(this.panel).on("dblclick", "[minute-panel]", this.minutePanel_DoubleClick.bind(this));
        $(this._durationPanel).on("click", "[duration-minute]", this.durationMinutePanel_Click.bind(this));
        $(this._endTimePanel).on("click", "[minute-panel]", this.endTimeMinutePanel_Click.bind(this));
    }
    private textBox_Click(target: Element, e: Event) {
        var tx = target as HTMLInputElement;
        if (tx != null) {
            this.textBox = tx;
            this.show(this.textBox);
        }
    }
    private textBox_Keydown(target: Element, e: Event) {
        this.hide();
    }

    private showAllChekBox_Change(target: Element, e: Event) {
        var chx = $("#SelectTimePopupPanelShowAllChekBox");
        if (chx.isChecked()) {
            $(this.panel).setAttribute("display-all", "true");
            $(this._endTimePanel).setAttribute("display-all", "true");
        }
        else {
            $(this.panel).setAttribute("display-all", "false");
            $(this._endTimePanel).setAttribute("display-all", "false");
        }
    }
    private minutePanel_Click(target: Element, e: Event) {
        this.setTextBoxValue(target);
        this.isDisplayNextPopupPanel(target);
        e.stopPropagation();
    }
    private minutePanel_DoubleClick(target: Element, e: Event) {
        this.setTextBoxValue(target);
        this.hide();
        e.stopPropagation();
    }
    private setTextBoxValue(element: Element) {
        var div = $(element);
        var hour = div.getAttribute("hour");
        var minute = div.getAttribute("minute");
        if (this.textBox != null) {
            $(this.textBox).setValue(hour + ":" + minute);
            this.startTime = $(this.textBox).getValue();
        }
        this.executeFunction();
    }
    private executeFunction() {
        for (var i = 0; i < this._funcList.length; i++) {
            var f = this._funcList[i];
            f(this, {});
        }
    }
    private isDisplayNextPopupPanel(element: Element) {
        var tr = $(element).getParent("tr").getFirstElement();
        var rect = tr.getBoundingClientRect();
        if (this.selectDuration == true) {
            $(this._durationPanel).setStyle("display", "block");
            $(this._durationPanel).setStyle("left", rect.left + rect.width + "px");
            $(this._durationPanel).setStyle("top", rect.top + "px");
            this.ensureInsideWindow(this._durationPanel);
        }
        else if (this.selectEndTime == true) {
            $(this._endTimePanel).setStyle("display", "block");
            $(this._endTimePanel).setStyle("left", rect.left + rect.width + "px");
            $(this._endTimePanel).setStyle("top", rect.top + "px");
            this.ensureInsideWindow(this._endTimePanel);
        }
        else {
            this.textBox = null;
            this.hide();
        }
    }

    private durationMinutePanel_Click(target: Element, e: Event) {
        var div = $(target);
        var minute = parseInt(div.getAttribute("minute"));
        var startTime = new DateTime("2000/1/1 " + $(this.textBox).getValue());// Dummy date to calculate endtime...
        var endTime = startTime.addMinute(minute);
        $(this.endTimeTextBox).setValue(endTime.toString("hh:mm"));
        this.endTime = $(this.endTimeTextBox).getValue();

        this.textBox = null;
        this.endTimeTextBox = null;
        this.hide();
        e.stopPropagation();
    }
    private endTimeMinutePanel_Click(target: Element, e: Event) {
        var div = $(target);
        var hour = div.getAttribute("hour");
        var minute = div.getAttribute("minute");
        $(this.endTimeTextBox).setValue(hour + ":" + minute);
        this.endTime = $(this.endTimeTextBox).getValue();

        this.textBox = null;
        this.endTimeTextBox = null;
        this.hide();
        e.stopPropagation();
    }

    public show(offsetPanel: Element) {
        this.selectDuration = false;
        this.selectEndTime = false;
        if ($(this.textBox).getAttribute("select-duration") == "true") {
            this.selectDuration = true;
        }
        if ($(this.textBox).getAttribute("select-end-time") == "true") {
            this.selectEndTime = true;
        }
        this.endTimeTextBox = $(this.textBox).getNearestElement("[time-picker]") as HTMLInputElement;

        const popupPanel = this.panel;
        const offset = $(offsetPanel).getOffset();
        const top = offset.top + $(offsetPanel).getOuterHeight();
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
            left = windowMaxWidth - width - 10;
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
    public hide() {
        $(this.panel).hide();
        $(this._durationPanel).hide();
        $(this._endTimePanel).hide();
    }

    public changed(func) {
        this._funcList.push(func);
    }
}
export interface SelectTimePopupPanelChanged {
    (sender: SelectTimePopupPanel, e: any)
}