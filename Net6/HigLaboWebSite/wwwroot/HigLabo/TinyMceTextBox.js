import { $ } from "./HtmlElementQuery.js";
import { HttpClient } from "./HttpClient.js";
export class TinyMceTextBox {
    constructor() {
        this.tinymce = window["tinymce"];
        this.textBoxId = "";
        this.tokenProvider = "";
        this.dropboxApiKey = "";
        this.googleDriveApiKey = "";
        this.googleDriveClientId = "";
        this.fileUploadUrlPath = "";
        this.imageUploadUrlPath = "";
        this.useDarkMode = false;
        this.createFileHtml = this.defaultCreateFileHtml;
    }
    initialize(id) {
        this.textBoxId = id;
        this.tinymce.init({
            selector: "#" + id,
            plugins: 'print preview powerpaste casechange importcss tinydrive searchreplace autolink autosave save directionality advcode visualblocks visualchars fullscreen image link media mediaembed template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists checklist wordcount a11ychecker textpattern noneditable help formatpainter permanentpen pageembed charmap tinycomments mentions quickbars linkchecker emoticons advtable export',
            mobile: {
                plugins: 'print preview powerpaste casechange importcss tinydrive searchreplace autolink autosave save directionality advcode visualblocks visualchars fullscreen image link media mediaembed template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists checklist wordcount a11ychecker textpattern noneditable help formatpainter pageembed charmap mentions quickbars linkchecker emoticons advtable'
            },
            menubar: 'file edit view insert format tools table tc help',
            toolbar: "uploadfile undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | "
                + "alignleft aligncenter alignright alignjustify | outdent indent | numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | "
                + "charmap emoticons | fullscreen  preview save print | media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment",
            images_upload_handler: this.imageUpload.bind(this),
            tinydrive_token_provider: this.tokenProvider,
            tinydrive_dropbox_app_key: this.dropboxApiKey,
            tinydrive_google_drive_key: this.googleDriveApiKey,
            tinydrive_google_drive_client_id: this.googleDriveClientId,
            menu: {
                tc: {
                    title: 'Comments',
                    items: 'addcomment showcomments deleteallconversations'
                }
            },
            image_advtab: true,
            link_list: [],
            image_list: [],
            image_class_list: [],
            importcss_append: true,
            templates: [],
            template_cdate_format: '[Created at: %m/%d/%Y : %H:%M:%S]',
            template_mdate_format: '[Modified at: %m/%d/%Y : %H:%M:%S]',
            height: 600,
            image_caption: true,
            quickbars_selection_toolbar: 'bold italic | quicklink h2 h3 blockquote quickimage quicktable',
            noneditable_noneditable_class: 'mceNonEditable',
            toolbar_mode: 'sliding',
            spellchecker_ignore_list: ['Ephox', 'Moxiecode'],
            tinycomments_mode: 'embedded',
            content_style: '.mymention{ color: gray; }',
            contextmenu: 'link image table configurepermanentpen',
            a11y_advanced_options: true,
            skin: this.useDarkMode ? 'oxide-dark' : 'oxide',
            content_css: this.useDarkMode ? 'dark' : 'default',
            mentions_selector: '.mymention',
            mentions_item_type: 'profile',
            setup: function (editor) {
                this.editor = editor;
                this.initializeFileUploadElement(editor);
                $(this.fileUploadElement).change(this.fileSelected.bind(this));
                editor.ui.registry.addButton("uploadfile", {
                    text: "File Upload",
                    icon: "upload",
                    onAction: function (e) {
                        this.fileUploadElement.click();
                    }.bind(this)
                });
            }.bind(this)
        });
    }
    initializeFileUploadElement(editor) {
        const pl = $(editor.getElement()).getParentElementList()[0];
        const fd = document.createElement("input");
        fd.type = "file";
        $(fd).setStyle("display", "none");
        pl.appendChild(fd);
        this.fileUploadElement = fd;
    }
    fileSelected(e) {
        if (this.fileUploadUrlPath == "") {
            return;
        }
        const f = this.fileUploadElement;
        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }
        HttpClient.postForm(this.fileUploadUrlPath, formData, this.fileUploadCallback.bind(this), this.fileUploadErrorCallback.bind(this));
        $(f).setValue("");
    }
    fileUploadCallback(response) {
        if (this.createFileHtml != null) {
            const html = this.createFileHtml(response);
            this.editor.insertContent(html);
        }
    }
    defaultCreateFileHtml(response) {
        const data = response.jsonParse();
        if (data.Text == null || data.Href == null) {
            return;
        }
        return "<a href=\"" + data.Href + "\" target=\"_blank\">" + data.Text + "</a>";
    }
    fileUploadErrorCallback(response) {
    }
    imageUpload(blobInfo, success, failure, progress) {
        if (this.imageUploadUrlPath == "") {
            return;
        }
        var formData = new FormData();
        formData.append('file', blobInfo.blob(), blobInfo.filename());
        HttpClient.postForm(this.imageUploadUrlPath, formData, this.invokeImageUploadCallback.bind(this), this.invokeImageUploadCallback.bind(this), this.invokeImageUploadProgress.bind(this), {
            success: success,
            failure: failure
        });
    }
    invokeImageUploadCallback(response, context) {
        const result = response.jsonParse();
        const success = context.success;
        success(result.Location);
        if (this.imageUploadCallback != null) {
            this.imageUploadCallback(response, context);
        }
    }
    invokeImageUploadProgress(e) {
        if (this.imageUploading != null) {
            this.imageUploading(e);
        }
    }
    getContent() {
        return this.tinymce.get(this.textBoxId).getContent();
    }
}
//# sourceMappingURL=TinyMceTextBox.js.map