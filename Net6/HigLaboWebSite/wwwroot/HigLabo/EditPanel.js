var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { $ } from "../HigLabo/HtmlElementQuery.js";
import { HttpClient } from "../HigLabo/HttpClient.js";
import { InputPropertyPanel } from "../HigLabo/InputPropertyPanel.js";
export class EditPanel {
    constructor() {
        this._editPanel = document.getElementById("EditPanel");
    }
    initialize() {
        $("body").on("click", "#SaveButton", this.saveButton_Click.bind(this));
        $("body").on("click", "#DeleteButton", this.deleteButton_Click.bind(this));
        $("body").on("click", "#DeleteYesButton", this.deleteYesButton_Click.bind(this));
        $("body").on("click", "#DeleteNoButton", this.deleteNoButton_Click.bind(this));
        this.loadData();
    }
    loadData() {
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
    setRecord(record) {
        this._record = record;
        var r = record;
        InputPropertyPanel.setElementProperty(document.getElementById("EditPanel"), r, "");
        this.setProperty();
        this.setRecordCompleted(record);
    }
    setRecordCompleted(record) {
    }
    setProperty() {
        $(this._editPanel).find("[input-panel]").setStyle("display", "initial");
        $(this._editPanel).find("[submit-button]").setStyle("display", "initial");
        $(this._editPanel).find("[record-loading-image-panel]").hide();
    }
    saveButton_Click(e) {
        return __awaiter(this, void 0, void 0, function* () {
            this.save();
        });
    }
    save() {
        const r = InputPropertyPanel.createRecord(document.getElementById("EditPanel"));
        const apiPath = $("#EditPanelParameter").getAttribute("api-path-save");
        if (apiPath == "") {
            return;
        }
        HttpClient.postJson(apiPath, r, this.api_Callback.bind(this), this.api_ErrorCallback.bind(this));
        this.hideButton();
    }
    deleteButton_Click(e) {
        return __awaiter(this, void 0, void 0, function* () {
            $("#SaveButton").hide();
            $("#DeleteButton").hide();
            $("#DeleteConfirmPanel").setStyle("display", "initial");
        });
    }
    deleteYesButton_Click(e) {
        return __awaiter(this, void 0, void 0, function* () {
            const r = InputPropertyPanel.createRecord(document.getElementById("EditPanel"));
            const apiPath = $("#EditPanelParameter").getAttribute("api-path-delete");
            HttpClient.postJson(apiPath, r, this.api_Callback.bind(this), this.api_ErrorCallback.bind(this));
            this.hideButton();
        });
    }
    deleteNoButton_Click(e) {
        return __awaiter(this, void 0, void 0, function* () {
            this.showButton();
        });
    }
    api_Callback(response) {
        const result = response.jsonParse();
        if (response.status == 200) {
        }
        else if (response.status == 302) {
            location.href = result.Url;
            return;
        }
        this.showButton();
    }
    api_ErrorCallback(response) {
        const result = response.jsonParse();
        this.showButton();
        InputPropertyPanel.setValidationResult(document.getElementById("EditPanel"), result.ValidationResultList);
        $("#BodyScrollPanel").setScrollTop(0);
    }
    hideButton() {
        $("#SaveButton").hide();
        $("#DeleteButton").hide();
        $("#DeleteConfirmPanel").hide();
        $("#SaveButton").getNearest("[loading-image-panel]").setStyle("display", "inline");
    }
    showButton() {
        $("#SaveButton").setStyle("display", "initial");
        $("#DeleteButton").setStyle("display", "initial");
        $("#DeleteConfirmPanel").hide();
        $("#SaveButton").getNearest("[loading-image-panel]").hide();
    }
}
//# sourceMappingURL=EditPanel.js.map