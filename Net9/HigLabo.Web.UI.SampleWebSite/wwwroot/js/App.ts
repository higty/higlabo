import { $ } from "../HigLabo/HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "../HigLabo/HttpClient.js";
import { DataRecordPopupPanel } from "../HigLabo/DataRecordPopupPanel.js";
import { DialogPopupPanel } from "../HigLabo/DialogPopupPanel.js";
import { FileUpload } from "../HigLabo/FileUpload.js";
import { FullWindowPopupPanel } from "../HigLabo/FullWindowPopupPanel.js";
import { HigLaboJson } from "../HigLabo/HigLaboJson.js";
import { Htmx } from "../HigLabo/Htmx.js";
import { MessagePopupPanel } from "../HigLabo/MessagePopupPanel.js";
import { PopuPanel } from "../HigLabo/Popup.js";
import { RecordListComponent } from "../HigLabo/RecordListComponent.js";

export class App {
    private HigLaboJson = new HigLaboJson();
    private htmx = new Htmx();
    private recordListComponent = new RecordListComponent();
    private fileUpload = new FileUpload();

    private popupPanel = new PopuPanel();
    private fullWindowPopupPanel = new FullWindowPopupPanel();
    private dialogPopupPanel = new DialogPopupPanel();
    private dataRecordPopupPanel = new DataRecordPopupPanel();
    private messagePopupPanel = new MessagePopupPanel();

    public initialize() {
        this.recordListComponent.initialize();
        this.fileUpload.initialize();

        this.popupPanel.initialize();
        this.dialogPopupPanel.initialize();
        this.fullWindowPopupPanel.initialize();
        this.dataRecordPopupPanel.initialize();
    }
}