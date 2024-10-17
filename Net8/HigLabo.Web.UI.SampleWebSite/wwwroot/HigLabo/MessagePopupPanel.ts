import { $ } from "./HtmlElementQuery.js";

export class MessagePopupPanel {
    public show(text: string) {
        $("#message-popup-panel").removeClass("display-none").setInnerText(text);
    }
}