import { $ } from "./HtmlElementQuery.js";
export class MessagePopupPanel {
    show(text) {
        $("#message-popup-panel").removeClass("display-none").setInnerText(text);
    }
}
//# sourceMappingURL=MessagePopupPanel.js.map