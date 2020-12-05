SET path="C:\GitHub\higty\HigLabo\Net5\
SET targetPath="C:\GitHub\higty\HigLabo\Net5\Tools\DbSharp\Reference\

Copy %path%HigLabo.Converter\bin\Release\net5.0\HigLabo.Converter.dll" %targetPath%HigLabo.Converter.dll"
Copy %path%HigLabo.Core\bin\Release\net5.0\HigLabo.Core.dll" %targetPath%HigLabo.Core.dll"
Copy %path%HigLabo.Mapper\bin\Release\net5.0\HigLabo.Mapper.dll" %targetPath%HigLabo.Mapper.dll"

Copy %path%HigLabo.CodeGenerator\bin\Release\net5.0\HigLabo.CodeGenerator.dll" %targetPath%HigLabo.CodeGenerator.dll"

Copy %path%HigLabo.Data\bin\Release\net5.0\HigLabo.Data.dll" %targetPath%HigLabo.Data.dll"
Copy %path%HigLabo.Data.SqlServer\bin\Release\net5.0\HigLabo.Data.SqlServer.dll" %targetPath%HigLabo.Data.SqlServer.dll"
Copy %path%HigLabo.Data.Oracle\bin\Release\net5.0\HigLabo.Data.Oracle.dll" %targetPath%HigLabo.Data.Oracle.dll"
Copy %path%HigLabo.Data.MySql\bin\Release\net5.0\HigLabo.Data.MySql.dll" %targetPath%HigLabo.Data.MySql.dll"
Copy %path%HigLabo.Data.PostgreSql\bin\Release\net5.0\HigLabo.Data.PostgreSql.dll" %targetPath%HigLabo.Data.PostgreSql.dll"
Copy %path%HigLabo.Data.SqLite\bin\Release\net5.0\HigLabo.Data.SqLite.dll" %targetPath%HigLabo.Data.SqLite.dll"

Copy %path%HigLabo.Net\bin\Release\net5.0\HigLabo.Net.dll" %targetPath%HigLabo.Net.dll"
Copy %path%HigLabo.Net.Ftp\bin\Release\net5.0\HigLabo.Net.Ftp.dll" %targetPath%HigLabo.Net.Ftp.dll"

Copy %path%HigLabo.Mail\bin\Release\net5.0\HigLabo.Mime.dll" %targetPath%HigLabo.Mime.dll"
Copy %path%HigLabo.Mail\bin\Release\net5.0\HigLabo.Mail.dll" %targetPath%HigLabo.Mail.dll"

pause
