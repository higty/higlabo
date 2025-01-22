import { $ } from "./HtmlElementQuery.js";
import { HttpClient } from "./HttpClient.js";
export class FileUpload {
    successCallback = (response) => { };
    errorCallback = (response) => { };
    progressCallback = (response) => { };
    initialize() {
        $("body").on("click", "[file-upload]", this.fileUpload_Click.bind(this));
        $("body").on("change", "[file-upload] input[type='file']", this.file_Change.bind(this));
    }
    fileUpload_Click(target, e) {
        const f = $(target).find("input[type='file']").getFirstElement();
        f.click();
    }
    file_Change(target, e) {
        const pl = $(target).getFirstParent("[file-upload]").getFirstElement();
        const apiPath = $(pl).getAttribute("api-path");
        const f = target;
        if (f.files.length == 0) {
            return;
        }
        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }
        const cl = new HttpClient();
        cl.postForm(apiPath, formData, this.successCallback.bind(this), this.errorCallback.bind(this), this.progressCallback.bind(this), {
            target: target,
            event: e,
        });
    }
}
//# sourceMappingURL=FileUpload.js.map