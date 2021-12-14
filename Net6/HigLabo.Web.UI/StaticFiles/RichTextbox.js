import { $ } from "../HigLabo/HtmlElementQuery.js";
var RichTextbox = (function () {
    function RichTextbox() {
        this.element = null;
        this.editor = null;
        this.mentionList = new Array();
        this.imageUrlList = new Array();
    }
    RichTextbox.prototype.initialize = function (element) {
        if (element == null) {
            return;
        }
        this.element = element;
        if (window["ClassicEditor"] != null) {
            this.initializeClassicEditor();
        }
        $(window).resize(this.window_Resize.bind(this));
    };
    RichTextbox.prototype.initializeClassicEditor = function () {
        var element = this.element;
        var language = "ja";
        var editor = window["ClassicEditor"];
        editor.create(element, {
            language: language,
            toolbar: {
                items: ["undo", "redo", "emoji",
                    "link", "imageUpload", "fileUpload", "imageTextAlternative",
                    "removeFormat", "alignment", "bold", "italic", "highlight",
                    "blockQuote", "codeBlock",
                    "heading", "numberedList", "bulletedList",
                    "imageStyle:full", "imageStyle:side", "mediaEmbed",
                    "insertTable", "tableColumn", "tableRow", "mergeTableCells"
                ]
            },
            link: {
                addTargetToExternalLinks: true
            },
            mediaEmbed: {
                removeProviders: ['instagram', 'twitter', 'googleMaps', 'flickr', 'facebook']
            },
            codeBlock: {
                languages: [
                    { language: 'plaintext', label: 'Plain text' },
                    { language: 'html', label: 'HTML' },
                    { language: 'xml', label: 'HTML/XML' },
                    { language: 'css', label: 'CSS' },
                    { language: 'json', label: 'JSON' },
                    { language: 'javascript', label: 'JavaScript' },
                    { language: 'typescript', label: 'TypeScript' },
                    { language: 'sql', label: 'SQL' },
                    { language: 'graphql', label: 'GraphQL' },
                    { language: 'c', label: 'C' },
                    { language: 'cpp', label: 'C++' },
                    { language: 'csharp', label: 'C#' },
                    { language: 'java', label: 'Java' },
                    { language: 'php', label: 'PHP' },
                    { language: 'python', label: 'Python' },
                    { language: 'ruby', label: 'Ruby' },
                    { language: 'php', label: 'PHP' },
                    { language: 'kotlin', label: 'Kotlin' },
                    { language: 'go', label: 'GO' },
                    { language: 'swift', label: 'Swift' },
                    { language: 'bash', label: 'Bash' },
                    { language: 'powershell', label: 'PowerShell' },
                    { language: 'docker', label: 'Docker' },
                    { language: 'yaml', label: 'YAML' },
                    { language: 'diff', label: 'Diff' },
                ]
            },
            ckfinder: {
                uploadUrl: "/Api/File/CKEditor/Upload?CsrfToken=" + $("#CsrfToken").getValue(),
            },
            typing: {
                transformations: {
                    include: [],
                }
            },
            emoji: {
                images: this.imageUrlList
            },
            mention: {
                feeds: [
                    {
                        marker: '@',
                        feed: this.getFeedItem.bind(this),
                        minimumCharacters: 0,
                        itemRenderer: this.renderMention.bind(this)
                    }
                ],
            }
        }).then(this.editor_Initialized.bind(this));
    };
    RichTextbox.prototype.editor_Initialized = function (editor) {
        this.editor = editor;
        this.element.richTextbox = this;
        editor.model.document.on('change:data', this.documentData_Change.bind(this));
    };
    RichTextbox.prototype.window_Resize = function (e) {
        this.setWidth();
    };
    RichTextbox.prototype.regiseterReplaceTextareEventHandler = function (panel) {
        this.floatingRichTextboxPanel = panel;
        $(document).on("focusin", "[rich-textbox]", this.richTextArea_Focusin.bind(this));
    };
    RichTextbox.prototype.richTextArea_Focusin = function (target, e) {
        this.replaceTextbox(target);
        this.setFocus();
    };
    RichTextbox.prototype.replaceTextbox = function (element) {
        var tx = $(element);
        var div = $(this.floatingRichTextboxPanel);
        var rtx = this;
        if (rtx.targetTextbox == element) {
            return;
        }
        if (rtx.targetTextbox != null) {
            $(rtx.targetTextbox).setStyle("display", "block");
            rtx.targetTextbox.richTextbox = null;
        }
        rtx.targetTextbox = element;
        rtx.targetTextbox.richTextbox = this;
        tx.setStyle("display", "none");
        div.setStyle("display", "block");
        var ppl = tx.getParentElementList()[0];
        ppl.append(div.getFirstElement());
        this.setWidth();
    };
    RichTextbox.prototype.setWidth = function () {
        var rtx = this;
        if (rtx.targetTextbox == null) {
            return;
        }
        var tx = rtx.targetTextbox;
        var div = $(this.floatingRichTextboxPanel);
        var ppl = $(tx).getParentElementList()[0];
        div.setStyle("width", $(ppl).getOuterWidth() + "px");
    };
    RichTextbox.prototype.documentData_Change = function () {
    };
    RichTextbox.prototype.getFeedItem = function (queryText) {
        var _this = this;
        var tx = this;
        return new Promise(function (resolve) {
            setTimeout(function () {
                var itemsToDisplay = _this.mentionList
                    .filter(isItemMatching)
                    .slice(0, 10);
                resolve(itemsToDisplay);
            }, 100);
        });
        function isItemMatching(item) {
            return tx.filterMentionInvoke(item, queryText);
        }
    };
    RichTextbox.prototype.filterMentionInvoke = function (item, queryText) {
        if (this.filterMention != null && this.filterMention(item, queryText) == false) {
            return false;
        }
        var searchText = queryText.toLowerCase();
        return (searchText.length == 0 ||
            item.DisplayName.toLowerCase().includes(searchText) ||
            item.UserID.toLowerCase().includes(searchText));
    };
    RichTextbox.prototype.renderMention = function (mention) {
        var r = mention;
        var div = document.createElement("div");
        div.classList.add('user-record-panel');
        var usernameElement = document.createElement('span');
        usernameElement.classList.add('user-name-link');
        usernameElement.textContent = r.DisplayName;
        div.appendChild(usernameElement);
        return div;
    };
    RichTextbox.prototype.getEditor = function () {
        return this.editor;
    };
    RichTextbox.prototype.getData = function () {
        if (this.editor == null) {
            return $(this.element).getValue();
        }
        return this.editor.getData();
    };
    RichTextbox.prototype.setData = function (value) {
        if (this.element != null) {
            this.editor.setData(value);
        }
    };
    RichTextbox.prototype.setTextAreaValue = function (value) {
        $(this.element).setValue(value);
    };
    RichTextbox.prototype.setFocus = function () {
        if (this.editor == null) {
            return $(this.element).setFocus();
        }
        this.editor.editing.view.focus();
    };
    return RichTextbox;
}());
export { RichTextbox };
//# sourceMappingURL=RichTextbox.js.map