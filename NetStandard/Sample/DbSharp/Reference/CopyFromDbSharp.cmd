SET path="C:\GitHub\higty\HigLabo\NetStandard\Tools\DbSharp\
SET targetPath="C:\GitHub\higty\HigLabo\NetStandard\Sample\DbSharp\Reference\

Copy %path%HigLabo.DbSharp\bin\Release\netstandard2.0\HigLabo.DbSharp.dll" %targetPath%HigLabo.DbSharp.dll"
Copy %path%HigLabo.DbSharp.CodeGenerator\bin\Release\netstandard2.0\HigLabo.DbSharp.CodeGenerator.dll" %targetPath%HigLabo.DbSharp.CodeGenerator.dll"
Copy %path%HigLabo.DbSharp.SchemaData\bin\Release\netstandard2.0\HigLabo.DbSharp.SchemaData.dll" %targetPath%HigLabo.DbSharp.SchemaData.dll"
Copy %path%HigLabo.DbSharp.Service\bin\Release\netstandard2.0\HigLabo.DbSharp.Service.dll" %targetPath%HigLabo.DbSharp.Service.dll"
Copy %path%HigLabo.DbSharp.SqlServer\bin\Release\netstandard2.0\HigLabo.DbSharp.SqlServer.dll" %targetPath%HigLabo.DbSharp.SqlServer.dll"


pause
