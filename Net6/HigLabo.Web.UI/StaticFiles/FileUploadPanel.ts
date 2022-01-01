import { $ } from "./HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";

export class FileUploadPanel {
    public initialize() {
        $("body").on("click", "[file-upload-panel]", this.FileUploadPanel_Click.bind(this));
        $("body").on("change", "[file-upload-panel] input[type='file']", this.fileUploadPanel_Change.bind(this));
    }
    private FileUploadPanel_Click(target: Element, e: Event) {
        const f = $(target).find("input[type='file']").getFirstElement() as HTMLInputElement;
        f.click();
    }
    public createParameter() {
        return {};
    }
    private fileUploadPanel_Change(target: Element, e: Event) {
        const apiPath = $(target).getParentAttribute("api-path");
        const f = target as HTMLInputElement;
        if (f.files.length == 0) { return; }

        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }

        const p = this.createParameter();
        const pNameList = Object.getOwnPropertyNames(p);
        for (var i = 0; i < pNameList.length; i++) {
            let v = p[pNameList[i]];
            formData.append(pNameList[i], v);
        }
        HttpClient.postForm(apiPath, formData, this.uploadCallback.bind(this), this.uploadErrorCallback.bind(this)
            , null, target);

        $(f).setValue("");
    }
    public uploadCallback(response: HttpResponse, target: Element) { }
    public uploadErrorCallback(response: HttpResponse, target: Element) { }
}
