import { HttpClient, HttpRequestCallback, HttpResponse } from "./HttpClient.js";

export class TinyMceTextBox {
    private tinymce = window["tinymce"];

    public textBoxId = "";
    public tokenProvider = "";
    public dropboxApiKey = "";
    public googleDriveApiKey = "";
    public googleDriveClientId = "";
    public imageUploadUrlPath = "";
    public imageUploadCallback: HttpResponse;
    public imageUploading: EventListener;
    public useDarkMode = false;

    public initialize(id: string) {
        this.textBoxId = id;

        this.tinymce.init({
            selector: "#" + id,
            plugins: 'print preview powerpaste casechange importcss tinydrive searchreplace autolink autosave save directionality advcode visualblocks visualchars fullscreen image link media mediaembed template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists checklist wordcount a11ychecker imagetools textpattern noneditable help formatpainter permanentpen pageembed charmap tinycomments mentions quickbars linkchecker emoticons advtable export',
            tinydrive_token_provider: this.tokenProvider,
            tinydrive_dropbox_app_key: this.dropboxApiKey,
            tinydrive_google_drive_key: this.googleDriveApiKey,
            tinydrive_google_drive_client_id: this.googleDriveClientId,
            mobile: {
                plugins: 'print preview powerpaste casechange importcss tinydrive searchreplace autolink autosave save directionality advcode visualblocks visualchars fullscreen image link media mediaembed template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists checklist wordcount a11ychecker textpattern noneditable help formatpainter pageembed charmap mentions quickbars linkchecker emoticons advtable'
            },
            menu: {
                tc: {
                    title: 'Comments',
                    items: 'addcomment showcomments deleteallconversations'
                }
            },
            menubar: 'file edit view insert format tools table tc help',
            toolbar: 'undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment',
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
            images_upload_handler: this.imageUpload.bind(this),
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
            contextmenu: 'link image imagetools table configurepermanentpen',
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
            mentions_item_type: 'profile'
        });
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