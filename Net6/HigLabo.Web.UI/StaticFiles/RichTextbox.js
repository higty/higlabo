import { $ } from "./HtmlElementQuery.js";
export class RichTextbox {
    constructor() {
        this.element = null;
        this.editor = null;
        this.language = "ja";
        this.mentionList = new Array();
        this.imageUrlList = new Array();
    }
    initialize(element) {
        if (element == null) {
            return;
        }
        this.element = element;
        if (window["ClassicEditor"] != null) {
            this.initializeClassicEditor();
        }
        $(window).resize(this.window_Resize.bind(this));
    }
    initializeClassicEditor() {
        var element = this.element;
        var language = "ja";
        var editor = window["ClassicEditor"];
        editor.create(element, {
            language: this.language,
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
    }
    editor_Initialized(editor) {
        this.editor = editor;
        this.element.richTextbox = this;
        editor.model.document.on('change:data', this.documentData_Change.bind(this));
    }
    window_Resize(e) {
        this.setWidth();
    }
    regiseterReplaceTextareEventHandler(panel) {
        this.floatingRichTextboxPanel = panel;
        $(document).on("focusin", "[rich-textbox]", this.richTextArea_Focusin.bind(this));
    }
    richTextArea_Focusin(target, e) {
        this.replaceTextbox(target);
        this.setFocus();
    }
    replaceTextbox(element) {
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
    }
    setWidth() {
        var rtx = this;
        if (rtx.targetTextbox == null) {
            return;
        }
        var tx = rtx.targetTextbox;
        var div = $(this.floatingRichTextboxPanel);
        var ppl = $(tx).getParentElementList()[0];
        div.setStyle("width", $(ppl).getOuterWidth() + "px");
    }
    documentData_Change() {
    }
    getFeedItem(queryText) {
        var tx = this;
        return new Promise(resolve => {
            setTimeout(() => {
                const itemsToDisplay = this.mentionList
                    .filter(isItemMatching)
                    .slice(0, 10);
                resolve(itemsToDisplay);
            }, 100);
        });
        function isItemMatching(item) {
            return tx.filterMentionInvoke(item, queryText);
        }
    }
    filterMentionInvoke(item, queryText) {
        if (this.filterMention != null && this.filterMention(item, queryText) == false) {
            return false;
        }
        const searchText = queryText.toLowerCase();
        return (searchText.length == 0 ||
            item.DisplayName.toLowerCase().includes(searchText) ||
            item.UserID.toLowerCase().includes(searchText));
    }
    renderMention(mention) {
        var r = mention;
        const div = document.createElement("div");
        div.classList.add('user-record-panel');
        const usernameElement = document.createElement('span');
        usernameElement.classList.add('user-name-link');
        usernameElement.textContent = r.DisplayName;
        div.appendChild(usernameElement);
        return div;
    }
    getEditor() {
        return this.editor;
    }
    getData() {
        if (this.editor == null) {
            return $(this.element).getValue();
        }
        return this.editor.getData();
    }
    setData(value) {
        if (this.element != null) {
            this.editor.setData(value);
        }
    }
    setTextAreaValue(value) {
        $(this.element).setValue(value);
    }
    setFocus() {
        if (this.editor == null) {
            return $(this.element).setFocus();
        }
        this.editor.editing.view.focus();
    }
}
//# sourceMappingURL=RichTextbox.js.map