
Create Procedure HigLabo_Data_LinkedServer_Create
(@ServerName Nvarchar(400)
,@DataSource Nvarchar(400)
,@DatabaseName Nvarchar(400)
,@UserName Nvarchar(100)
,@Password Nvarchar(100)
) 
As 

Exec sp_addlinkedserver 
@server=@ServerName, 
@srvproduct='',
@provider='sqlncli',
@datasrc=@DataSource,
@location='',
@provstr='',
@catalog=@DatabaseName

Exec sp_addlinkedsrvlogin
@rmtsrvname = @ServerName,
@useself = 'false',
@rmtuser = @UserName,
@rmtpassword = @Password

Exec sp_serveroption @ServerName, 'rpc out', true;

Go





Create Table dbo.Dates
([Date] Date Not Null
,Constraint Dates_PrimaryKey Primary Key Clustered([Date])
) As


With T0 As 
(
	select cast('1900/1/1' As DateTime) As [Date]
	union all
	select DateAdd(Day, 1, [Date])From T0
	where T0.[Date] < '9999/12/31'
)
insert into dbo.Dates
select * from T0 Option(MaxRecursion 0);

Go


Create Type GuidTable As Table
(GuidValue Uniqueidentifier not null
)


--http://msdn.microsoft.com/ja-jp/library/ms190273.aspx
ALTER TABLE MVideoChannel Add LastImportTime DateTimeOffset(7) Not Null 
Constraint LastImportTime_Default DEFAULT '2000/1/1 00:00:00'
GO
