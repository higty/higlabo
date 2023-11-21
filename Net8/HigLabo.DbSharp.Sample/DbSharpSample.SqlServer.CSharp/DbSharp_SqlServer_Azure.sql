
Create Type MyTableType As Table
(BigIntColumn bigint not null
,BinaryColumn binary(100)
,ImageColumn image
--,TimestampColumn timestamp
,VarBinaryColumn varbinary(100)
,BitColumn bit
,CharColumn char(100)
,NCharColumn nchar(100)
,NTextColumn ntext
,NVarCharColumn nvarchar(100)
,TextColumn text
,VarCharColumn varchar(100)
,XmlColumn xml
,DateTimeColumn datetime
,SmallDateTimeColumn smalldatetime
,DateColumn date
,TimeColumn time
,DateTime2Column datetime2
,DecimalColumn decimal
,MoneyColumn money
,SmallMoneyColumn smallmoney
,FloatColumn float
,IntColumn int
,RealColumn real
,UniqueIdentifierColumn uniqueidentifier
,SmallIntColumn smallint 
,TinyIntColumn tinyint
,DateTimeOffsetColumn datetimeoffset(7)
/*
,SqlVariantColumn sql_variant 
A bug exist at SqlVariant http://connect.microsoft.com/VisualStudio/feedback/details/476281/sql-server-2008-table-valued-parameter-tvp-with-column-type-sql-variant-cannot-be-filled-with-datatable-with-column-type-system-object
,GeometryColumn geometry 
,GeographyColumn geography 
,HierarchyIDColumn Hierarchyid 
*/
,EnumColumn nvarchar(20)
)

 
Go

Create Type MyTableType1 As Table
(BigIntColumn bigint not null
,BinaryColumn binary(100)
,ImageColumn image
,VarBinaryColumn varbinary(100)
) 

Go



--Drop Table AllDataTypeTable_Azure 

Create Table AllDataTypeTable_Azure  
(PrimaryKeyColumn bigint not null
,TimestampColumn timestamp

,BigIntColumn bigint 
,BinaryColumn binary(100)
,ImageColumn image
,VarBinaryColumn varbinary(100)
,BitColumn bit
,CharColumn char(100)
,NCharColumn nchar(100)
,NTextColumn ntext
,NVarCharColumn nvarchar(100)
,TextColumn text
,VarCharColumn varchar(100)
,XmlColumn xml
,DateTimeColumn datetime
,SmallDateTimeColumn smalldatetime
,DateColumn date
,TimeColumn time
,DateTime2Column datetime2
,DecimalColumn decimal
,MoneyColumn money
,SmallMoneyColumn smallmoney
,FloatColumn float
,IntColumn int
,RealColumn real
,UniqueIdentifierColumn uniqueidentifier
,SmallIntColumn smallint 
,TinyIntColumn tinyint
,DateTimeOffsetColumn datetimeoffset(7)
,SqlVariantColumn sql_variant
,EnumColumn nvarchar(20)

,NotNullBigIntColumn bigint not null
,NotNullBinaryColumn binary(100) not null
,NotNullImageColumn image not null
,NotNullVarBinaryColumn varbinary(100) not null
,NotNullBitColumn bit not null
,NotNullCharColumn char(100) not null
,NotNullNCharColumn nchar(100) not null
,NotNullNTextColumn ntext not null
,NotNullNVarCharColumn nvarchar(100) not null
,NotNullTextColumn text not null
,NotNullVarCharColumn varchar(100) not null
,NotNullXmlColumn xml not null
,NotNullDateTimeColumn datetime not null
,NotNullSmallDateTimeColumn smalldatetime not null
,NotNullDateColumn date not null
,NotNullTimeColumn time not null
,NotNullDateTime2Column datetime2 not null
,NotNullDecimalColumn decimal not null
,NotNullMoneyColumn money not null
,NotNullSmallMoneyColumn smallmoney not null
,NotNullFloatColumn float not null
,NotNullIntColumn int not null
,NotNullRealColumn real not null
,NotNullUniqueIdentifierColumn uniqueidentifier not null
,NotNullSmallIntColumn smallint not null
,NotNullTinyIntColumn tinyint not null
,NotNullDateTimeOffsetColumn datetimeoffset(7) not null
,NotNullSqlVariantColumn sql_variant not null
,NotNullEnumColumn nvarchar(20) not null

,Constraint [PK_AllDataTypeTable_Azure] Primary Key NonClustered (PrimaryKeyColumn)
)

