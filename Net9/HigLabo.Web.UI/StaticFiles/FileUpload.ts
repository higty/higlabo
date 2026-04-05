import { $ } from "./HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "./HttpClient.js";

export class FileUpload {
    public createHttpClient = () => new HttpClient();
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

        const ppl = $(pl).getFirstParent("[file-parameter-panel]").getFirstElement();
        if (ppl != null) {
            ppl.querySelectorAll("input,textarea,select").forEach(childNode => {
                if (childNode.nodeType == Node.ELEMENT_NODE) {
                    this.appendFormValue(formData, childNode as HTMLElement);
                }
            });
        }

        const files = Array.from(f.files ?? []);
        for (const file of files) {
            formData.append(f.name, file);
        }

        const cl = this.createHttpClient();
        cl.postForm(apiPath, formData, this.successCallback.bind(this), this.errorCallback.bind(this), this.progressCallback.bind(this)
            , {
                target: target,
                event: e,
            });
        f.value = "";
    }
    private appendFormValue(formData: FormData, element: HTMLElement) {
        const name = element.getAttribute("name");
        if (name == null || name == "" || element.hasAttribute("disabled")) { return; }

        if (element.tagName.toLowerCase() == "select") {
            const selectElement = element as HTMLSelectElement;
            if (selectElement.multiple) {
                Array.from(selectElement.selectedOptions).forEach(option => {
                    formData.append(name, option.value);
                });
            }
            else if (selectElement.selectedIndex > -1) {
                formData.append(name, selectElement.options[selectElement.selectedIndex].value);
            }
            return;
        }
        if (element.tagName.toLowerCase() != "input" && element.tagName.toLowerCase() != "textarea") { return; }

        const inputElement = element as HTMLInputElement;
        const type = (inputElement.getAttribute("type") || "").toLowerCase();
        if (type == "file") { return; }
        if (type == "checkbox" || type == "radio") {
            if (inputElement.checked) {
                formData.append(name, inputElement.value);
            }
            return;
        }
        formData.append(name, inputElement.value);
    }
}
