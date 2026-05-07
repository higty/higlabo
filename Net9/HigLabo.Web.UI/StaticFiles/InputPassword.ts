import { $ } from "./HtmlElementQuery.js";

export class InputPassword {
    public initialize() {
        $("body").on("click", "[input-password]>[toggle-input-type]", this.toggleInputType_Click.bind(this));
    }
    private toggleInputType_Click(target: Element, e: Event) {
        const span = $(target).findAncestors("[input-password]").getFirstElement();
        $(span).find("input").toggleAttributeValue("type", "text", "password");
    }
}
