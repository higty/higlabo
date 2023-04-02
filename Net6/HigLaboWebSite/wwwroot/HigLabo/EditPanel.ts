import { $ } from "./HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";
import { InputPropertyPanel } from "./InputPropertyPanel.js";
import { WebApiResult } from "./WebApiResult.js";

export class EditPanel {
    private _record: any;
    private _editPanel = document.getElementById("EditPanel");

    public initialize() {
        $("body").on("click", "#SaveButton", this.saveButton_Click.bind(this));
        $("body").on("click", "#DeleteButton", this.deleteButton_Click.bind(this));
        $("body").on("click", "#DeleteYesButton", this.deleteYesButton_Click.bind(this));
        $("body").on("click", "#DeleteNoButton", this.deleteNoButton_Click.bind(this));
        this.loadData();
    }
    public loadData() {
        const json = $("#JsonData").getAttribute("edit-json-data");
        if (json != "") {
            $("#JsonData").removeAttribute("edit-json-data");
            try {
                const r = JSON.parse(json);
                this.setRecord(r);
                return;
            }
            catch (ex) {
                const msg = ex;
            }
        }
        this.setProperty();
    }
    private setRecord(record: any) {
        this._record = record;
        var r = record;
        InputPropertyPanel.setElementProperty(document.getElementById("EditPanel"), r, "");
        this.setProperty();
        this.setRecordCompleted(record);
    }
    protected setRecordCompleted(record: any) {

    }
    private setProperty() {
        $(this._editPanel).find("[input-panel]").setStyle("display", "initial");
        $(this._editPanel).find("[submit-button]").setStyle("display", "initial");
        $(this._editPanel).find("[record-loading-image-panel]").hide();
    }

    private async saveButton_Click(e: Event) {
        this.save();
    }
    public save() {
        const apiPath = $("#EditPanelParameter").getAttribute("api-path-save");
        if (apiPath == "") { return; }
        this.hideButton();
        const r = InputPropertyPanel.createRecord(document.getElementById("EditPanel"));
        HttpClient.postJson(apiPath, r, this.api_Callback.bind(this), this.api_ErrorCallback.bind(this));
    }
    private async deleteButton_Click(e: Event) {
        $("#SaveButton").hide();
        $("#DeleteButton").hide();
        $("#DeleteConfirmPanel").setStyle("display", "initial");
    }
    private async deleteYesButton_Click(e: Event) {
        const r = InputPropertyPanel.createRecord(document.getElementById("EditPanel"));
        const apiPath = $("#EditPanelParameter").getAttribute("api-path-delete");
        HttpClient.postJson(apiPath, r, this.api_Callback.bind(this), this.api_ErrorCallback.bind(this));
        this.hideButton();
    }
    private async deleteNoButton_Click(e: Event) {
        this.showButton();
    }
    protected api_Callback(response: HttpResponse) {
        const result = response.jsonParse() as WebApiResult;

        if (response.status == 200) {
        }
        else if (response.status == 302) {
            location.href = result.Url;
            return;
        }
        this.showButton();
    }
    protected api_ErrorCallback(response: HttpResponse) {
        const result = response.jsonParse() as WebApiResult;

        this.showButton();

        InputPropertyPanel.setValidationResult(document.getElementById("EditPanel"), result.ValidationResultList);
        $("#BodyScrollPanel").setScrollTop(0);
    }
    protected hideButton() {
        $("#SaveButton").hide();
        $("#DeleteButton").hide();
        $("#DeleteConfirmPanel").hide();
        $("#SaveButton").getNearest("[loading-image-panel]").setStyle("display", "inline");
    }
    protected showButton() {
        $("#SaveButton").setStyle("display", "initial");
        $("#DeleteButton").setStyle("display", "initial");
        $("#DeleteConfirmPanel").hide();
        $("#SaveButton").getNearest("[loading-image-panel]").hide();
    }
}