Go


/*
SQL TableValue parameter
C# SqlDbType.Structure, DataTable --> p.TypeName
Structured only used on parameter type
*/
Create Procedure Usp_Structure
(@BigIntColumn bigint out
,@StructuredColumn as MyTableType readonly
) As 

Set @BigIntColumn = @BigIntColumn + 
(
	select Sum(BigIntColumn) from @StructuredColumn where EnumColumn = 'Default'
) 


Go


Create Procedure Usp_OutputParameter
(@BigIntColumn bigint out
,@BinaryColumn binary(100) out
,@ImageColumn image 
,@VarBinaryColumn varbinary(100) out
,@BitColumn bit out
,@CharColumn char(100) out
,@NCharColumn nchar(100) out
,@NTextColumn ntext 
,@NVarCharColumn nvarchar(100) out
,@TextColumn text 
,@VarCharColumn varchar(100) out
,@XmlColumn xml out
,@DateTimeColumn datetime out
,@SmallDateTimeColumn smalldatetime out
,@DateColumn date out
,@TimeColumn time out
,@DateTime2Column datetime2 out
,@DecimalColumn decimal out
,@MoneyColumn money out
,@SmallMoneyColumn smallmoney out
,@FloatColumn float out
,@IntColumn int out
,@RealColumn real out
,@UniqueIdentifierColumn uniqueidentifier out
,@SmallIntColumn smallint  out
,@TinyIntColumn tinyint out
,@DateTimeOffsetColumn datetimeoffset(7) out
,@GeometryColumn geometry out 
,@GeographyColumn geography out
,@HierarchyIDColumn Hierarchyid 
,@EnumColumn nvarchar(20) out
) As 

Set @BigIntColumn = @BigIntColumn + 1 
Set @SmallIntColumn = @SmallIntColumn + 1


Go


Create Table IdentityTable 
(IntColumn int not null IDENTITY(1,1)
,NVarCharColumn nvarchar(100)
)

Go

ALTER TABLE [dbo].[IdentityTable] ADD CONSTRAINT [PK_IdentityTable] 
PRIMARY KEY NONCLUSTERED ([IntColumn])

GO

Create Table RowGuidColTable 
(RowGuidColumn uniqueidentifier not null ROWGUIDCOL Default NEWSEQUENTIALID()
,NVarCharColumn nvarchar(100)
)

Go

ALTER TABLE [dbo].[RowGuidColTable] ADD CONSTRAINT [PK_RowGuidColTable] 
PRIMARY KEY CLUSTERED ([RowGuidColumn])

GO


Create Table MultiPkTable 
(BigIntColumn bigint not null
,IntColumn int not null
,FloatColumn float not null
,BinaryColumn binary(100)
,TimestampColumn timestamp
,VarBinaryColumn varbinary(100)
,BitColumn bit
,NCharColumn nchar(100)
,NTextColumn ntext
,NVarCharColumn nvarchar(100)
)

Go

ALTER TABLE [dbo].[MultiPkTable] ADD CONSTRAINT [PK_MultiPkTable] 
PRIMARY KEY NONCLUSTERED ([BigIntColumn],[IntColumn],[FloatColumn])

GO

Create Procedure Usp_SelectMultiTable 
As

select * from AllDataTypeTable with(nolock)
select * from IdentityTable with(nolock)
select * from RowGuidColTable with(nolock)
select * from MultiPkTable with(nolock)

Go
