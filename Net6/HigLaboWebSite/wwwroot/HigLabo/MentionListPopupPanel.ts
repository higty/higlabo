import { DateTime } from "./DateTime.js";
import { HigLaboVue } from "./HigLaboVue.js";
import { $, HtmlElementQuery } from "./HtmlElementQuery.js";
import { HttpClient, HttpRequestCallback, HttpResponse } from "./HttpClient.js";
import { InputPropertyPanel } from "./InputPropertyPanel.js";
import { List } from "./linq/Collections.js";
import { TinyMceTextBox } from "./TinyMceTextBox.js";

export class MentionListPopupPanel {
    public initialize() {
        $("#MentionListPopupPanel").on("click", "[mention-record-panel]", this.mentionRecordPanel_Click.bind(this));
    }
    public mentionRecordPanel_Click(target: Element, e: Event) {
        const textbox = window["tinymce_current"] as TinyMceTextBox;
        if (textbox == null) { return; }
        textbox.selectMention(target);
        textbox.setFocus();
    }
}
