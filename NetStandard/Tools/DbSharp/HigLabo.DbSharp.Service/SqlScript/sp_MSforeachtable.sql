/****** Object:  StoredProcedure [dbo].[sp_MSforeachtable]    Script Date: 2019/10/12 14:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_MSforeachtable]
	@command1 nvarchar(2000), @replacechar nchar(1) = N'?', @command2 nvarchar(2000) = null,
  @command3 nvarchar(2000) = null, @whereand nvarchar(2000) = null,
	@precommand nvarchar(2000) = null, @postcommand nvarchar(2000) = null
AS
	declare @mscat nvarchar(12)
	select @mscat = ltrim(str(convert(int, 0x0002)))
	if (@precommand is not null)
		exec(@precommand)
   exec(N'declare hCForEachTable cursor global for select ''['' + REPLACE(schema_name(syso.schema_id), N'']'', N'']]'') + '']'' + ''.'' + ''['' + REPLACE(object_name(o.id), N'']'', N'']]'') + '']'' from dbo.sysobjects o join sys.all_objects syso on o.id = syso.object_id '
         + N' where OBJECTPROPERTY(o.id, N''IsUserTable'') = 1 ' + N' and o.category & ' + @mscat + N' = 0 '
         + @whereand)
	declare @retval int
	select @retval = @@error
	if (@retval = 0)
		exec @retval = dbo.sp_MSforeach_worker @command1, @replacechar, @command2, @command3, 0
	if (@retval = 0 and @postcommand is not null)
		exec(@postcommand)
	return @retval
