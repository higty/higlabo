
Create Table AllDataTypeTable 
(PrimaryKeyColumn bigint not null
,TimestampColumn timestamp

,CharColumn char(100)
,VarCharColumn varchar(100)
,BitColumn bit(1)
,TinyIntColumn tinyint
,SmallIntColumn smallint 
,MediumIntColumn mediumint
,IntColumn int
,BigIntColumn bigint 
,TinyIntUnsignedColumn tinyint unsigned
,SmallIntUnsignedColumn smallint unsigned
,MediumIntUnsignedColumn mediumint unsigned
,IntUnsignedColumn int unsigned
,BigIntUnsignedColumn bigint unsigned
,FloatColumn float(8,4)
,DoubleColumn double(9,5)
,DecimalColumn decimal(10,5)
,NumericColumn numeric
,DateColumn date
,DateTimeColumn datetime
,TimeColumn time
,YearColumn year(4)
,BinaryColumn binary(100)
,VarBinaryColumn varbinary(100)
,TinyBlobColumn tinyblob
,MediumBlobColumn mediumblob
,BlobColumn blob(1024)
,LongBlobColumn longblob
,TinyTextColumn tinytext
,MediumTextColumn mediumtext
,TextColumn text(1024)
,LongTextColumn longtext
,GeometryColumn geometry
,EnumColumn enum('Default','Value1','Value2')
,SetColumn set('Value0','Value1','Value2')

,NotNullCharColumn char(100) not null
,NotNullVarCharColumn varchar(100) not null
,NotNullBitColumn bit(1) not null
,NotNullTinyIntColumn tinyint not null
,NotNullSmallIntColumn smallint not null
,NotNullMediumIntColumn mediumint not null
,NotNullIntColumn int not null
,NotNullBigIntColumn bigint not null
,NotNullTinyIntUnsignedColumn tinyint unsigned not null
,NotNullSmallIntUnsignedColumn smallint unsigned not null
,NotNullMediumIntUnsignedColumn mediumint unsigned not null
,NotNullIntUnsignedColumn int unsigned not null
,NotNullBigIntUnsignedColumn bigint unsigned not null
,NotNullFloatColumn float(8,4) not null
,NotNullDoubleColumn double(9,5) not null
,NotNullDecimalColumn decimal(10,5) not null
,NotNullNumericColumn numeric not null
,NotNullDateColumn date not null
,NotNullDateTimeColumn datetime not null
,NotNullTimeColumn time not null
,NotNullYearColumn year(4) not null
,NotNullBinaryColumn binary(100) not null
,NotNullVarBinaryColumn varbinary(100) not null
,NotNullTinyBlobColumn tinyblob not null
,NotNullTinyTextColumn tinytext not null
,NotNullBlobColumn blob(1024) not null
,NotNullTextColumn text(1024) not null
,NotNullMediumBlobColumn mediumblob not null
,NotNullMediumTextColumn mediumtext not null
,NotNullLongBlobColumn longblob not null
,NotNullLongTextColumn longtext not null
,NotNullGeometryColumn geometry not null
,NotNullEnumColumn enum('Default','Value1','Value2') not null
,NotNullSetColumn set('Value0','Value1','Value2') not null

);

ALTER TABLE AllDataTypeTable ADD CONSTRAINT PK_AllDataTypeTable 
PRIMARY KEY NONCLUSTERED (PrimaryKeyColumn);


DELIMITER //
Create Procedure Usp_OutputParameter
(inout CharColumn char(100)
,inout NCharColumn nchar(100)
,inout VarCharColumn varchar(100)
,inout NVarCharColumn nvarchar(100)
,inout BitColumn bit
,inout TinyIntColumn tinyint
,inout SmallIntColumn smallint 
,inout MediumIntColumn mediumint
,inout IntColumn int
,inout BigIntColumn bigint 
,inout TinyIntUnsignedColumn tinyint unsigned
,inout SmallIntUnsignedColumn smallint unsigned
,inout MediumIntUnsignedColumn mediumint unsigned
,inout IntUnsignedColumn int unsigned
,inout BigIntUnsignedColumn bigint unsigned
,inout FloatColumn float(8,4)
,inout DoubleColumn double(9,5)
,inout DecimalColumn decimal(10,5)
,inout NumericColumn numeric
,inout DateColumn date
,inout DateTimeColumn datetime(5)
,inout TimeColumn time
,inout YearColumn year(4)
,inout BinaryColumn binary(100)
,inout VarBinaryColumn varbinary(100)
 
,inout TinyBlobColumn tinyblob
,inout MediumBlobColumn mediumblob
,inout BlobColumn blob(1024)
,inout LongBlobColumn longblob
 
,inout TinyTextColumn tinytext
,inout TextColumn text(1234)
,inout MediumTextColumn mediumtext
,inout LongTextColumn longtext
 
,inout TimestampColumn timestamp
,inout EnumColumn enum('Default','Value1','Value2')
,inout SetColumn set('Value0','Value1','Value2')
)
Begin
Set BigIntColumn = BigIntColumn + 1;
Set SmallIntColumn = SmallIntColumn + 1;

End;
//
DELIMITER ;

Create Table IdentityTable 
(IntColumn int not null AUTO_INCREMENT
,TimestampColumn timestamp
,NVarCharColumn nvarchar(100)
,PRIMARY KEY (IntColumn)
);



Create Table MultiPkTable 
(BigIntColumn bigint not null
,IntColumn int not null
,FloatColumn float not null
,BinaryColumn binary(100)
,TimestampColumn timestamp
,VarBinaryColumn varbinary(100)
,BitColumn bit
,NCharColumn nchar(100)
,NVarCharColumn nvarchar(100)
);


ALTER TABLE MultiPkTable ADD CONSTRAINT PK_MultiPkTable 
PRIMARY KEY NONCLUSTERED (BigIntColumn,IntColumn,FloatColumn);




