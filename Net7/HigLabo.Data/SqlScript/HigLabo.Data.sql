/*-------------------------------------
Dates
-------------------------------------*/
Create Table Dates
([Date] Date Not Null
,Constraint Dates_PrimaryKey Primary Key Clustered([Date])
) 
Go

With T0 As 
(
	select cast('2000/1/1' As DateTime) As [Date]
	union all
	select DateAdd(Day, 1, [Date])From T0
	where T0.[Date] < '2100/12/31'
)
insert into dbo.Dates
select * from T0 Option(MaxRecursion 0);

Go


/*-------------------------------------
GuidTable
-------------------------------------*/
Create Type GuidTable As Table
([Value] Uniqueidentifier Not Null
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



