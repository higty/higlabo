/*-------------------------------------
GuidTable
-------------------------------------*/
Create Type GuidTable As Table
([Value] Uniqueidentifier NOT NULL
)

Go


/*-------------------------------------
DateTable
-------------------------------------*/
CREATE TYPE DateTable AS TABLE
([Value] Date NOT NULL
)
GO


/*-------------------------------------
Nvarchar32Table
-------------------------------------*/
Create Type Nvarchar32Table As Table
([Value] Nvarchar(32) NOT NULL
)

Go


/*-------------------------------------
Nvarchar64Table
-------------------------------------*/
Create Type Nvarchar64Table As Table
([Value] Nvarchar(64) NOT NULL
)

Go


/*-------------------------------------
Nvarchar128Table
-------------------------------------*/
Create Type Nvarchar128Table As Table
([Value] Nvarchar(128) NOT NULL
)

Go


/*-------------------------------------
Nvarchar256Table
-------------------------------------*/
Create Type Nvarchar256Table As Table
([Value] Nvarchar(256) NOT NULL
)

Go


/*-------------------------------------
Nvarchar400Table
-------------------------------------*/
Create Type Nvarchar400Table As Table
([Value] Nvarchar(400) NOT NULL
)

Go


/*-------------------------------------
NvarcharMaxTable
-------------------------------------*/
Create Type NvarcharMaxTable As Table
([Value] Nvarchar(max) NOT NULL
)

Go


/*-------------------------------------
IntTable
-------------------------------------*/
Create Type IntTable As Table
([Value] Int NOT NULL
)

Go








/*-------------------------------------
GuidGuidTable
-------------------------------------*/
Create Type GuidGuidTable As Table
(Value0 Uniqueidentifier NOT NULL
,Value1 Uniqueidentifier NOT NULL
)

Go


/*-------------------------------------
IntGuidTable
-------------------------------------*/
Create Type IntGuidTable As Table
(Value0 Int NOT NULL
,Value1 Uniqueidentifier NOT NULL
)

Go


/*-------------------------------------
IntGuidGuidTable
-------------------------------------*/
Create Type IntGuidGuidTable As Table
(Value0 Int NOT NULL
,Value1 Uniqueidentifier NOT NULL
,Value2 UniqueIdentifier NOT NULL
)

Go


/*-------------------------------------
Nvarchar256GuidTable
-------------------------------------*/
Create Type Nvarchar256GuidTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] UNIQUEIDENTIFIER NOT NULL
)

Go


/*-------------------------------------
Nvarchar256BitTable
-------------------------------------*/
Create Type Nvarchar256BitTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] BIT NOT NULL
)

Go


/*-------------------------------------
Nvarchar256Nvarchar256Table
-------------------------------------*/
Create Type Nvarchar256Nvarchar256Table As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] Nvarchar(256) NOT NULL
)

Go


/*-------------------------------------
Nvarchar256IntTable
-------------------------------------*/
Create Type Nvarchar256IntTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] INT NOT NULL
)

Go


/*-------------------------------------
Nvarchar256FloatTable
-------------------------------------*/
Create Type Nvarchar256FloatTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] FLOAT NOT NULL
)

Go


/*-------------------------------------
Nvarchar256DateTable
-------------------------------------*/
Create Type Nvarchar256DateTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] DATE NOT NULL
)

Go


/*-------------------------------------
Nvarchar256TimeTable
-------------------------------------*/
Create Type Nvarchar256TimeTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] TIME NOT NULL
)

Go


/*-------------------------------------
Nvarchar256DateTimeOffsetTable
-------------------------------------*/
Create Type Nvarchar256DateTimeOffsetTable As Table
([Value0] Nvarchar(256) NOT NULL
,[Value1] DateTimeOffset(7) NOT NULL
)

Go



