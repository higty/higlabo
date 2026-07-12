import { $ } from "./HtmlElementQuery.js";
export class MessagePopupPanel {
    show(text) {
        $("#message-popup-panel").removeClass("display-none").setInnerText(text);
    }
    showHtml(html) {
        $("#message-popup-panel").removeClass("display-none").setInnerHtml(html);
    }
}
//# sourceMappingURL=MessagePopupPanel.js.map