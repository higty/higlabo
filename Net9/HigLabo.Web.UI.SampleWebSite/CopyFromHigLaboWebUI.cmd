SET path=C:\GitHub\higty\HigLabo\Net9\HigLabo.Web.UI\
SET targetPath="C:\GitHub\higty\HigLabo\Net9\HigLabo.Web.UI.SampleWebSite\

Mkdir "%targetPath%wwwroot\HigLabo\"
Copy "%path%StaticFiles" "%targetPath%wwwroot\HigLabo"

pause
