import { $ } from "./HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";

export class FileUpload {
    public successCallback = (response: HttpResponse) => { };
    public errorCallback = (response: HttpResponse) => { };
    public progressCallback = (response: HttpResponse) => { };

    public initialize() {
        $("body").on("click", "[file-upload]", this.fileUpload_Click.bind(this));
        $("body").on("change", "[file-upload] input[type='file']", this.file_Change.bind(this));
    }
    private fileUpload_Click(target: Element, e: Event) {
        const f = $(target).find("input[type='file']").getFirstElement() as HTMLInputElement;
        f.click();
    }
    private file_Change(target: Element, e: Event) {
        const pl = $(target).getFirstParent("[file-upload]").getFirstElement();
        const apiPath = $(pl).getAttribute("api-path");
        const f = target as HTMLInputElement;
        if (f.files.length == 0) { return; }

        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }

        const cl = new HttpClient();
        cl.postForm(apiPath, formData, this.successCallback.bind(this), this.errorCallback.bind(this), this.progressCallback.bind(this)
            , {
                target: target,
                event: e,
            });
    }
}