import { HtmlElementQuery } from "../../HigLabo/HtmlElementQuery.js";
import { InputPropertyPanel, RecordChangedEvent } from "../../HigLabo/InputPropertyPanel.js";
import { RichTextbox } from "../../HigLabo/RichTextbox.js";
import SelectTimePopupPanel from "../../HigLabo/SelectTimePopupPanel.js";

class Page {
    public inputPropertyPanel = new InputPropertyPanel();
    public selectTimePopupPanel = new SelectTimePopupPanel();
    public richTextBox = new RichTextbox();

    public initialize() {
        this.inputPropertyPanel.initialize();
        this.inputPropertyPanel.registerEventHandler(this.recordAdded.bind(this));
        this.selectTimePopupPanel.initialize();
        this.richTextBox.initialize(document.getElementById("RichTextBox"));
    }
    private recordAdded(panel: InputPropertyPanel, e: RecordChangedEvent) {
        //alert("Record added");
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


