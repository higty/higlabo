SET path=C:\GitHub\higty\HigLabo\Net6\HigLabo.Web.UI\
SET targetPath=C:\GitHub\higty\HigLabo\Net6\HigLaboWebSite\

Mkdir "%targetPath%wwwroot\HigLabo\"
Copy "%path%StaticFiles" "%targetPath%wwwroot\HigLabo"

Mkdir "%targetPath%wwwroot\HigLabo\ckeditor\"
Copy "%path%StaticFiles\ckeditor\ckeditor.js" "%targetPath%wwwroot\HigLabo\ckeditor\ckeditor.js"
Copy "%path%StaticFiles\ckeditor\ckeditor-language-ja.js" "%targetPath%wwwroot\HigLabo\ckeditor\ckeditor-language-ja.js"

Mkdir "%targetPath%wwwroot\HigLabo\linq\"
Copy "%path%StaticFiles\linq" "%targetPath%wwwroot\HigLabo\linq"

Mkdir "%targetPath%Views\HigLabo\"
Copy "%path%Views" "%targetPath%Views\HigLabo"

pause
