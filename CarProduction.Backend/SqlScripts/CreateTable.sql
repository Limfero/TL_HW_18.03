use CarProduction

-- create tables 
create table Manufacturer(
	ManufacturerId int identity(1, 1) constraint PK_Manufacturer primary key,
	NameFactory nvarchar(100),
	Headquarters nvarchar(100),
	FoundationDate date
)

create table Car(
	CarId int identity(1, 1) constraint PK_Car primary key,
	Model nvarchar(100),
	BuildData date,
	Price numeric,
	ManufacturerId int constraint FK_Car_Manufacturer references Manufacturer(ManufacturerId)
)

create table CarDealership(
	DealershipId int identity(1, 1) constraint PK_CarDealership primary key,
	NameDealership nvarchar(100),
	Supplier int constraint FK_Factory_Id references Manufacturer(ManufacturerId)
)

create table PurchaseOrder(
	NameBuyer nvarchar(100),
	DealershipId int constraint FK_Dealership_Id references CarDealership(DealershipId),
	CarId int constraint FK_Car references Car(CarId),
)

--select all
select * from Manufacturer
select * from Car
select * from CarDealership
select * from PurchaseOrder

--insert data
insert into Manufacturer
	(NameFactory, Headquarters, FoundationDate)
values 
	('�������', '��������', '1966-06-20'),
	('BMW AG', '������', '1916-03-07'),
	('Mercedes-Benz', '��������', '1926-06-28')

insert into Car
	(Model, BuildData, Price, ManufacturerId)
values
	('Lada Granta �����', '2022-06-06', 678300, 1),
	('Lada Largus Cross', '2021-03-23', 1378900, 1),
	('BMW 4 ����� Coupe', '2022-01-11', 4450000, 2),
	('BMW iX', '2022-02-22', 9580000, 2),
	('Mercedes-Benz E 200', '2021-08-11', 5000000, 3),
	('Mercedes-Benz Sprinter VS30', '2021-02-11',  4448000, 3)

insert into CarDealership
	(NameDealership, Supplier)
values
	('��� ������� ����', 1),
	('����+', 1),
	('BMW', 2),
	('����� BMW', 2),
	('Mercedes-Benz', 3),
	('������', 3)

insert into PurchaseOrder
	(NameBuyer, DealershipId, CarId)
values
	('����', 1, 1),
	('����', 1, 2),
	('����', 2, 3),
	('����', 2, 4),
	('�����', 3, 5),
	('������', 3, 6),
	('������', 1, 2),
	('����', 3, 6),
	('����', 2, 3),
	('���', 3, 5)

