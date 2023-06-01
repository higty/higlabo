/*-------------------------------------
GuidTable
-------------------------------------*/
Create Type GuidTable As Table
([Value] Uniqueidentifier Not Null
)

Go


/*-------------------------------------
Nvarchar32Table
-------------------------------------*/
Create Type Nvarchar32Table As Table
([Value] Nvarchar(32) Not Null
)

Go


/*-------------------------------------
Nvarchar64Table
-------------------------------------*/
Create Type Nvarchar64Table As Table
([Value] Nvarchar(64) Not Null
)

Go


/*-------------------------------------
Nvarchar128Table
-------------------------------------*/
Create Type Nvarchar128Table As Table
([Value] Nvarchar(128) Not Null
)

Go


/*-------------------------------------
Nvarchar256Table
-------------------------------------*/
Create Type Nvarchar256Table As Table
([Value] Nvarchar(256) Not Null
)

Go


/*-------------------------------------
Nvarchar400Table
-------------------------------------*/
Create Type Nvarchar400Table As Table
([Value] Nvarchar(400) Not Null
)

Go


/*-------------------------------------
NvarcharMaxTable
-------------------------------------*/
Create Type NvarcharMaxTable As Table
([Value] Nvarchar(max) Not Null
)

Go


/*-------------------------------------
IntTable
-------------------------------------*/
Create Type IntTable As Table
([Value] Int Not Null
)

Go


/*-------------------------------------
GuidGuidTable
-------------------------------------*/
Create Type GuidGuidTable As Table
(Value0 Uniqueidentifier Not Null
,Value1 Uniqueidentifier Not Null
)

Go


/*-------------------------------------
IntGuidTable
-------------------------------------*/
Create Type IntGuidTable As Table
(Value0 Int Not Null
,Value1 Uniqueidentifier Not Null
)

Go


/*-------------------------------------
IntGuidGuidTable
-------------------------------------*/
Create Type IntGuidGuidTable As Table
(Value0 Int Not Null
,Value1 Uniqueidentifier Not Null
,Value2 UniqueIdentifier Not Null
)

Go



