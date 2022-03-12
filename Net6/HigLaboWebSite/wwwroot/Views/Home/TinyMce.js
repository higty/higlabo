import { $, HtmlElementQuery } from "../../HigLabo/HtmlElementQuery.js";
import { HttpClient } from "../../HigLabo/HttpClient.js";
import { InputPropertyPanel } from "../../HigLabo/InputPropertyPanel.js";
import { RichTextbox } from "../../HigLabo/RichTextbox.js";
import SelectTimePopupPanel from "../../HigLabo/SelectTimePopupPanel.js";
import { TinyMceTextBox } from "../../HigLabo/TinyMceTextBox.js";
class Page {
    constructor() {
        this.inputPropertyPanel = new InputPropertyPanel();
        this.selectTimePopupPanel = new SelectTimePopupPanel();
        this.richTextBox = new RichTextbox();
        this.tinyMceTextBox = new TinyMceTextBox();
    }
    initialize() {
        this.inputPropertyPanel.initialize();
        this.selectTimePopupPanel.initialize();
        this.richTextBox.initialize(document.getElementById("RichTextBox"));
        this.tinyMceTextBox.imageUploadUrlPath = "/Api/Image/Upload";
        this.tinyMceTextBox.initialize("Description");
        $("body").on("click", "#PostButton", this.postButton_Click.bind(this));
    }
    imageUploadCallback(response) {
    }
    postButton_Click(target, e) {
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
//# sourceMappingURL=TinyMce.js.map