import { WebApiResult } from "./WebApiResult.js";
import { $ } from "./HtmlElementQuery.js";
import { HigLaboVue } from ".//HigLaboVue.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";
import { InputPropertyPanel } from "./InputPropertyPanel.js";
import { List } from "./linq/Linq.js";

export class ViewPanel {
    public viewPanel: Element = document.getElementById("ViewPanel");
    public templateID = "";
    public recordList: List<any> = new List<any>();
    public isHideViewPanel = true;
    public isLoadOnInitialize = true;

    public initialize() {
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
    }
    private window_HashChange(e: Event) {
        this.loadDataByHash();
    }
    protected loadDataByHash() {
        const d = location.hash.replace("#", "").split("&").map(v => v.split("="))
            .reduce((pre, [key, value]) => ({ ...pre, [key]: value }), {});

        this.loadData();
    }

    public loadData() {
        const json = $("#JsonData").getAttribute("view-json-data");
        if (json != "") {
            $("#JsonData").removeAttribute("view-json-data");
            try {
                const data = JSON.parse(json);
                this.setData(data);
                return;
            }
            catch { }
        }
        const p = InputPropertyPanel.createRecord($("#FilterConditionPanel").getFirstElement());
        const apiPath = $("#ViewPanel").getAttribute("api-path-load");
        if (apiPath == "") { return; }

        $("#NoDataMessagePanel").hide();
        if (this.isHideViewPanel == true) {
            $(this.viewPanel).getNearest("[loading-image-panel]").setStyle("display", "block");
            $(this.viewPanel).hide();
        }
        this.recordList.clear();
        HttpClient.postJson(apiPath, p, this.loadDataCallback.bind(this));
    }
    private loadDataCallback(response: HttpResponse) {
        const r = response.jsonParse() as WebApiResult;

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
    protected setData(data: any) {
        $(this.viewPanel).setInnerHtml("");

        let rr = data;
        if (data.PageCount != null) {
            rr = data.RecordList;

            if (document.getElementById("PagingListPanel") != null) {
                $("#PagingListPanel").setInnerHtml("");
                const pageCount = data.PageCount;
                for (var i = 0; i < pageCount; i++) {
                    HigLaboVue.append($("#PagingListPanel").getFirstElement(), "PageNumberPanelTemplate", { PageIndex: i, Text: (i + 1) });
                }
            }
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
    protected loadDataCompleted(data: any) {
    }

    public getRecord(key: string) {
        return this.recordList.firstOrDefault(el => this.selectKeyColumn(el) == key);
    }
    public addRecord(record: any) {
        return this.recordList.push(record);
    }
    public replaceRecord(record: any) {
        const key = this.selectKeyColumn(record);
        if (key == null) { return; }
        //Reeplace record object on memory.
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
    public replaceElement(key: string): List<Element> {
        const r = this.getRecord(key);
        if (r == null) { return; }
        //Replace element on UI.
        const l = new List<Element>();
        const elementList = $("body").find("[h-key='" + key + "']").getElementList();
        for (var i = 0; i < elementList.length; i++) {
            let element = elementList[i];
            if ($(element).getParent("#SlideMenuPanel").getElementCount() > 0) { continue; }

            HigLaboVue.insertBefore(element, this.templateID, r).forEach(newElement => {
                l.push(newElement);
            });
            element.remove();
        }
        return l;
    }
    public deleteRecord(record: any) {
        return this.recordList.remove(record);
    }
    public deleteElement(key: string) {
        $("body").find("[h-key='" + key + "']").forEach(element => {
            element.remove();
        });
    }
    protected selectKeyColumn(record: any): string {
        if (record.SeatCD) { return record.SeatCD; }
        if (record.EquipmentCD) { return record.EquipmentCD; }
        if (record.ObjectCD) { return record.ObjectCD; }
        return undefined;
    }

}
