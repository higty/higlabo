import { $ } from "./HtmlElementQuery.js";
export class MentionListPopupPanel {
    initialize() {
        $("#MentionListPopupPanel").on("click", "[mention-record-panel]", this.mentionRecordPanel_Click.bind(this));
    }
    mentionRecordPanel_Click(target, e) {
        const textbox = window["tinymce_current"];
        if (textbox == null) {
            return;
        }
        textbox.selectMention(target);
        textbox.setFocus();
    }
}
//# sourceMappingURL=MentionListPopupPanel.js.map