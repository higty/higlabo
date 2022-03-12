import { $, HtmlElementQuery } from "../../HigLabo/HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "../../HigLabo/HttpClient.js";
import { InputPropertyPanel, RecordAddedEvent } from "../../HigLabo/InputPropertyPanel.js";
import { RichTextbox } from "../../HigLabo/RichTextbox.js";
import SelectTimePopupPanel from "../../HigLabo/SelectTimePopupPanel.js";
import { TinyMceTextBox } from "../../HigLabo/TinyMceTextBox.js";

class Page {
    public inputPropertyPanel = new InputPropertyPanel();
    public selectTimePopupPanel = new SelectTimePopupPanel();
    public richTextBox = new RichTextbox();
    public tinyMceTextBox = new TinyMceTextBox();

    public initialize() {
        this.inputPropertyPanel.initialize();
        this.selectTimePopupPanel.initialize();
        this.richTextBox.initialize(document.getElementById("RichTextBox"));

        this.tinyMceTextBox.fileUploadUrlPath = "/Api/File/Upload";
        this.tinyMceTextBox.imageUploadUrlPath = "/Api/Image/Upload";
        this.tinyMceTextBox.initialize("Description");
        $("body").on("click", "#PostButton", this.postButton_Click.bind(this));
    }
    private postButton_Click(target: Element, e: Event) {
        const p = {
            Value: this.tinyMceTextBox.getContent(),
        };
        HttpClient.postJson("/Api/RichTextBox/Post", p);
    }
}



HtmlElementQuery.domContentLoaded(e => {
    var page = new Page();
    page.initialize();

    const flatpickr = window["flatpickr"];
    flatpickr.l10ns.default.firstDayOfWeek = 1;
    const webApp = window["WebApp_Current"];
    if (webApp != null && webApp.User != null && webApp.User.Language == "ja-JP") {
        flatpickr.localize(flatpickr.l10ns.ja);
    }
    flatpickr("[date-picker]", {
        dateFormat: "Y/m/d",
        allowInput: true,
        disableMobile: true
    });

});


