SET path="C:\GitHub\higty\HigLabo\Net6\HigLabo.Web.UI\
SET targetPath="C:\GitHub\higty\HigLabo\Net6\HigLaboWebSite\

Copy %path%StaticFiles\HigLabo.scss" %targetPath%wwwroot\HigLabo\HigLabo.scss"
Copy %path%StaticFiles\DateTime.ts" %targetPath%wwwroot\HigLabo\DateTime.ts"
Copy %path%StaticFiles\HigLaboVue.ts" %targetPath%wwwroot\HigLabo\HigLaboVue.ts"
Copy %path%StaticFiles\HtmlElementQuery.ts" %targetPath%wwwroot\HigLabo\HtmlElementQuery.ts"
Copy %path%StaticFiles\HttpClient.ts" %targetPath%wwwroot\HigLabo\HttpClient.ts"
Copy %path%StaticFiles\InputPropertyPanel.ts" %targetPath%wwwroot\HigLabo\InputPropertyPanel.ts"
Copy %path%StaticFiles\RichTextbox.ts" %targetPath%wwwroot\HigLabo\RichTextbox.ts"
Copy %path%StaticFiles\SelectTimePopupPanel.ts" %targetPath%wwwroot\HigLabo\SelectTimePopupPanel.ts"
Copy %path%StaticFiles\vue.js" %targetPath%wwwroot\HigLabo\vue.js"

Copy %path%StaticFiles\ckeditor\ckeditor.js" %targetPath%wwwroot\HigLabo\ckeditor\ckeditor.js"
Copy %path%StaticFiles\ckeditor\ckeditor-language-ja.js" %targetPath%wwwroot\HigLabo\ckeditor\ckeditor-language-ja.js"

Copy %path%Views\CommonTemplate.cshtml" %targetPath%Views\HigLabo\CommonTemplate.cshtml"
Copy %path%Views\EditRecordPanelTemplate.cshtml" %targetPath%Views\HigLabo\EditRecordPanelTemplate.cshtml"
Copy %path%Views\InputPropertyPanel.cshtml" %targetPath%Views\HigLabo\InputPropertyPanel.cshtml"
Copy %path%Views\InputPropertyPanelMessagePanel.cshtml" %targetPath%Views\HigLabo\InputPropertyPanelMessagePanel.cshtml"
Copy %path%Views\SelectTimePopupPanel.cshtml" %targetPath%Views\HigLabo\SelectTimePopupPanel.cshtml"
Copy %path%Views\ValidationResultMessagePanel.cshtml" %targetPath%Views\HigLabo\ValidationResultMessagePanel.cshtml"


pause
