import { DateTime } from "./DateTime.js";
import { $ } from "./HtmlElementQuery.js";
import { HigLaboVue } from "./HigLaboVue.js";
import { HttpClient } from "./HttpClient.js";
import SelectTimePopupPanel from "./SelectTimePopupPanel.js";
var InputPropertyPanel = (function () {
    function InputPropertyPanel() {
        this.selectTimePopupPanel = new SelectTimePopupPanel();
    }
    InputPropertyPanel.prototype.initialize = function () {
        this.selectTimePopupPanel.initialize();
        $("body").on("focusin", "input[date-picker],input[time-picker]", this.dateTimeTextBox_Focusin.bind(this));
        $("body").on("keydown", "input[date-picker]", this.dateTextBox_Keydown.bind(this));
        $("body").on("keydown", "input[time-picker]", this.timeTextBox_Keydown.bind(this));
        $("body").on("keydown", "[input-property-panel][element-type='Color'] input[type=text]", this.colorTextBox_Keydown.bind(this));
        $("body").on("keyup", "[input-property-panel][element-type='Color'] input[type=text]", this.colorTextBox_Keyup.bind(this));
        $("body").on("click", "[input-property-panel][element-type='Color'] [color-panel]", this.colorPanel_Click.bind(this));
        $("body").on("click", "[input-property-panel][element-type='Color'] td[color]", this.colorCell_Click.bind(this));
        $("body").on("keydown", "[input-property-panel][element-type='Color'] td[color]", this.colorCell_Keydown.bind(this));
        $("body").on("change", "[input-property-panel] [set-by-end-time]", this.dateTimeDurationList_Change.bind(this));
        $("body").on("click", "[input-property-panel]  [radio-button-label]", this.radioButtonLabel_Click.bind(this));
        $("body").on("click", "[input-property-panel]  [checkbox-label]", this.checkBoxLabel_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [delete-link]", this.deleteLink_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [delete-link]", this.deleteLink_Click.bind(this));
        $("body").on("click", "[input-property-panel] [add-record-button]", this.addRecordButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-panel]", this.selectRecordPanel_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-panel]", this.selectRecordPanel_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [search-button]", this.searchButton_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [search-textbox]", this.searchTextBox_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [record-list-panel] [h-record]", this.record_Click.bind(this));
        $("body").on("click", "[input-property-panel] [sort-button]", this.sortButton_Click.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [sort-record]", this.sortRecord_Click.bind(this));
        $("body").on("click", "[input-property-panel] [close-button]", this.closeButton_Click.bind(this));
        $("body").on("keyup", "[input-property-panel] [select-record-list-panel] [header-text-binding-panel] input[type=text]", this.editRecordPanelTextBox_Keyup.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-list-panel] [toggle-content-panel]", this.toggleContentPanel_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [toggle-content-panel]", this.toggleContentPanel_Click.bind(this));
        $("body").on("keydown", "[input-property-panel] [select-record-list-panel] [delete-candidate-link]", this.deleteCandidateLink_Keydown.bind(this));
        $("body").on("click", "[input-property-panel] [select-record-list-panel] [delete-candidate-link]", this.deleteCandidateLink_Click.bind(this));
    };
    InputPropertyPanel.prototype.dateTimeTextBox_Focusin = function (target, e) {
        $(target).select();
    };
    InputPropertyPanel.prototype.dateTextBox_Keydown = function (target, e) {
        var ftx = target;
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
        var today = DateTime.getToday();
        var date = null;
        if (text.length == 1) {
            date = today.toString("yyyy/MM/") + text;
        }
        else if (text.length == 2) {
            date = today.toString("yyyy/MM/") + text;
        }
        else if (text.length == 3) {
            date = today.toString("yyyy") + "/" + text.substr(0, 1) + "/" + text.substr(1, 2);
        }
        else if (text.length == 4) {
            date = today.toString("yyyy") + "/" + text.substr(0, 2) + "/" + text.substr(2, 2);
        }
        else if (text.length == 5) {
            date = "20" + text.substr(0, 2) + "/" + text.substr(2, 1) + "/" + text.substr(3, 2);
        }
        else if (text.length == 6) {
            date = "20" + text.substr(0, 2) + "/" + text.substr(2, 2) + "/" + text.substr(4, 2);
        }
        else if (text.length == 8) {
            date = text.substr(0, 4) + "/" + text.substr(4, 2) + "/" + text.substr(6, 2);
        }
        if (date == null) {
            return;
        }
        var dateTime = new DateTime(date);
        if (text.length == 1 || text.length == 2) {
            if (dateTime < today) {
                dateTime = today.addMonth(1);
            }
        }
        tx.setValue(dateTime.toString("yyyy/MM/dd"));
    };
    InputPropertyPanel.prototype.timeTextBox_Keydown = function (target, e) {
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
    };
    InputPropertyPanel.prototype.colorTextBox_Keydown = function (target, e) {
        if (e.keyCode == 13) {
            this.showColorTable(target);
        }
    };
    InputPropertyPanel.prototype.colorTextBox_Keyup = function (target, e) {
        $(target).getNearest("[color-panel]").setStyle("background-color", $(target).getValue());
    };
    InputPropertyPanel.prototype.colorPanel_Click = function (target, e) {
        this.showColorTable(target);
    };
    InputPropertyPanel.prototype.showColorTable = function (target) {
        $(target).getNearest("[color-table-panel]").setStyle("display", "block");
        $(target).getNearest("[color-table-panel]").find("td").setFocus();
    };
    InputPropertyPanel.prototype.colorCell_Click = function (target, e) {
        var color = $(target).getAttribute("color");
        this.setColor(target, color);
    };
    InputPropertyPanel.prototype.colorCell_Keydown = function (target, e) {
        var tr = target.parentElement;
        if (e.keyCode == 13) {
            var color = $(target).getAttribute("color");
            this.setColor(target, color);
        }
        else if (e.keyCode == 37) {
            $(target.previousElementSibling).setFocus();
            e.stopPropagation();
        }
        else if (e.keyCode == 38) {
            var index = $(target).getIndex();
            $(tr.previousElementSibling.children[index]).setFocus();
            e.preventDefault();
        }
        else if (e.keyCode == 39) {
            $(target.nextElementSibling).setFocus();
            e.stopPropagation();
        }
        else if (e.keyCode == 40) {
            var index = $(target).getIndex();
            $(tr.nextElementSibling.children[index]).setFocus();
            e.preventDefault();
        }
    };
    InputPropertyPanel.prototype.setColor = function (target, color) {
        $(target).getNearest("[color-panel]").setStyle("background-color", color);
        $(target).getNearest("[color-table-panel]").hide();
        $(target).getNearest("input[type='text']").setValue(color).setFocus().select();
    };
    InputPropertyPanel.prototype.dateTimeDurationList_Change = function (target, e) {
        this.toggleDateTimeDurationList(target);
    };
    InputPropertyPanel.prototype.toggleDateTimeDurationList = function (target) {
        var durationListPanel = $(target).getNearestElement("[duration-list-panel]");
        var durationEndPanel = $(target).getNearestElement("[duration-end-panel]");
        if ($(target).isChecked()) {
            $(durationListPanel).setStyle("display", "none");
            $(durationEndPanel).setStyle("display", "inline");
        }
        else {
            $(durationListPanel).setStyle("display", "inline");
            $(durationEndPanel).setStyle("display", "none");
        }
    };
    InputPropertyPanel.prototype.radioButtonLabel_Click = function (target, e) {
        $(target).getNearest("input[type='radio']").setChecked(true).triggerEvent("change");
    };
    InputPropertyPanel.prototype.checkBoxLabel_Click = function (target, e) {
        $(target).getNearest("input[type='checkbox']").toggleChecked().triggerEvent("change");
    };
    InputPropertyPanel.prototype.selectRecordPanel_Click = function (target, e) {
        this.showSearchRecordListPanel(target);
    };
    InputPropertyPanel.prototype.selectRecordPanel_Keydown = function (target, e) {
        if (e.keyCode == 13) {
            this.showSearchRecordListPanel(target);
        }
    };
    InputPropertyPanel.prototype.deleteLink_Click = function (target, e) {
        this.deleteRecord(target);
        e.preventDefault();
    };
    InputPropertyPanel.prototype.deleteLink_Keydown = function (target, e) {
        if (e.keyCode == 13) {
            var pl = $(target).getParent("[h-record]").getFirstElement();
            var focusElement = pl.nextElementSibling;
            if (focusElement == null) {
                focusElement = pl.previousElementSibling;
            }
            if (focusElement != null) {
                $(focusElement).find("[delete-link]").setFocus();
            }
            this.deleteRecord(target);
        }
    };
    InputPropertyPanel.prototype.deleteRecord = function (target) {
        var pl = $(target).getParent("[h-record]").getFirstElement();
        var elementType = $(target).getParentAttribute("element-type");
        if (elementType == "Record") {
            var rpl = $(target).getNearestElement("[select-record-panel]");
            $(rpl).setInnerHtml("");
            var span = document.createElement("span");
            $(span).setInnerText(rpl.getAttribute("default-text"));
            rpl.appendChild(span);
            $(rpl).setFocus();
        }
        pl.remove();
    };
    InputPropertyPanel.prototype.addRecordButton_Click = function (target, e) {
        var ipl = $(target).getParent("[input-property-panel]");
        var mode = ipl.getAttribute("add-record-mode");
        switch (mode) {
            case "Search":
                $(target).getParent("[button-list-panel]").hide();
                this.showSearchRecordListPanel(target);
                break;
            case "Api":
                var apiPath = ipl.getAttribute("api-path-default-get");
                HttpClient.postJson(apiPath, {}, this.getDefaultRecordCallback.bind(this), null, ipl.getFirstElement());
                break;
            default:
        }
    };
    InputPropertyPanel.prototype.getDefaultRecordCallback = function (response, inputPropertyPanel) {
        var ipl = inputPropertyPanel;
        var templateID = ipl.getAttribute("template-id");
        var rpl = $(ipl).find("[select-record-list-panel]").getFirstElement();
        var r = response.jsonParse();
        var element = HigLaboVue.append(rpl, templateID, r)[0];
        var key = $(element).getAttribute("h-key");
        InputPropertyPanel.setElementProperty(element, r, key);
        this.recordAdded();
    };
    InputPropertyPanel.prototype.recordAdded = function () {
    };
    InputPropertyPanel.prototype.showSearchRecordListPanel = function (target) {
        var pl = $(target).getNearestElement("[search-record-list-panel]");
        $(pl).addClass("slide-down");
        $(target).getNearest("[search-textbox]").setFocus();
        this.search(target);
    };
    InputPropertyPanel.prototype.searchButton_Click = function (target, e) {
        this.search(target);
    };
    InputPropertyPanel.prototype.searchTextBox_Keydown = function (target, e) {
        var pl = $(target).getNearest("[search-record-list-panel]");
        var currentElement = pl.find("[current]").getFirstElement();
        var targetElement = null;
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
                var selected = this.selectRecord(currentElement);
                if (selected == false) {
                    return;
                }
            }
        }
        var elementList = pl.find("[h-record]").getElementList();
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
            var currentElement_1 = pl.find("[current]").getFirstElement();
            if (currentElement_1 == null) {
                targetElement = elementList[0];
            }
            else {
                currentElement_1.removeAttribute("current");
                targetElement = currentElement_1.nextElementSibling;
            }
        }
        if (targetElement == null) {
            pl.find("[current]").removeAttribute("current");
        }
        else {
            var rpl = pl.find("[record-list-panel]");
            var parentOffset = rpl.getOffset();
            var scrollTop = rpl.getScrollTop();
            var offset = $(targetElement).getOffset();
            rpl.setScrollTop((offset.top) - (parentOffset.top - scrollTop) - (rpl.getOuterHeight() / 2) + 40);
        }
        $(targetElement).setAttribute("current", "true");
    };
    InputPropertyPanel.prototype.search = function (target) {
        var pl = $(target).getParent("[api-path-search]");
        var url = $(pl).getAttribute("api-path-search");
        var p = null;
        try {
            p = JSON.parse($(pl).getAttribute("api-parameter"));
        }
        catch (_a) { }
        if (p == null) {
            p = {};
        }
        p.SearchText = $(pl).find("[search-textbox]").getValue();
        HttpClient.postJson(url, p, this.search_Callback.bind(this), null, pl);
    };
    InputPropertyPanel.prototype.search_Callback = function (response, context) {
        var data = response.jsonParse();
        var pl = context;
        var recordListPanel = $(pl).find("[record-list-panel]").getFirstElement();
        var templateID = $(pl).getAttribute("search-template-id");
        $(recordListPanel).setInnerHtml("");
        for (var i = 0; i < data.Data.length; i++) {
            HigLaboVue.append(recordListPanel, templateID, data.Data[i]);
        }
    };
    InputPropertyPanel.prototype.record_Click = function (target, e) {
        this.selectRecord(target);
    };
    InputPropertyPanel.prototype.selectRecord = function (target) {
        var ipl = $(target).getParent("[input-property-panel]");
        var name = $(ipl).getAttribute("h-record-list");
        var elementType = ipl.getAttribute("element-type");
        var mode = ipl.getAttribute("select-record-mode");
        var rpl = $(target).getFirstElement();
        switch (mode) {
            case "Html":
                if (elementType == "Record") {
                    var spl = $(ipl).find("[select-record-panel]").getFirstElement();
                    $(spl).setInnerHtml("");
                    spl.appendChild(rpl);
                    $(spl).setFocus();
                    this.closeSearchRecordListPanel(target);
                }
                else if (elementType == "RecordList") {
                    var spl = $(ipl).find("[select-record-list-panel]").getFirstElement();
                    var hKey = $(rpl).getAttribute("h-key");
                    if ($(spl).find("[h-key='" + hKey + "']").getElementCount() > 0) {
                        return false;
                    }
                    spl.appendChild(rpl);
                    spl.scrollTop = 20000;
                }
                break;
            case "Template":
                var templateID = ipl.getAttribute("template-id");
                if (elementType == "Record") {
                    var spl = $(ipl).find("[select-record-panel]").getFirstElement();
                    $(rpl).setInnerHtml("");
                    var r = InputPropertyPanel.createRecord(rpl);
                    var pl = HigLaboVue.append(spl, templateID, r);
                    $(spl).setFocus();
                    this.closeSearchRecordListPanel(target);
                }
                else if (elementType == "RecordList") {
                    var spl = $(ipl).find("[select-record-list-panel]").getFirstElement();
                    var hKey = $(rpl).getAttribute("h-key");
                    if ($(spl).find("[h-key='" + hKey + "']").getElementCount() > 0) {
                        return false;
                    }
                    var r = InputPropertyPanel.createRecord(rpl);
                    var pl = HigLaboVue.append(spl, templateID, r)[0];
                    InputPropertyPanel.setRadioButtonProperty(pl, name, hKey);
                    var checkBoxList = $(pl).find("input[type='checkbox']").getElementList();
                    for (var i = 0; i < checkBoxList.length; i++) {
                    }
                    spl.scrollTop = 20000;
                }
                break;
            default:
        }
        this.recordAdded();
        return true;
    };
    InputPropertyPanel.prototype.sortButton_Click = function (target, e) {
        var rpl = $(target).getNearest("[select-record-list-panel]").getFirstElement();
        $(rpl).find("[h-record]").setAttribute("sort-record", "true");
        HigLaboVue.insertBefore(rpl.children[0], "SortLinePanelTemplate", { Text: $(target).getValue() });
        $(rpl).getNearest("[sort-button]").hide();
    };
    InputPropertyPanel.prototype.sortRecord_Click = function (target, e) {
        var rpl = $(target).getParent("[select-record-list-panel]").getFirstElement();
        var linePanel = $(rpl).find("[sort-line-panel]").getFirstElement();
        rpl.insertBefore(target, linePanel);
        $(target).removeAttribute("sort-record");
        if ($(rpl).find("[sort-record]").getElementCount() == 0) {
            linePanel.remove();
            $(rpl).getNearest("[sort-button]").removeStyle("display");
        }
        e.preventDefault();
    };
    InputPropertyPanel.prototype.closeButton_Click = function (target, e) {
        this.closeSearchRecordListPanel(target);
    };
    InputPropertyPanel.prototype.closeSearchRecordListPanel = function (target) {
        var rpl = $(target).getNearestElement("[search-record-list-panel]");
        $(rpl).removeClass("slide-down");
        $(target).getNearest("[button-list-panel]").setStyle("display", "initial");
    };
    InputPropertyPanel.prototype.editRecordPanelTextBox_Keyup = function (target, e) {
        var text = $(target).getValue();
        $(target).getNearest("[header-text]").setInnerText(text);
    };
    InputPropertyPanel.prototype.toggleContentPanel_Keydown = function (target, e) {
        if (e.keyCode == 13) {
            $(target).getParent("[h-record]").toggleAttributeValue("toggle-state", "Expand", "Collapse");
        }
    };
    InputPropertyPanel.prototype.toggleContentPanel_Click = function (target, e) {
        $(target).getParent("[h-record]").toggleAttributeValue("toggle-state", "Expand", "Collapse");
    };
    InputPropertyPanel.prototype.deleteCandidateLink_Keydown = function (target, e) {
        if (e.keyCode == 13) {
            this.deleteCandidate(target);
        }
    };
    InputPropertyPanel.prototype.deleteCandidateLink_Click = function (target, e) {
        this.deleteCandidate(target);
    };
    InputPropertyPanel.prototype.deleteCandidate = function (target) {
        $(target).getParent("[h-record]").toggleAttributeValue("is-delete", "true", "false");
        $(target).getParent("[h-record]").find("input[h-name='IsDelete']").setValue("true");
    };
    InputPropertyPanel.createRecord = function (recordElement) {
        var record = {};
        var propertyPanelList = new Array();
        this.findChildNodes(recordElement, propertyPanelList);
        var name = "";
        for (var i = 0; i < propertyPanelList.length; i++) {
            var propertyPanel = propertyPanelList[i];
            name = $(propertyPanel).getAttribute("h-record-list");
            if (name != "") {
                record[name] = this.createRecordList(propertyPanel);
                continue;
            }
            name = $(propertyPanel).getAttribute("h-record");
            if (name != "") {
                var r = this.createRecord(propertyPanel);
                record[name] = r;
                continue;
            }
            name = $(propertyPanel).getAttribute("h-name");
            if (name != "") {
                InputPropertyPanel.setRecordProperty(record, propertyPanel);
            }
        }
        return record;
    };
    InputPropertyPanel.setRecordProperty = function (record, propertyPanel) {
        var name = $(propertyPanel).getAttribute("h-name");
        {
            var hRecord = $(propertyPanel).find("[h-record]").getFirstElement();
            if (hRecord != null) {
                record[name] = InputPropertyPanel.createRecord(hRecord);
                return;
            }
        }
        {
            var textarea = $(propertyPanel).find("textarea").getFirstElement();
            if (textarea != null) {
                var richTextbox = textarea.richTextbox;
                if (richTextbox == null) {
                    record[name] = $(textarea).getValue();
                }
                else {
                    record[name] = richTextbox.getData();
                    return;
                }
            }
        }
        {
            var dl = $(propertyPanel).find("select").getFirstElement();
            if (dl != null) {
                record[name] = $(dl).getValue();
                return;
            }
        }
        {
            var radioButtonList = $(propertyPanel).find("input[type='radio']").getElementList();
            for (var i = 0; i < radioButtonList.length; i++) {
                var rb = $(radioButtonList[i]);
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
            var element = $(propertyPanel).find("input").getFirstElement();
            if (element == null) {
                if (propertyPanel.tagName.toUpperCase() == "INPUT") {
                    element = propertyPanel;
                }
            }
            if (element == null) {
                return;
            }
            var control = $(element);
            switch (control.getAttribute("type")) {
                case "text":
                case "password":
                case "hidden":
                    {
                        var v = control.getValue();
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
    };
    InputPropertyPanel.createRecordList = function (recordListElement) {
        var rr = new Array();
        var recordList = $(recordListElement).find("[h-record]").getElementList();
        for (var i = 0; i < recordList.length; i++) {
            var recordPanel = recordList[i];
            if ($(recordPanel).getParent("[h-record-list]").getFirstElement() != recordListElement) {
                continue;
            }
            if ($(recordPanel).getParent("[search-record-list-panel]").getElementCount() > 0) {
                continue;
            }
            var r = InputPropertyPanel.createRecord(recordPanel);
            rr.push(r);
        }
        return rr;
    };
    InputPropertyPanel.findChildNodes = function (element, elementList) {
        var childList = $(element).getChildElementList();
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
    };
    InputPropertyPanel.setElementProperty = function (recordElement, record, key) {
        var propertyList = Object.getOwnPropertyNames(record);
        for (var i = 0; i < propertyList.length; i++) {
            var name = propertyList[i];
            var v = record[name];
            var propertyPanel = $(recordElement).find("[h-name='" + name + "'],[h-record='" + name + "'],[h-record-list='" + name + "']");
            var elementType = propertyPanel.getAttribute("element-type");
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
                var vv = v;
                for (var vIndex = 0; vIndex < vv.length; vIndex++) {
                    var hidden = propertyPanel.find("input[h-name='Value'][value='" + vv[vIndex].Value + "']").getFirstElement();
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
                if (v != null && v.length > 10) {
                    v = v.replace(/-/g, "/").substr(0, 10);
                    $(propertyPanel).find("[date-picker]").setValue(v);
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
            else if (elementType == "DateTimeDuration") {
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
                var element = propertyPanel.getFirstElement();
                if (element == null) {
                    continue;
                }
                if (element.tagName.toLowerCase() == "input") {
                    $(element).setValue(v);
                }
                else {
                    var input = propertyPanel.find("input").getFirstElement();
                    switch ($(input).getAttribute("type").toLowerCase()) {
                        case "radio":
                        case "checkbox":
                            $(input).setChecked(v);
                            $(input).triggerEvent("change");
                            break;
                        default:
                            $(input).setValue(v);
                            var textarea = propertyPanel.find("textarea").getFirstElement();
                            if (textarea != null) {
                                this.setTextArea(textarea, v);
                            }
                    }
                }
            }
        }
    };
    InputPropertyPanel.setRadioButtonProperty = function (element, name, key) {
        var radioButtonList = $(element).find("input[type='radio']").getElementList();
        for (var i = 0; i < radioButtonList.length; i++) {
            var rb = radioButtonList[i];
            var rbValue = $(rb).getValue();
            var hName = $(rb).getParentAttribute("h-name");
            var rName = name + "_" + key + "_" + hName;
            $(rb).setAttribute("name", rName);
            $(rb).setAttribute("id", rName + "_" + rbValue);
            $(rb).getNearest("label").setAttribute("for", rName + "_" + rbValue);
        }
    };
    InputPropertyPanel.setCheckBoxProperty = function (element, name, key) {
        var hName = $(element).getAttribute("h-name");
        var id = "CheckBox_" + name + "_" + key + "_" + hName;
        $(element).find("input[type='checkbox']").setAttribute("id", id);
        $(element).find("label").setAttribute("for", id);
    };
    InputPropertyPanel.setTextArea = function (element, value) {
        var v = value;
        if (v == null) {
            v = "";
        }
        var textarea = element;
        var richTextbox = textarea.richTextbox;
        if (richTextbox == null) {
            $(textarea).setValue(v);
        }
        else {
            richTextbox.setData(v);
        }
    };
    InputPropertyPanel.setRecord = function (propertyPanel, record) {
        if (record == null) {
            return;
        }
        var selectRecordPanel = $(propertyPanel).find("[select-record-panel]");
        var templateID = propertyPanel.getAttribute("template-id");
        $(selectRecordPanel).setInnerHtml("");
        HigLaboVue.append(selectRecordPanel.getFirstElement(), templateID, record);
    };
    InputPropertyPanel.setRecordList = function (propertyPanel, recordList) {
        var recordListPanel = $(propertyPanel).find("[select-record-list-panel]");
        var templateID = propertyPanel.getAttribute("template-id");
        $(recordListPanel).setInnerHtml("");
        for (var i = 0; i < recordList.length; i++) {
            var element = HigLaboVue.append(recordListPanel.getFirstElement(), templateID, recordList[i])[0];
            var key = $(element).getAttribute("h-key");
            InputPropertyPanel.setElementProperty(element, recordList[i], key);
        }
    };
    InputPropertyPanel.setValidationResult = function (element, validationResultList) {
        var vv = validationResultList;
        $(element).find("[h-validation-name]").removeClass("fadein");
        setTimeout(function () {
            for (var i = 0; i < vv.length; i++) {
                var vr = vv[i];
                var pl = $("[h-validation-name='" + vr.ParameterName + "']");
                pl.find("[text-panel]").setInnerText(vr.Message);
                pl.addClass("fadein");
            }
        }, 10);
    };
    return InputPropertyPanel;
}());
export { InputPropertyPanel };
var ValidationResult = (function () {
    function ValidationResult() {
    }
    return ValidationResult;
}());
export { ValidationResult };
//# sourceMappingURL=InputPropertyPanel.js.map