import { DateOnly, DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
import { HigLaboVue } from "./HigLaboVue.js";
import { HttpClient } from "./HttpClient.js";
import { CKEditorTextBox } from "./CKEditorTextBox.js";
import SelectTimePopupPanel from "./SelectTimePopupPanel.js";
import { TinyMceTextBox } from "./TinyMceTextBox.js";
export class InputPropertyPanel {
    constructor() {
        this._eventHandlerList = new Array();
        this.selectTimePopupPanel = new SelectTimePopupPanel();
    }
    initialize() {
        this.selectTimePopupPanel.initialize();
        $("body").find("input").forEach((element, index) => {
            $(element).setAttribute("previous-value", $(element).getValue());
        });
        $("body").on("change", "input", this.input_Change.bind(this));
        $("body").on("focusin", "input[date-picker],input[time-picker]", this.dateTimeTextBox_Focusin.bind(this));
        $("body").on("keydown", "input[date-picker]", this.dateTextBox_Keydown.bind(this));
        $("body").on("keydown", "input[time-picker]", this.timeTextBox_Keydown.bind(this));
        $("body").on("keydown", "[input-property-panel][element-type='Color'] input[type=text]", this.colorTextBox_Keydown.bind(this));
        $("body").on("keyup", "[input-property-panel][element-type='Color'] input[type=text]", this.colorTextBox_Keyup.bind(this));
        $("body").on("click", "[input-property-panel][element-type='Color'] [color-panel]", this.colorPanel_Click.bind(this));
        $("body").on("click", "[input-property-panel][element-type='Color'] td[color]", this.colorCell_Click.bind(this));
        $("body").on("keydown", "[input-property-panel][element-type='Color'] td[color]", this.colorCell_Keydown.bind(this));
        $("body").on("change", "[input-property-panel] [set-by-end-time]", this.dateTimeDurationList_Change.bind(this));
        $("body").on("change", "[input-property-panel][element-type='DateDropDownList'] [year]", this.dateDrowDownList_Change.bind(this));
        $("body").on("change", "[input-property-panel][element-type='DateDropDownList'] [month]", this.dateDrowDownList_Change.bind(this));
        $("body").on("keydown", "[input-property-panel][element-type='DateDropDownList'] select", this.dateDrowDownList_Keydown.bind(this));
        $("body").on("click", "[input-property-panel]  [radio-button-label]", this.radioButtonLabel_Click.bind(this));
        $("body").on("click", "[input-property-panel]  [checkbox-label]", this.checkBoxLabel_Click.bind(this));
        $("body").on("input", "[input-property-panel] [filter-textbox]", this.filterTextBox_Keydown.bind(this));
        $("body").on("keydown", "[input-property-panel] [delete-link]", this.deleteLink_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [delete-link]", this.deleteLink_Click.bind(this));
        $("body").on("click", "[input-property-panel] [add-record-button]", this.addRecordButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-panel]", this.selectRecordPanel_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-panel]", this.selectRecordPanel_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [search-button]", this.searchButton_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [search-textbox]", this.searchTextBox_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [tab-name='Search'] [record-list-panel] [h-record]", this.record_Click.bind(this));
        $("body").on("click", "[input-property-panel] [sort-button]", this.sortButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [sort-record]", this.sortRecord_Click.bind(this));
        $("body").on("click", "[input-property-panel] [close-button]", this.closeButton_Click.bind(this));
        $("body").on("keyup", "[input-property-panel] [select-record-list-panel] [header-text-binding-panel] input[type=text]", this.editRecordPanelTextBox_Keyup.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-list-panel] [toggle-content-panel]", this.toggleContentPanel_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [toggle-content-panel]", this.toggleContentPanel_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-list-panel] [header-text]", this.headerText_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [delete-candidate-link]", this.deleteCandidateLink_Click.bind(this));
        $("body").on("click", "[input-property-panel] [tab-header-list-panel] [tab-name]", this.tabName_Click.bind(this));
        $("body").on("click", "[input-property-panel] [tab-panel] [create-record-button]", this.createRecordButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [tab-panel] [search-by-text-button]", this.searchByTextButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [tab-panel][template-id] [record-list-panel] [h-record]", this.tabPanelRecord_Click.bind(this));
        this.initializeSetByEndTimeProperty();
    }
    initializeFlatpickr(language) {
        const flatpickr = window["flatpickr"];
        if (flatpickr == null) {
            return;
        }
        flatpickr.l10ns.default.firstDayOfWeek = 1;
        if (language == "ja-JP") {
            flatpickr.localize(flatpickr.l10ns.ja);
        }
        flatpickr("[date-picker]", {
            dateFormat: "Y/m/d",
            allowInput: true,
            disableMobile: true
        });
        flatpickr("[inline-date-picker]", {
            dateFormat: "Y/m/d",
            allowInput: true,
            disableMobile: true,
            inline: true
        });
    }
    registerEventHandler(hander) {
        this._eventHandlerList.push(hander);
    }
    initializeSetByEndTimeProperty() {
        var ipl = this;
        $("[input-property-panel] [set-by-end-time]").forEach((element, index) => {
            ipl.toggleDateTimeDurationList(element);
        });
    }
    input_Change(target, e) {
        $(target).setAttribute("previous-value", $(target).getValue());
    }
    dateTimeTextBox_Focusin(target, e) {
        $(target).select();
    }
    dateTextBox_Keydown(target, e) {
        const ftx = target;
        if (ftx._flatpickr != null) {
            if (e.keyCode == 40) {
                ftx._flatpickr.open();
            }
            else {
                ftx._flatpickr.close();
            }
        }
        if (e.keyCode != 9) {
            return;
        }
        var tx = $(target);
        var text = tx.getValue();
        var value = parseInt(text);
        if (isNaN(value) == true) {
            return;
        }
        var today = DateTime.getToday();
        var date = new DateOnly();
        if (text.length <= 2) {
            date.Year = today.year;
            date.Month = today.month;
            date.Day = value;
        }
        else if (text.length == 3) {
            date.Year = today.year;
            date.Month = parseInt(text.substr(0, 1));
            date.Day = parseInt(text.substr(1, 2));
        }
        else if (text.length == 4) {
            date.Year = today.year;
            date.Month = parseInt(text.substr(0, 2));
            date.Day = parseInt(text.substr(2, 2));
        }
        else if (text.length == 5) {
            date.Year = parseInt("20" + text.substr(0, 2));
            date.Month = parseInt(text.substr(2, 1));
            date.Day = parseInt(text.substr(3, 2));
        }
        else if (text.length == 6) {
            date.Year = parseInt("20" + text.substr(0, 2));
            date.Month = parseInt(text.substr(2, 2));
            date.Day = parseInt(text.substr(4, 2));
        }
        else if (text.length == 8) {
            date.Year = parseInt(text.substr(0, 4));
            date.Month = parseInt(text.substr(4, 2));
            date.Day = parseInt(text.substr(6, 2));
        }
        else {
            return;
        }
        let dateTime = new DateTime(date);
        if (text.length == 1 || text.length == 2) {
            if (dateTime.value < today.value) {
                dateTime = today.addMonth(1);
            }
        }
        tx.setValue(dateTime.toString("yyyy/MM/dd"));
    }
    timeTextBox_Keydown(target, e) {
        if (e.keyCode == 40) {
            this.selectTimePopupPanel.show(target);
        }
        else {
            this.selectTimePopupPanel.hide();
        }
        if (e.keyCode != 9) {
            return;
        }
        var tx = $(target);
        var text = tx.getValue();
        if (text.length == 1) {
            var hour = parseInt(text);
            var minute = 0;
        }
        if (text.length == 2) {
            var hour = parseInt(text);
            var minute = 0;
        }
        if (text.length == 3) {
            var hour = parseInt("0" + text.substr(0, 1));
            var minute = parseInt(text.substr(1, 2));
        }
        if (text.length == 4) {
            var hour = parseInt(text.substr(0, 2));
            var minute = parseInt(text.substr(2, 2));
        }
        if (text.length == 5) {
            var hour = parseInt(text.substr(0, 2));
            var minute = parseInt(text.substr(3, 2));
        }
        if (minute == NaN) {
            minute = 0;
        }
        if (0 <= hour && hour < 30 &&
            0 <= minute && minute < 60) {
            if (hour < 10) {
                if (minute < 10) {
                    tx.setValue("0" + hour + ":0" + minute);
                }
                else {
                    tx.setValue("0" + hour + ":" + minute);
                }
            }
            else {
                if (minute < 10) {
                    tx.setValue(hour + ":0" + minute);
                }
                else {
                    tx.setValue(hour + ":" + minute);
                }
            }
        }
        else {
            tx.setValue("");
        }
    }
    colorTextBox_Keydown(target, e) {
        if (e.keyCode == 13) {
            this.showColorTable(target);
        }
    }
    colorTextBox_Keyup(target, e) {
        $(target).getNearest("[color-panel]").setStyle("background-color", $(target).getValue());
    }
    colorPanel_Click(target, e) {
        this.showColorTable(target);
    }
    showColorTable(target) {
        $(target).getNearest("[color-table-panel]").setStyle("display", "block");
        $(target).getNearest("[color-table-panel]").find("td").setFocus();
    }
    colorCell_Click(target, e) {
        var color = $(target).getAttribute("color");
        this.setColor(target, color);
    }
    colorCell_Keydown(target, e) {
        const tr = target.parentElement;
        if (e.keyCode == 13) {
            var color = $(target).getAttribute("color");
            this.setColor(target, color);
        }
        else if (e.keyCode == 37) {
            if (target.previousElementSibling == null) {
                const td = $(target).getParent("tr").find("td").getLastElement();
                $(td).setFocus();
            }
            else {
                $(target.previousElementSibling).setFocus();
            }
            e.preventDefault();
        }
        else if (e.keyCode == 38) {
            const index = $(target).getIndex();
            $(tr.previousElementSibling.children[index]).setFocus();
            e.preventDefault();
        }
        else if (e.keyCode == 39) {
            if (target.nextElementSibling == null) {
                const td = $(target).getParent("tr").find("td").getFirstElement();
                $(td).setFocus();
            }
            else {
                $(target.nextElementSibling).setFocus();
            }
            e.preventDefault();
        }
        else if (e.keyCode == 40) {
            const index = $(target).getIndex();
            $(tr.nextElementSibling.children[index]).setFocus();
            e.preventDefault();
        }
    }
    setColor(target, color) {
        $(target).getNearest("[color-panel]").setStyle("background-color", color);
        $(target).getNearest("[color-table-panel]").hide();
        $(target).getNearest("input[type='text']").setValue(color).setFocus().select();
    }
    dateTimeDurationList_Change(target, e) {
        this.toggleDateTimeDurationList(target);
    }
    toggleDateTimeDurationList(target) {
        const durationListPanel = $(target).getNearestElement("[duration-list-panel]");
        const durationEndPanel = $(target).getNearestElement("[duration-end-panel]");
        if ($(target).isChecked()) {
            $(durationListPanel).setStyle("display", "none");
            $(durationEndPanel).setStyle("display", "inline");
        }
        else {
            $(durationListPanel).setStyle("display", "inline");
            $(durationEndPanel).setStyle("display", "none");
        }
    }
    dateDrowDownList_Change(target, e) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const year = $(ipl).find("[year]").getSelectedValue();
        const month = $(ipl).find("[month]").getSelectedValue();
        const date = new DateTime(year + "/" + month + "/01");
        const nextMonth = date.addMonth(1);
        const lastDayOfMonth = nextMonth.addDay(-1);
        const day = lastDayOfMonth.day;
        const dl = $(ipl).find("[day]").getFirstElement();
        $(dl).setInnerHtml("");
        for (var i = 1; i <= day; i++) {
            let option = document.createElement("option");
            $(option).setAttribute("value", i.toString());
            let day = i.toString();
            if (day.length == 1) {
                day = "0" + day;
            }
            $(option).setInnerText(day);
            dl.appendChild(option);
        }
        $(dl).setSelectedValue("1");
    }
    dateDrowDownList_Keydown(target, e) {
        if (e.shiftKey == true || e.ctrlKey == true || e.altKey == true) {
            return;
        }
        let x = -1;
        if (e.keyCode >= 48 && e.keyCode < 58) {
            x = e.keyCode - 48;
        }
        if (e.keyCode >= 96 && e.keyCode < 106) {
            x = e.keyCode - 96;
        }
        if (x > -1) {
            let v = $(target).getAttribute("key-input-value") + x.toString();
            if ($(target).getAttribute("year") == "true") {
                if (v.length > 4) {
                    v = v.substr(v.length - 4, 4);
                }
            }
            else if ($(target).getAttribute("month") == "true") {
                v = v.substr(v.length - 2, 2);
                if (v.substr(0, 1) == "0") {
                    v = v.substr(1, 1);
                }
                if (parseInt(v) > 12) {
                    v = v.substr(1, 1);
                }
            }
            else if ($(target).getAttribute("day") == "true") {
                v = v.substr(v.length - 2, 2);
                if (v.substr(0, 1) == "0") {
                    v = v.substr(1, 1);
                }
                if (parseInt(v) > 31) {
                    v = v.substr(1, 1);
                }
            }
            $(target).setSelectedValue(v);
            $(target).setAttribute("key-input-value", v);
            e.preventDefault();
        }
    }
    radioButtonLabel_Click(target, e) {
        $(target).getNearest("input[type='radio']").setChecked(true).triggerEvent("change");
    }
    checkBoxLabel_Click(target, e) {
        $(target).getNearest("input[type='checkbox']").toggleChecked().triggerEvent("change");
    }
    filterTextBox_Keydown(target, e) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const text = $(target).getValue();
        if (text == "") {
            $(ipl).find("[filter-text]").removeClass("display-none");
        }
        else {
            $(ipl).find("[filter-text]").addClass("display-none");
            $(ipl).find("[filter-text*='" + text + "']").removeClass("display-none");
        }
    }
    selectRecordPanel_Click(target, e) {
        this.showSearchRecordListPanel(target);
    }
    selectRecordPanel_Keydown(target, e) {
        if (e.keyCode == 13) {
            this.showSearchRecordListPanel(target);
        }
        else if (e.keyCode == 46) {
            this.deleteRecord($(target).find("[h-record]").getFirstElement());
        }
    }
    showSearchRecordListPanel(target) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const spl = $(target).getNearestElement("[search-record-list-panel]");
        if ($(spl).hasClass("slide-down") == true) {
            this.closeSearchRecordListPanel(target);
        }
        else {
            this.selectTab(ipl, "Search");
            $(spl).addClass("slide-down");
            $(target).getNearest("[search-textbox]").setFocus();
            this.search(target);
        }
    }
    deleteLink_Click(target, e) {
        this.deleteRecord(target);
        e.preventDefault();
    }
    deleteLink_Keydown(target, e) {
        if (e.keyCode == 13) {
            const pl = $(target).getParent("[h-record]").getFirstElement();
            let focusElement = pl.nextElementSibling;
            if (focusElement == null) {
                focusElement = pl.previousElementSibling;
            }
            if (focusElement != null) {
                $(focusElement).find("[delete-link]").setFocus();
            }
            this.deleteRecord(target);
        }
    }
    deleteRecord(target) {
        const pl = $(target).getParent("[h-record]").getFirstElement();
        const elementType = $(target).getParentAttribute("element-type");
        if (elementType == "Record") {
            const rpl = $(target).getNearestElement("[select-record-panel]");
            $(rpl).setInnerHtml("");
            const span = document.createElement("span");
            $(span).setInnerText(rpl.getAttribute("default-text"));
            rpl.appendChild(span);
            $(rpl).setFocus();
        }
        if (pl != null) {
            pl.remove();
        }
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        this.recordChanged(ipl);
    }
    addRecordButton_Click(target, e) {
        const ipl = $(target).getParent("[input-property-panel]");
        const mode = $(ipl).find("[search-record-list-panel]").getAttribute("add-record-mode");
        switch (mode) {
            case "None":
                this.setDefaultRecord(ipl.getFirstElement(), {});
                break;
            case "Search":
                $(target).getParent("[button-list-panel]").hide();
                this.showSearchRecordListPanel(target);
                break;
            case "Api":
                const apiPath = ipl.find("[search-record-list-panel]").getAttribute("api-path-default-get");
                HttpClient.postJson(apiPath, {}, this.getDefaultRecordCallback.bind(this), null, ipl.getFirstElement());
                break;
            default:
        }
    }
    setDefaultRecord(inputPropertyPanel, record) {
        const r = record;
        const ipl = inputPropertyPanel;
        const rpl = $(ipl).find("[select-record-list-panel]").getFirstElement();
        const templateID = $(ipl).find("[search-record-list-panel]").getAttribute("template-id");
        const element = HigLaboVue.append(rpl, templateID, r)[0];
        if ($(element).getAttribute("header-mode") == "Label") {
            $(element).setAttribute("toggle-state", "Expand");
        }
        var key = $(element).getAttribute("h-key");
        InputPropertyPanel.setElementProperty(element, r, key);
        $(element).find("input[type='text']").setFocus();
        this.recordChanged(ipl);
    }
    getDefaultRecordCallback(response, inputPropertyPanel) {
        const r = response.jsonParse();
        this.setDefaultRecord(inputPropertyPanel, r);
    }
    recordChanged(inputPropertyPanel) {
        const e = new RecordChangedEvent(inputPropertyPanel);
        for (var i = 0; i < this._eventHandlerList.length; i++) {
            try {
                var f = this._eventHandlerList[i];
                f(this, e);
            }
            catch (_a) {
            }
        }
    }
    searchButton_Click(target, e) {
        this.search(target);
    }
    searchTextBox_Keydown(target, e) {
        const pl = $(target).getNearest("[search-record-list-panel]");
        const currentElement = pl.find("[current]").getFirstElement();
        let targetElement = null;
        if (e.keyCode == 27) {
            this.closeSearchRecordListPanel(target);
            $(target).getParent("[input-property-panel]").find("[select-record-panel]").setFocus();
            return;
        }
        if (e.keyCode == 13) {
            if (currentElement == null) {
                this.search(target);
                return;
            }
            else {
                targetElement = currentElement.nextElementSibling;
                if (targetElement == null) {
                    targetElement = currentElement.previousElementSibling;
                }
                const selected = this.selectRecord(currentElement);
                if (selected == false) {
                    return;
                }
            }
        }
        const elementList = pl.find("[h-record]").getElementList();
        if (elementList.length == 0) {
            return;
        }
        if (e.keyCode == 8) {
            targetElement = null;
        }
        else if (e.keyCode == 38) {
            if (currentElement == null) {
                targetElement = elementList[elementList.length - 1];
            }
            else {
                currentElement.removeAttribute("current");
                targetElement = currentElement.previousSibling;
            }
        }
        else if (e.keyCode == 40) {
            const currentElement = pl.find("[current]").getFirstElement();
            if (currentElement == null) {
                targetElement = elementList[0];
            }
            else {
                currentElement.removeAttribute("current");
                targetElement = currentElement.nextElementSibling;
            }
        }
        if (targetElement == null) {
            pl.find("[current]").removeAttribute("current");
        }
        else {
            const rpl = pl.find("[record-list-panel]");
            const parentOffset = rpl.getOffset();
            const scrollTop = rpl.getScrollTop();
            const offset = $(targetElement).getOffset();
            rpl.setScrollTop((offset.top) - (parentOffset.top - scrollTop) - (rpl.getOuterHeight() / 2) + 40);
        }
        $(targetElement).setAttribute("current", "true");
    }
    search(target) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const pl = $(ipl).find("[search-record-list-panel]").getFirstElement();
        const url = $(pl).getAttribute("api-path-search");
        let p = null;
        try {
            p = JSON.parse($(pl).getAttribute("api-parameter"));
        }
        catch (_a) { }
        if (p == null) {
            p = {};
        }
        p.SearchText = $(pl).find("[search-textbox]").getValue();
        HttpClient.postJson(url, p, this.searchCallback.bind(this), null, pl);
    }
    searchCallback(response, panel) {
        const data = response.jsonParse();
        const pl = panel;
        const ipl = $(panel).getParent("[input-property-panel]").getFirstElement();
        const recordListPanel = $(pl).find("[tab-name='Search'] [record-list-panel]").getFirstElement();
        const templateID = $(ipl).find("[search-record-list-panel]").getAttribute("search-template-id");
        $(recordListPanel).setInnerHtml("");
        for (var i = 0; i < data.Data.length; i++) {
            HigLaboVue.append(recordListPanel, templateID, data.Data[i]);
        }
    }
    record_Click(target, e) {
        this.selectRecord(target);
    }
    selectRecord(target) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const name = $(ipl).getAttribute("h-record-list");
        const elementType = $(ipl).getAttribute("element-type");
        const mode = $(ipl).find("[search-record-list-panel]").getAttribute("select-record-mode");
        const rpl = $(target).getFirstElement();
        switch (mode) {
            case "Html":
                if (elementType == "Record") {
                    const spl = $(ipl).find("[select-record-panel]").getFirstElement();
                    $(spl).setInnerHtml("");
                    spl.appendChild(rpl);
                    $(spl).setFocus();
                    this.closeSearchRecordListPanel(target);
                }
                else if (elementType == "RecordList") {
                    const spl = $(ipl).find("[select-record-list-panel]").getFirstElement();
                    const hKey = $(rpl).getAttribute("h-key");
                    if ($(spl).find("[h-key='" + hKey + "']").getElementCount() > 0) {
                        return false;
                    }
                    spl.appendChild(rpl);
                    spl.scrollTop = 20000;
                }
                break;
            case "Template":
                const templateID = $(ipl).find("[search-record-list-panel]").getAttribute("template-id");
                if (elementType == "Record") {
                    const spl = $(ipl).find("[select-record-panel]").getFirstElement();
                    $(rpl).setInnerHtml("");
                    const r = InputPropertyPanel.createRecord(rpl);
                    const pl = HigLaboVue.append(spl, templateID, r)[0];
                    InputPropertyPanel.setElementProperty(pl, r, "");
                    $(spl).setFocus();
                    this.closeSearchRecordListPanel(target);
                }
                else if (elementType == "RecordList") {
                    const spl = $(ipl).find("[select-record-list-panel]").getFirstElement();
                    const hKey = $(rpl).getAttribute("h-key");
                    if ($(spl).find("[h-key='" + hKey + "']").getElementCount() > 0) {
                        return false;
                    }
                    const r = InputPropertyPanel.createRecord(rpl);
                    const pl = HigLaboVue.append(spl, templateID, r)[0];
                    InputPropertyPanel.setElementProperty(pl, r, "");
                    $(pl).setAttribute("toggle-state", "Expand");
                    InputPropertyPanel.setRadioButtonProperty(pl, name, hKey);
                    const checkBoxList = $(pl).find("input[type='checkbox']").getElementList();
                    for (var i = 0; i < checkBoxList.length; i++) {
                    }
                    spl.scrollTop = 20000;
                }
                break;
            default:
        }
        this.recordChanged(ipl);
        return true;
    }
    sortButton_Click(target, e) {
        this.sort(target);
    }
    sort(button) {
        const rpl = $(button).getNearest("[select-record-list-panel]").getFirstElement();
        $(rpl).find("[h-record]").setAttribute("sort-record", "true");
        HigLaboVue.insertBefore(rpl.children[0], "SortLinePanelTemplate", { Text: $(button).getValue() });
        $(rpl).getNearest("[sort-button]").hide();
    }
    sortRecord_Click(target, e) {
        const rpl = $(target).getParent("[select-record-list-panel]").getFirstElement();
        const linePanel = $(rpl).find("[sort-line-panel]").getFirstElement();
        rpl.insertBefore(target, linePanel);
        $(target).removeAttribute("sort-record");
        if ($(rpl).find("[sort-record]").getElementCount() == 0) {
            linePanel.remove();
            $(rpl).getNearest("[sort-button]").removeStyle("display");
        }
        e.preventDefault();
    }
    closeButton_Click(target, e) {
        this.closeSearchRecordListPanel(target);
    }
    closeSearchRecordListPanel(target) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const spl = $(ipl).find("[search-record-list-panel]");
        $(spl).removeClass("slide-down");
        const bt = $(ipl).find("[add-record-button]").getFirstElement();
        if (bt == null) {
            $(ipl).find("[select-record-panel]").setFocus();
        }
        else {
            $(ipl).find("[button-list-panel]").removeStyle("display");
            $(bt).setFocus();
        }
    }
    editRecordPanelTextBox_Keyup(target, e) {
        const text = $(target).getValue();
        $(target).getNearest("[header-text]").setInnerText(text);
    }
    toggleContentPanel_Keydown(target, e) {
        if (e.keyCode == 13) {
            $(target).getParent("[h-record]").toggleAttributeValue("toggle-state", "Expand", "Collapse");
        }
    }
    toggleContentPanel_Click(target, e) {
        if ($(target).getParentAttribute("can-toggle") == "false") {
            return;
        }
        $(target).getParent("[h-record]").toggleAttributeValue("toggle-state", "Expand", "Collapse");
    }
    headerText_Keydown(target, e) {
        if (e.keyCode == 46) {
            this.deleteCandidate(target);
        }
    }
    deleteCandidateLink_Click(target, e) {
        this.deleteCandidate(target);
    }
    deleteCandidate(target) {
        $(target).getParent("[h-record]").toggleAttributeValue("is-delete", "true", "false");
        const v = $(target).getParent("[h-record]").getAttribute("is-delete");
        $(target).getParent("[h-record]").find("input[h-name='IsDelete']").setValue(v);
    }
    tabName_Click(target, e) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const tabName = $(target).getAttribute("tab-name");
        this.selectTab(ipl, tabName);
    }
    selectTab(inputPropertyPanel, tabName) {
        const ipl = inputPropertyPanel;
        const spl = $(ipl).find("[search-record-list-panel]").getFirstElement();
        const pl = $(ipl).find("[tab-header-list-panel]").getFirstElement();
        $(pl).find("[tab-name]").removeClass("selected");
        const selectedTabHeaderPanel = $(pl).find("[tab-name='" + tabName + "']");
        selectedTabHeaderPanel.addClass("selected");
        $(spl).find("[tab-panel][tab-name]").hide();
        const tabPanel = $(spl).find("[tab-panel][tab-name='" + tabName + "']").getFirstElement();
        $(tabPanel).removeStyle("display");
        const apiPath = $(selectedTabHeaderPanel).getAttribute("api-path");
        if (apiPath != "") {
            const p = JSON.parse($(selectedTabHeaderPanel).getAttribute("api-parameter"));
            HttpClient.postJson(apiPath, p, this.tabApiPathCallback.bind(this), null, tabPanel);
        }
    }
    tabApiPathCallback(response, tabPanel) {
        const result = response.getWebApiResult();
        const pl = $(tabPanel).find("[record-list-panel]").getFirstElement();
        const templateID = $(tabPanel).getAttribute("template-id");
        $(pl).setInnerHtml("");
        for (var i = 0; i < result.Data.length; i++) {
            let r = result.Data[i];
            HigLaboVue.append(pl, templateID, r);
        }
    }
    createRecordButton_Click(target, e) {
        const ipl = $(target).getFirstParent("[input-property-panel]").getFirstElement();
        const spl = $(target).getFirstParent("[search-record-list-panel]").getFirstElement();
        let r = InputPropertyPanel.createRecord($(spl).find("[create-record-panel]").getFirstElement());
        const apiPath = $(target).getAttribute("api-path");
        if (apiPath == "") {
            this.setCreatedRecord(ipl, r);
        }
        else {
            HttpClient.postJson(apiPath, r, this.createRecordCallback.bind(this), null, target);
        }
    }
    createRecordCallback(response, button) {
        const result = response.getWebApiResult();
        const ipl = $(button).getFirstParent("[input-property-panel]").getFirstElement();
        this.setCreatedRecord(ipl, result.Data);
        this.closeSearchRecordListPanel(button);
    }
    setCreatedRecord(inputPropertyPanel, data) {
        const ipl = inputPropertyPanel;
        const elementType = $(ipl).getAttribute("element-type");
        if (elementType == "Record") {
            InputPropertyPanel.setRecord(ipl, data);
        }
        else if (elementType == "RecordList") {
            InputPropertyPanel.appendRecordList(ipl, [data]);
        }
        $(ipl).find("[create-record-panel] input").setValue("");
    }
    searchByTextButton_Click(target, e) {
        const spl = $(target).getFirstParent("[search-record-list-panel]").getFirstElement();
        const apiPath = $(target).getAttribute("api-path");
        let p = JSON.parse($(spl).getAttribute("api-parameter"));
        p.SearchText = $(target).getNearest("[search-text-list-textbox]").getValue();
        HttpClient.postJson(apiPath, p, this.searchByTextCallback.bind(this), null, target);
    }
    searchByTextCallback(response, button) {
        const ipl = $(button).getFirstParent("[input-property-panel]").getFirstElement();
        this.setSelectedRecordList(response, ipl);
    }
    tabPanelRecord_Click(target, e) {
        const tabPanel = $(target).getFirstParent("[tab-panel]").getFirstElement();
        const apiPath = $(tabPanel).getAttribute("api-path");
        const p = InputPropertyPanel.createRecord(target);
        HttpClient.postJson(apiPath, p, this.tabPanelRecordCallback.bind(this), null, tabPanel);
    }
    tabPanelRecordCallback(response, tabPanel) {
        const ipl = $(tabPanel).getFirstParent("[input-property-panel]").getFirstElement();
        this.setSelectedRecordList(response, ipl);
    }
    setSelectedRecordList(response, inputPropertyPanel) {
        const result = response.getWebApiResult();
        const ipl = inputPropertyPanel;
        const templateID = $(ipl).find("[search-record-list-panel]").getAttribute("template-id");
        const spl = $(ipl).find("[select-record-list-panel]").getFirstElement();
        for (var i = 0; i < result.Data.length; i++) {
            let r = result.Data[i];
            let ee = HigLaboVue.create(templateID, r);
            for (var eIndex = 0; eIndex < ee.length; eIndex++) {
                let hKey = $(ee[eIndex]).getAttribute("h-key");
                if ($(spl).find("[h-key='" + hKey + "']").getElementCount() > 0) {
                    continue;
                }
                spl.appendChild(ee[eIndex]);
            }
        }
    }
    static createRecord(recordElement) {
        let record = {};
        const propertyPanelList = new Array();
        this.findChildNodes(recordElement, propertyPanelList);
        var name = "";
        for (var i = 0; i < propertyPanelList.length; i++) {
            let propertyPanel = propertyPanelList[i];
            name = $(propertyPanel).getAttribute("h-record-list");
            if (name != "" && record[name] == null) {
                record[name] = this.createRecordList(propertyPanel);
                continue;
            }
            name = $(propertyPanel).getAttribute("h-record");
            if (name != "" && record[name] == null) {
                let r = this.createRecord(propertyPanel);
                record[name] = r;
                continue;
            }
            name = $(propertyPanel).getAttribute("h-name");
            if (name != "" && record[name] == null) {
                InputPropertyPanel.setRecordProperty(record, propertyPanel);
            }
        }
        return record;
    }
    static setRecordProperty(record, propertyPanel) {
        let name = $(propertyPanel).getAttribute("h-name");
        {
            let hRecord = $(propertyPanel).find("[h-record]").getFirstElement();
            if (hRecord != null) {
                record[name] = InputPropertyPanel.createRecord(hRecord);
                return;
            }
        }
        {
            const textarea = $(propertyPanel).find("textarea").getFirstElement();
            if (textarea != null) {
                if (textarea.richTextbox instanceof CKEditorTextBox) {
                    record[name] = textarea.richTextbox.getData();
                }
                else if (textarea.richTextbox instanceof TinyMceTextBox) {
                    record[name] = textarea.richTextbox.getInnerHtml();
                }
                else {
                    record[name] = $(textarea).getValue();
                }
            }
        }
        if ($(propertyPanel).getAttribute("element-type") == "DateDropDownList") {
            const year = $(propertyPanel).find("[year]").getSelectedValue();
            const month = $(propertyPanel).find("[month]").getSelectedValue();
            const day = $(propertyPanel).find("[day]").getSelectedValue();
            if (year != "" && month != "" && day != "") {
                record[name] = year + "/" + month + "/" + day;
            }
        }
        if ($(propertyPanel).getAttribute("element-type") == "DropDownList") {
            const dl = $(propertyPanel).find("select").getFirstElement();
            if (dl != null) {
                record[name] = $(dl).getValue();
                return;
            }
        }
        {
            const radioButtonList = $(propertyPanel).find("input[type='radio']").getElementList();
            for (var i = 0; i < radioButtonList.length; i++) {
                let rb = $(radioButtonList[i]);
                if (rb.isChecked()) {
                    record[name] = rb.getValue();
                    return;
                }
            }
            if (radioButtonList.length > 0) {
                return;
            }
        }
        {
            let element = $(propertyPanel).find("input").getFirstElement();
            if (element == null) {
                if (propertyPanel.tagName.toUpperCase() == "INPUT") {
                    element = propertyPanel;
                }
            }
            if (element == null) {
                return;
            }
            let control = $(element);
            switch (control.getAttribute("type")) {
                case "text":
                case "password":
                case "hidden":
                    {
                        let v = control.getValue();
                        if (v != null) {
                            record[name] = v;
                        }
                    }
                    break;
                case "radio":
                    {
                        if (control.isChecked()) {
                            record[name] = control.getValue();
                        }
                    }
                    break;
                case "checkbox":
                    {
                        record[name] = control.isChecked();
                    }
                    break;
                default:
            }
        }
    }
    static createRecordList(recordListElement) {
        const rr = new Array();
        const recordList = $(recordListElement).find("[h-record]").getElementList();
        for (var i = 0; i < recordList.length; i++) {
            var recordPanel = recordList[i];
            if ($(recordPanel).getParent("[h-record-list]").getFirstElement() != recordListElement) {
                continue;
            }
            if ($(recordPanel).getParent("[search-record-list-panel]").getElementCount() > 0) {
                continue;
            }
            if ($(recordPanel).getParent("[input-property-panel][element-type='Record']").getElementCount() > 0) {
                continue;
            }
            let r = InputPropertyPanel.createRecord(recordPanel);
            rr.push(r);
        }
        return rr;
    }
    static findChildNodes(element, elementList) {
        const childList = $(element).getChildElementList();
        for (var i = 0; i < childList.length; i++) {
            var child = childList[i];
            if ($(child).getAttribute("[search-record-list-panel]") != "") {
                continue;
            }
            if ($(child).hasAttribute("h-name") ||
                $(child).hasAttribute("h-record") ||
                $(child).hasAttribute("h-record-list")) {
                elementList.push(child);
            }
            else {
                InputPropertyPanel.findChildNodes(child, elementList);
            }
        }
        return elementList;
    }
    static setElementProperty(recordElement, record, key) {
        const zeroPad2Digits = new Intl.NumberFormat('ja', { minimumIntegerDigits: 2 });
        const propertyList = Object.getOwnPropertyNames(record);
        for (var i = 0; i < propertyList.length; i++) {
            var name = propertyList[i];
            let v = record[name];
            let propertyPanel = $(recordElement).find("[h-name='" + name + "'],[h-record='" + name + "'],[h-record-list='" + name + "']");
            let elementType = propertyPanel.getAttribute("element-type");
            if (elementType == "Color") {
                propertyPanel.find("input").setValue(v);
                propertyPanel.find("[color-panel]").setStyle("background-color", v);
            }
            else if (elementType == "CheckBox") {
                if (key != "") {
                }
                propertyPanel.find("input").setChecked(v);
            }
            else if (elementType == "CheckBoxList") {
                const vv = v;
                for (var vIndex = 0; vIndex < vv.length; vIndex++) {
                    let hidden = propertyPanel.find("input[h-name='Value'][value='" + vv[vIndex].Value + "']").getFirstElement();
                    if (hidden == null) {
                        continue;
                    }
                    $(hidden.parentElement).find("input[type='checkbox']").setChecked(vv[vIndex].Checked);
                }
            }
            else if (elementType == "SelectButton" || elementType == "RadioButtonList") {
                if (key != "") {
                    InputPropertyPanel.setRadioButtonProperty(propertyPanel.getFirstElement(), name, key);
                }
                propertyPanel.find("input[type=radio][value='" + v + "']").setChecked(true);
            }
            else if (elementType == "Date") {
                if (v != null) {
                    if (v.Year != null && v.Month != null && v.Day != null) {
                        v = new DateTime(v.Year + "/" + v.Month + "/" + v.Day).toString("yyyy/MM/dd");
                        $(propertyPanel).find("[date-picker]").setValue(v);
                    }
                    else if (v.length > 10) {
                        v = v.replace(/-/g, "/").substr(0, 10);
                        $(propertyPanel).find("[date-picker]").setValue(v);
                    }
                    else {
                        $(propertyPanel).find("[date-picker]").setValue(v);
                    }
                }
            }
            else if (elementType == "DateDropDownList") {
                if (v != null) {
                    if (v.Year != null && v.Month != null && v.Day != null) {
                        $(propertyPanel).find("[year]").setSelectedValue(v.Year);
                        $(propertyPanel).find("[month]").setSelectedValue(v.Month);
                        $(propertyPanel).find("[day]").setSelectedValue(v.Day);
                    }
                    else {
                        v = v.replace(/-/g, "/");
                        if (v.length > 10) {
                            v = v.substr(0, 10);
                        }
                        const date = DateTime.TryCreate(v);
                        if (date != null) {
                            $(propertyPanel).find("[year]").setSelectedValue(date.year.toString());
                            $(propertyPanel).find("[month]").setSelectedValue(date.month.toString());
                            $(propertyPanel).find("[day]").setSelectedValue(date.day.toString());
                        }
                    }
                }
            }
            else if (elementType == "Time") {
                if (v != null) {
                    if (v.Hour != null && v.Minute != null && v.Second != null) {
                        v = zeroPad2Digits.format(v.Hour) + ":" + zeroPad2Digits.format(v.Minute) + ":" + zeroPad2Digits.format(v.Second);
                    }
                    else if (v.length > 5) {
                        v = v.replace(/-/g, "/").substr(0, 5);
                    }
                    $(propertyPanel).find("input").setValue(v);
                }
            }
            else if (elementType == "DateTime") {
                if (v != null) {
                    if (v.Date != "") {
                        $(propertyPanel).find("[date-picker]").setValue(v.Date);
                    }
                    if (v.HourMinute != "") {
                        $(propertyPanel).find("[time-picker]").setValue(v.HourMinute);
                    }
                }
            }
            else if (elementType == "TimeDuration" ||
                elementType == "DateDuration" ||
                elementType == "DateTimeDuration") {
                InputPropertyPanel.setElementProperty(propertyPanel.getFirstElement(), v, "");
            }
            else if (elementType == "DropDownList") {
                propertyPanel.find("select").setValue(v);
            }
            else if (elementType == "Record") {
                InputPropertyPanel.setRecord(propertyPanel.getFirstElement(), v);
            }
            else if (elementType == "RecordList") {
                InputPropertyPanel.setRecordList(propertyPanel.getFirstElement(), v);
            }
            else {
                let element = propertyPanel.getFirstElement();
                if (element == null) {
                    continue;
                }
                var textarea = propertyPanel.find("textarea").getFirstElement();
                if (textarea != null) {
                    InputPropertyPanel.setTextArea(textarea, v);
                }
                else {
                    if (element.tagName.toLowerCase() == "input" && element.attributes["type"] != "file") {
                        $(element).setValue(v);
                    }
                    else if ($(propertyPanel).getAttribute("h-record-list") == "") {
                        let input = propertyPanel.find("input").getFirstElement();
                        switch ($(input).getAttribute("type").toLowerCase()) {
                            case "radio":
                            case "checkbox":
                                $(input).setChecked(v);
                                $(input).triggerEvent("change");
                                break;
                            default:
                                $(input).setValue(v);
                                break;
                        }
                    }
                }
            }
        }
    }
    clearElementProperty(element) {
        const zeroPad2Digits = new Intl.NumberFormat('ja', { minimumIntegerDigits: 2 });
        const propertyPanelList = $(element).find("[input-property-panel][h-name],[input-property-panel][h-record],[input-property-panel][h-record-list]").getElementList();
        const v = "";
        for (var i = 0; i < propertyPanelList.length; i++) {
            var propertyPanel = $(propertyPanelList[i]);
            let name = "";
            name = $(propertyPanel).getAttribute("h-name");
            if (name == "") {
                name = $(propertyPanel).getAttribute("h-record");
            }
            if (name == "") {
                name = $(propertyPanel).getAttribute("h-record-list");
            }
            let elementType = propertyPanel.getAttribute("element-type");
            if (elementType == "Color") {
                propertyPanel.find("input").setValue(v);
                propertyPanel.find("[color-panel]").setStyle("background-color", v);
            }
            else if (elementType == "CheckBox") {
                propertyPanel.find("input").setChecked(false);
            }
            else if (elementType == "CheckBoxList") {
                $(propertyPanel).find("input[type='checkbox']").setChecked(false);
            }
            else if (elementType == "SelectButton" || elementType == "RadioButtonList") {
                propertyPanel.find("input[type=radio]").setChecked(false);
            }
            else if (elementType == "Date") {
                $(propertyPanel).find("[date-picker]").setValue(v);
            }
            else if (elementType == "DateDropDownList") {
            }
            else if (elementType == "Time") {
                $(propertyPanel).find("input").setValue(v);
            }
            else if (elementType == "DateTime" ||
                elementType == "TimeDuration" ||
                elementType == "DateDuration" ||
                elementType == "DateTimeDuration") {
                $(propertyPanel).find("[date-picker]").setValue(v);
                $(propertyPanel).find("[time-picker]").setValue(v);
            }
            else if (elementType == "DropDownList") {
                propertyPanel.find("select").setValue(v);
            }
            else if (elementType == "Record") {
                this.deleteRecord(propertyPanel.find("[select-record-panel] [delete-link]").getFirstElement());
            }
            else if (elementType == "RecordList") {
                propertyPanel.find("[select-record-list-panel]").setInnerHtml("");
            }
            else {
                let element = propertyPanel.getFirstElement();
                if (element == null) {
                    continue;
                }
                var textarea = propertyPanel.find("textarea").getFirstElement();
                if (textarea != null) {
                    InputPropertyPanel.setTextArea(textarea, v);
                }
                else {
                    if (element.tagName.toLowerCase() == "input" && element.attributes["type"] != "file") {
                        $(element).setValue(v);
                    }
                    else {
                        let input = propertyPanel.find("input").getFirstElement();
                        switch ($(input).getAttribute("type").toLowerCase()) {
                            case "radio":
                            case "checkbox":
                                $(input).setChecked(false);
                                $(input).triggerEvent("change");
                                break;
                            default:
                                $(input).setValue(v);
                                break;
                        }
                    }
                }
            }
        }
    }
    static setRadioButtonProperty(element, name, key) {
        const radioButtonList = $(element).find("input[type='radio']").getElementList();
        for (var i = 0; i < radioButtonList.length; i++) {
            var rb = radioButtonList[i];
            var rbValue = $(rb).getValue();
            var hName = $(rb).getParentAttribute("h-name");
            var rName = name + "_" + key + "_" + hName;
            $(rb).setAttribute("name", rName);
            $(rb).setAttribute("id", rName + "_" + rbValue);
            $(rb).getNearest("label").setAttribute("for", rName + "_" + rbValue);
        }
    }
    static setCheckBoxProperty(element, name, key) {
        const hName = $(element).getAttribute("h-name");
        const id = "CheckBox_" + name + "_" + key + "_" + hName;
        $(element).find("input[type='checkbox']").setAttribute("id", id);
        $(element).find("label").setAttribute("for", id);
    }
    static setTextArea(element, value) {
        let v = value;
        if (v == null) {
            v = "";
        }
        const textarea = element;
        if (textarea.richTextbox instanceof CKEditorTextBox) {
            textarea.richTextbox.setData(v);
        }
        else if (textarea.richTextbox instanceof TinyMceTextBox) {
            textarea.richTextbox.setContent(v);
        }
        else {
            $(textarea).setValue(v);
        }
    }
    static setRecord(inputPropertyPanel, record) {
        if (record == null) {
            return;
        }
        const selectRecordPanel = $(inputPropertyPanel).find("[select-record-panel]");
        const templateID = $(inputPropertyPanel).find("[search-record-list-panel]").getAttribute("template-id");
        $(selectRecordPanel).setInnerHtml("");
        HigLaboVue.append(selectRecordPanel.getFirstElement(), templateID, record);
    }
    static setRecordList(inputPropertyPanel, recordList) {
        this.setRecordListToPanel(inputPropertyPanel, recordList, true);
    }
    static appendRecordList(inputPropertyPanel, recordList) {
        this.setRecordListToPanel(inputPropertyPanel, recordList, false);
    }
    static setRecordListToPanel(inputPropertyPanel, recordList, isClearInnerHtml) {
        const recordListPanel = $(inputPropertyPanel).find("[select-record-list-panel]").getFirstElement();
        if (isClearInnerHtml == true) {
            $(recordListPanel).setInnerHtml("");
        }
        if (recordListPanel == null) {
            return;
        }
        const templateID = $(inputPropertyPanel).find("[search-record-list-panel]").getAttribute("template-id");
        for (var i = 0; i < recordList.length; i++) {
            var element = HigLaboVue.append(recordListPanel, templateID, recordList[i])[0];
            var key = $(element).getAttribute("h-key");
            InputPropertyPanel.setElementProperty(element, recordList[i], key);
        }
    }
    static setValidationResult(element, validationResultList) {
        const vv = validationResultList;
        $(element).find("[h-validation-name]").removeClass("fadein");
        setTimeout(function () {
            for (var i = 0; i < vv.length; i++) {
                let vr = vv[i];
                let pl = $("[h-validation-name='" + vr.Name + "']");
                pl.find("[text-panel]").setInnerText(vr.Message);
                if (vr.Name == "TimeStamp") {
                    $("[input-property-panel][h-name='TimeStamp'] input[type='hidden']").setValue(vr.Value);
                }
                pl.addClass("fadein");
            }
        }, 10);
    }
}
export class ValidationResult {
}
export class RecordChangedEvent {
    constructor(inputPropertyPanel) {
        this.InputPropertyPanel = inputPropertyPanel;
    }
}
//# sourceMappingURL=InputPropertyPanel.js.map