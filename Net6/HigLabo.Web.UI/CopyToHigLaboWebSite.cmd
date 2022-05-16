SET path=C:\GitHub\higty\HigLabo\Net6\HigLabo.Web.UI\
SET targetPath=C:\GitHub\higty\HigLabo\Net6\HigLaboWebSite\

Copy "%path%StaticFiles" "%targetPath%wwwroot\HigLabo"

Copy "%path%StaticFiles\ckeditor\ckeditor.js" "%targetPath%wwwroot\HigLabo\ckeditor\ckeditor.js"
Copy "%path%StaticFiles\ckeditor\ckeditor-language-ja.js" "%targetPath%wwwroot\HigLabo\ckeditor\ckeditor-language-ja.js"

Copy "%path%Views" "%targetPath%Views\HigLabo"

pause
