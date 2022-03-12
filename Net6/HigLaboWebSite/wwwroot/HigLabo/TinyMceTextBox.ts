import { $, HtmlElementQuery } from "./HtmlElementQuery.js";
import { HttpClient, HttpRequestCallback, HttpResponse } from "./HttpClient.js";

export class TinyMceTextBox {
    private tinymce = window["tinymce"];
    private fileUploadElement: HTMLInputElement;
    
    public editor;
    public textBoxId = "";
    public tokenProvider = "";
    public dropboxApiKey = "";
    public googleDriveApiKey = "";
    public googleDriveClientId = "";
    public fileUploadUrlPath = "";
    public createFileHtml;
    public imageUploadUrlPath = "";
    public imageUploadCallback: HttpRequestCallback;
    public imageUploading: EventListener;
    public useDarkMode = false;

    constructor() {
        this.createFileHtml = this.defaultCreateFileHtml;
    }
    public initialize(id: string) {
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
            //autosave_ask_before_unload: true,
            //autosave_interval: '30s',
            //autosave_prefix: '{path}{query}-{id}-',
            //autosave_restore_when_empty: false,
            //autosave_retention: '2m',
            image_advtab: true,
            link_list: [
            //    { title: 'My page 1', value: 'https://www.tiny.cloud' },
            //    { title: 'My page 2', value: 'http://www.moxiecode.com' }
            ],
            image_list: [
            //    { title: 'My page 1', value: 'https://www.tiny.cloud' },
            //    { title: 'My page 2', value: 'http://www.moxiecode.com' }
            ],
            image_class_list: [
            //    { title: 'None', value: '' },
            //    { title: 'Some class', value: 'class-name' }
            ],
            importcss_append: true,
            templates: [
            //    { title: 'New Table', description: 'creates a new table', content: '<div class="mceTmpl"><table width="98%%"  border="0" cellspacing="0" cellpadding="0"><tr><th scope="col"> </th><th scope="col"> </th></tr><tr><td> </td><td> </td></tr></table></div>' },
            //    { title: 'Starting my story', description: 'A cure for writers block', content: 'Once upon a time...' },
            //    { title: 'New list with dates', description: 'New List with dates', content: '<div class="mceTmpl"><span class="cdate">cdate</span><br /><span class="mdate">mdate</span><h2>My List</h2><ul><li></li><li></li></ul></div>' }
            ],
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
            /*
            The following settings require more configuration than shown here.
            For information on configuring the mentions plugin, see:
            https://www.tiny.cloud/docs/plugins/premium/mentions/.
            */
            mentions_selector: '.mymention',
            //mentions_fetch: mentions_fetch,
            //mentions_menu_hover: mentions_menu_hover,
            //mentions_menu_complete: mentions_menu_complete,
            //mentions_select: mentions_select,
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
    private initializeFileUploadElement(editor) {
        const pl = $(editor.getElement()).getParentElementList()[0] as HTMLElement;
        const fd = document.createElement("input") as HTMLInputElement;
        fd.type = "file";
        $(fd).setStyle("display", "none");
        pl.appendChild(fd);
        this.fileUploadElement = fd;
    }
    private fileSelected(e: Event) {
        if (this.fileUploadUrlPath == "") { return; }
        const f = this.fileUploadElement;
        const formData = new FormData();
        for (var i = 0; i < f.files.length; i++) {
            formData.append(f.name, f.files[i]);
        }
        HttpClient.postForm(this.fileUploadUrlPath, formData, this.fileUploadCallback.bind(this), this.fileUploadErrorCallback.bind(this));

        $(f).setValue("");
    }
    private fileUploadCallback(response: HttpResponse) {
        if (this.createFileHtml != null) {
            const html = this.createFileHtml(response);
            this.editor.insertContent(html);
        }
    }
    private defaultCreateFileHtml(response: HttpResponse) {
        const data = response.jsonParse();
        if (data.Text == null || data.Href == null) { return; }

        return "<a href=\"" + data.Href + "\" target=\"_blank\">" + data.Text + "</a>";
    }
    private fileUploadErrorCallback(response: HttpResponse) {

    }
    private imageUpload(blobInfo, success, failure, progress) {
        if (this.imageUploadUrlPath == "") { return; }
        var formData = new FormData();
        formData.append('file', blobInfo.blob(), blobInfo.filename());
        HttpClient.postForm(this.imageUploadUrlPath, formData
            , this.invokeImageUploadCallback.bind(this)
            , this.invokeImageUploadCallback.bind(this)
            , this.invokeImageUploadProgress.bind(this)
            , {
                success: success,
                failure: failure
            }
        );
    }
    private invokeImageUploadCallback(response: HttpResponse, context: any) {
        const result = response.jsonParse();
        const success = context.success;
        success(result.Location);
        if (this.imageUploadCallback != null) {
            this.imageUploadCallback(response, context);
        }
    }
    private invokeImageUploadProgress(e: Event) {
        if (this.imageUploading != null) {
            this.imageUploading(e);
        }
    }

    public getContent() {
        return this.tinymce.get(this.textBoxId).getContent();
    }
}