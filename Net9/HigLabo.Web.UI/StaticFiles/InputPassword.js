import { $ } from "./HtmlElementQuery.js";
export class InputPassword {
    initialize() {
        $("body").on("click", "[input-password]>[toggle-input-type]", this.toggleInputType_Click.bind(this));
    }
    toggleInputType_Click(target, e) {
        const span = $(target).getFirstParent("[input-password]").getFirstElement();
        $(span).find("input").toggleAttributeValue("type", "text", "password");
    }
}
//# sourceMappingURL=InputPassword.js.map