import { $ } from "./HtmlElementQuery.js";
import { HigLaboVue } from ".//HigLaboVue.js";
import { HttpClient } from "./HttpClient.js";
import { InputPropertyPanel } from "./InputPropertyPanel.js";
import { List } from "./linq/Linq.js";
export class ViewPanel {
    constructor() {
        this.viewPanel = document.getElementById("ViewPanel");
        this.templateID = "";
        this.recordList = new List();
        this.isHideViewPanel = true;
        this.isLoadOnInitialize = true;
    }
    initialize() {
        this.templateID = $(document.getElementById("ViewPanel")).getAttribute("template-id");
        window.addEventListener("hashchange", this.window_HashChange.bind(this));
        if (this.isLoadOnInitialize == true) {
            if (location.hash == "") {
                this.loadData();
            }
            else {
                this.loadDataByHash();
            }
        }
        $(this.viewPanel).on("click", "[h-record]", this.record_Click.bind(this));
    }
    window_HashChange(e) {
        this.loadDataByHash();
    }
    loadDataByHash() {
        const d = location.hash.replace("#", "").split("&").map(v => v.split("="))
            .reduce((pre, [key, value]) => (Object.assign(Object.assign({}, pre), { [key]: value })), {});
        this.loadData();
    }
    loadData() {
        const json = $("#JsonData").getAttribute("view-json-data");
        if (json != "") {
            $("#JsonData").removeAttribute("view-json-data");
            try {
                const data = JSON.parse(json);
                this.setData(data);
                return;
            }
            catch (_a) { }
        }
        const p = InputPropertyPanel.createRecord($("#FilterConditionPanel").getFirstElement());
        const apiPath = $("#ViewPanel").getAttribute("api-path-load");
        if (apiPath == "") {
            return;
        }
        $("#NoDataMessagePanel").hide();
        if (this.isHideViewPanel == true) {
            $(this.viewPanel).getNearest("[loading-image-panel]").setStyle("display", "block");
            $(this.viewPanel).hide();
        }
        this.recordList.clear();
        HttpClient.postJson(apiPath, p, this.loadDataCallback.bind(this));
    }
    loadDataCallback(response) {
        const r = response.jsonParse();
        $(this.viewPanel).getNearest("[loading-image-panel]").hide();
        $(document.getElementById("FilterTextBox")).setValue("");
        if (this.viewPanel.tagName.toLowerCase() === "table") {
            $(this.viewPanel).setStyle("display", "table");
        }
        else {
            $(this.viewPanel).setStyle("display", "block");
        }
        this.setData(r.Data);
    }
    setPagingListPanel(pageCount) {
        if (document.getElementById("PagingListPanel") != null) {
            $("#PagingListPanel").setInnerHtml("");
            for (var i = 0; i < pageCount; i++) {
                HigLaboVue.append($("#PagingListPanel").getFirstElement(), "PageNumberPanelTemplate", { PageIndex: i, Text: (i + 1) });
            }
        }
    }
    setData(data) {
        $(this.viewPanel).setInnerHtml("");
        let rr = data;
        if (data.PageCount != null) {
            rr = data.RecordList;
            this.setPagingListPanel(data.PageCount);
        }
        let isTable = false;
        if (this.viewPanel.tagName.toLowerCase() === "table") {
            isTable = true;
        }
        if (rr instanceof Array) {
            if (isTable == true) {
                HigLaboVue.render(this.viewPanel, $(this.viewPanel).getAttribute("header-templete-id"), {});
            }
            this.recordList.clear();
            let containerPanel = this.viewPanel;
            if (isTable == true) {
                containerPanel = document.createElement("tbody");
                this.viewPanel.appendChild(containerPanel);
            }
            for (var i = 0; i < rr.length; i++) {
                this.recordList.push(rr[i]);
                HigLaboVue.append(containerPanel, this.templateID, rr[i]);
            }
        }
        else {
            this.recordList.push(rr);
            HigLaboVue.append(this.viewPanel, this.templateID, rr);
        }
        if (rr.length == 0) {
            $(this.viewPanel).hide();
            $("#NoDataMessagePanel").setStyle("display", "block");
        }
        this.loadDataCompleted(data);
    }
    loadDataCompleted(data) {
    }
    getRecord(key) {
        return this.recordList.firstOrDefault(el => this.selectKeyColumn(el) == key);
    }
    addRecord(record) {
        return this.recordList.push(record);
    }
    replaceRecord(record) {
        const key = this.selectKeyColumn(record);
        if (key == null) {
            return;
        }
        const r = this.getRecord(key);
        if (r == null) {
            this.recordList.push(record);
        }
        else {
            const index = this.recordList.indexOf(r);
            this.recordList.removeAt(index);
            this.recordList.insert(index, record);
        }
    }
    replaceElement(key) {
        const r = this.getRecord(key);
        if (r == null) {
            return;
        }
        if (this.templateID == "") {
            return;
        }
        const l = new List();
        const elementList = $("body").find("[h-key='" + key + "']").getElementList();
        for (var i = 0; i < elementList.length; i++) {
            let element = elementList[i];
            if ($(element).getParent("#SlideMenuPanel").getElementCount() > 0) {
                continue;
            }
            HigLaboVue.insertBefore(element, this.templateID, r).forEach(newElement => {
                l.push(newElement);
            });
            element.remove();
        }
        return l;
    }
    deleteRecord(record) {
        return this.recordList.remove(record);
    }
    deleteElement(key) {
        $("body").find("[h-key='" + key + "']").forEach(element => {
            element.remove();
        });
    }
    selectKeyColumn(record) {
        if (record.SeatCD) {
            return record.SeatCD;
        }
        if (record.EquipmentCD) {
            return record.EquipmentCD;
        }
        if (record.ObjectCD) {
            return record.ObjectCD;
        }
        return undefined;
    }
    getSelectedRecordList() {
        return InputPropertyPanel.createRecord(this.viewPanel);
    }
    record_Click(target, e) {
        var _a;
        const key = $(target).getAttribute("h-key");
        if (key == "") {
            return;
        }
        const ch = this.getCurrentCheckbox(key);
        if (e.shiftKey == true) {
            if (target != ch) {
                this.changeCheckboxChecked(key);
                (_a = window.getSelection()) === null || _a === void 0 ? void 0 : _a.removeAllRanges();
            }
            this.setCheckboxListChecked(key);
        }
        else if (e.ctrlKey == true) {
            if (e.srcElement != ch) {
                this.toggleCheckboxChecked(key);
            }
            if ($(ch).isChecked() == true) {
                this.setCurrentCheckbox(ch);
            }
        }
        else {
            if (e.srcElement != ch) {
                this.changeCheckboxChecked(key);
            }
            this.setCurrentCheckbox(ch);
        }
    }
    getCurrentCheckbox(key) {
        return $(this.viewPanel).find("input[type='checkbox'][h-name='Selected'][h-key='" + key + "']").getFirstElement();
    }
    setCurrentCheckbox(checkbox) {
        $(this.viewPanel).find("input[type='checkbox'][h-name='Selected']").removeAttribute("current");
        $(checkbox).setAttribute("current", "true");
    }
    clearCheckbox() {
        $(this.viewPanel).find("input[type='checkbox'][h-name='Selected']").setChecked(false);
    }
    toggleCheckboxChecked(key) {
        $(this.viewPanel).find("input[type='checkbox'][h-name='Selected'][h-key='" + key + "']").toggleChecked();
    }
    changeCheckboxChecked(key) {
        this.clearCheckbox();
        $(this.viewPanel).find("input[type='checkbox'][h-name='Selected'][h-key='" + key + "']").setChecked(true);
    }
    setCheckboxListChecked(key) {
        const cc = $(this.viewPanel).find("input[type='checkbox'][h-name='Selected']").getElementList();
        const activeCheckbox = $(this.viewPanel).find("input[type='checkbox'][h-name='Selected'][current='true']").getFirstElement();
        const checkbox = $(this.viewPanel).find("input[type='checkbox'][h-name='Selected'][h-key='" + key + "']").getFirstElement();
        let intersect = false;
        for (var i = 0; i < cc.length; i++) {
            let ch = cc[i];
            if (intersect == true) {
                $(ch).setChecked(true);
                if (checkbox == cc[i] || activeCheckbox == cc[i]) {
                    break;
                }
            }
            else {
                if (checkbox == cc[i] || activeCheckbox == cc[i]) {
                    intersect = true;
                    $(ch).setChecked(true);
                }
            }
        }
    }
}
//# sourceMappingURL=ViewPanel.js.map