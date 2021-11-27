import { HtmlElementQuery } from "../../HigLabo/HtmlElementQuery.js";
import { InputPropertyPanel } from "../../HigLabo/InputPropertyPanel.js";
import { RichTextbox } from "../../HigLabo/RichTextbox.js";
import SelectTimePopupPanel from "../../HigLabo/SelectTimePopupPanel.js";
class Page {
    constructor() {
        this.inputPropertyPanel = new InputPropertyPanel();
        this.selectTimePopupPanel = new SelectTimePopupPanel();
        this.richTextBox = new RichTextbox();
    }
    initialize() {
        this.inputPropertyPanel.initialize();
        this.selectTimePopupPanel.initialize();
        this.richTextBox.initialize(document.getElementById("RichTextBox"));
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
//# sourceMappingURL=Home.js.map