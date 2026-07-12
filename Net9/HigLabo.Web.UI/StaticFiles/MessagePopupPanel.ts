import { $ } from "./HtmlElementQuery.js";

export class MessagePopupPanel {
    public show(text: string) {
        $("#message-popup-panel").removeClass("display-none").setInnerText(text);
    }
    public showHtml(html: string) {
        $("#message-popup-panel").removeClass("display-none").setInnerHtml(html);
    }
}