create database Sem3
go
use Sem3
go
create table Category(
	CategoryId int PRIMARY KEY IDENTITY,
	CategoryName varchar(100),
	CategoryType varchar(200)
)
go
create table Product(
	ProductId int PRIMARY KEY IDENTITY,
	ProductName varchar(100),
	Price float,
	Description ntext,
	ProductImage varchar(200),
	ProductStatus varchar(200),
	CategoryId int foreign key references Category(CategoryId)
)
go
create table News(
	NewsId int PRIMARY KEY IDENTITY,
	Title ntext,
	ShortContent ntext,
	LongContent ntext,
	NewsImage varchar(200),
	NewsType varchar(200)
)
go
create table Account(
	AccountId int PRIMARY KEY IDENTITY,
	FullName varchar(100),
	Email varchar(200),
	Password varchar(100),
	Phone varchar(20),
	Address nvarchar(200),
	Avatar varchar(200),
	AccountStatus varchar(200),
	AccountType bit
)
go
CREATE TABLE Comment
(
    CommentId int PRIMARY KEY IDENTITY,
	Content ntext,
	NewsId int foreign key references News(NewsId),
	AccountId int foreign key references Account(AccountId)
)
go
CREATE TABLE Cart
(
    CartId int PRIMARY KEY IDENTITY,
	Quantity int,
	TotalPrice Float,
	ProductId int foreign key references Product(ProductId),
	AccountId int foreign key references Account(AccountId),
)
go
CREATE TABLE Orders
(
    OrdersId int PRIMARY KEY IDENTITY,
	ReceiverName nvarchar(100),
	OrderDate datetime DEFAULT GETDATE(),
	ReceiverAddress nvarchar(200),
	ReceiverPhone nvarchar(20),
	Note ntext,
	CartId int foreign key references Cart(CartId)
)
go
CREATE TABLE OrderDetail
(
    OrderDetailId int PRIMARY KEY IDENTITY,
	OrderDetailStatus varchar(200),
	OrderId int foreign key references Orders(OrdersId)
)
go