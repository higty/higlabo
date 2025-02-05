SET path=C:\GitHub\higty\HigLabo\Net9\
SET targetPath=C:\GitHub\higty\HigLabo\Net9\HigLabo.DbSharp.Sample\Reference\

Copy "%path%HigLabo.Core\bin\Release\net9.0\HigLabo.Core.dll" "%targetPath%HigLabo.Core.dll"

Copy "%path%HigLabo.Data\bin\Release\net9.0\HigLabo.Data.dll" "%targetPath%HigLabo.Data.dll"
Copy "%path%HigLabo.Data.SqlServer\bin\Release\net9.0\HigLabo.Data.SqlServer.dll" "%targetPath%HigLabo.Data.SqlServer.dll"
Copy "%path%HigLabo.Data.Oracle\bin\Release\net9.0\HigLabo.Data.Oracle.dll" "%targetPath%HigLabo.Data.Oracle.dll"
Copy "%path%HigLabo.Data.MySql\bin\Release\net9.0\HigLabo.Data.MySql.dll" "%targetPath%HigLabo.Data.MySql.dll"
Copy "%path%HigLabo.Data.PostgreSql\bin\Release\net9.0\HigLabo.Data.PostgreSql.dll" "%targetPath%HigLabo.Data.PostgreSql.dll"
Copy "%path%HigLabo.Data.SqLite\bin\Release\net9.0\HigLabo.Data.SqLite.dll" "%targetPath%HigLabo.Data.SqLite.dll"


Copy "%path%HigLabo.DbSharp\bin\Release\net9.0\HigLabo.DbSharp.dll" "%targetPath%HigLabo.DbSharp.dll"
Copy "%path%HigLabo.DbSharp.SqlServer\bin\Release\net9.0\HigLabo.DbSharp.SqlServer.dll" "%targetPath%HigLabo.DbSharp.SqlServer.dll"

pause
