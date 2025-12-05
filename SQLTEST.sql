create database SQL_TEST

create table Customers(
 CustID INT PRIMARY KEY,
 CustName VARCHAR(100),
 Email VARCHAR(200),
 City VARCHAR(100)
)

INSERT INTO Customers (CustID, CustName, Email, City) VALUES
(1, 'Amit Sharma', 'amit.sharma@gmail.com', 'Mumbai'),
(2, 'Ravi Kumar', 'ravi.kumar@yahoo.com', 'Delhi'),
(3, 'Priya Singh', 'priya.singh@gmail.com', 'Pune'),
(4, 'John Mathew', 'john.mathew@hotmail.com', 'Bangalore'),
(5, 'Sara Thomas', 'sara.thomas@gmail.com', 'Kochi'),
(6, 'Nidhi Jain', 'nidhi.jain@gmail.com', NULL);
 

create table Products(
 ProductID INT PRIMARY KEY,
 ProductName VARCHAR(100),
 Price DECIMAL(10,2),
 Stock INT CHECK(Stock >= 0)
)

INSERT INTO Products (ProductID, ProductName, Price, Stock) VALUES
(101, 'Laptop Pro 14', 75000, 15),
(102, 'Laptop Air 13', 55000, 8),
(103, 'Wireless Mouse', 800, 50),
(104, 'Mechanical Keyboard', 3000, 20),
(105, 'USB-C Charger', 1200, 5),
(106, '27-inch Monitor', 18000, 10),
(107, 'Pen Drive 64GB', 600, 80);

create table Orders(
 OrderID INT PRIMARY KEY,
 CustID INT FOREIGN KEY REFERENCES Customers(CustID),
 OrderDate DATE,
 Status VARCHAR(20)
)

INSERT INTO Orders (OrderID, CustID, OrderDate, Status) VALUES
(5001, 1, '2025-01-05', 'Pending'),
(5002, 2, '2025-01-10', 'Completed'),
(5003, 1, '2025-01-20', 'Completed'),
(5004, 3, '2025-02-01', 'Pending'),
(5005, 4, '2025-02-15', 'Completed'),
(5006, 5, '2025-02-18', 'Pending');
 

create table OrderDetails(
 DetailID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
 Qty INT CHECK(Qty > 0)
)

INSERT INTO OrderDetails (DetailID, OrderID, ProductID, Qty) VALUES
(9001, 5001, 101, 1),
(9002, 5001, 103, 2),
 
(9003, 5002, 104, 1),
(9004, 5002, 103, 1),
 
(9005, 5003, 102, 1),
(9006, 5003, 105, 1),
(9007, 5003, 103, 3),
 
(9008, 5004, 106, 1),
 
(9009, 5005, 107, 4),
(9010, 5005, 104, 1),
 
(9011, 5006, 101, 1),
(9012, 5006, 107, 2);
 

create table Payments(
 PaymentID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 Amount DECIMAL(10,2),
 PaymentDate DATE
)

INSERT INTO Payments (PaymentID, OrderID, Amount, PaymentDate) VALUES
(7001, 5002, 3300, '2025-01-11'),
(7002, 5003, 62000, '2025-01-22'),
(7003, 5005, 4500, '2025-02-16');

select * from Customers
select * from Products
select * from Orders
select * from OrderDetails
select * from Payments


create table Employee(EmpID int primary key ,EmpName varchar(20))
insert into Employee values(100,'keerthu'),(200,'sanjay'),(300,'hari')
alter table Orders add EmpID int
update orders set EmpId = 100 where OrderID in (5001, 5003)
update orders set EmpID = 200 where OrderID in (5002,5006)
update orders set EmpID = 300 where OrderID in (5004,5005)

create table PriceHistory
(
    HisID int identity(1,1) primary key,
    ProductID int,
    OldPrice decimal(10,2),
    NewPrice decimal(10,2),
    changeddate datetime default getdate()
)

insert into pricehistory (ProductID, OldPrice, NewPrice)
values 
(101, 75000, 87000),
(102, 55000, 58900),
(103, 800, 6790),
(104, 3000, 7500),
(105, 1200, 2300);


create table paymentaudit
(
    auditid int identity(1,1) primary key,
    paymentid int,
    oldamount decimal(18,2),
    newamount decimal(18,2),
    oldpaymentdate date,
    newpaymentdate date,
    changeddate datetime default getdate()
);

insert into paymentaudit 
(paymentid, oldamount, newamount, oldpaymentdate, newpaymentdate, changeddate)
values 
(201, 3300, 4000, '2025-01-11', '2025-12-05', getdate()),
(202, 62000, 63000, '2025-01-22', '2025-12-05', getdate()),
(203, 4500, 4600, '2025-02-16', '2025-12-05', getdate());


alter table customers
add status varchar(20) default 'Active';

---------------------------------------------------------------------------------------------------------------------------------------------
 
            ------ SQL QUERIES ------

-- 1
select distinct * from Customers c inner join Orders o on c.CustID = o.CustID where OrderDate >= dateadd(day,-30,getdate())

--2
select top 3 p.ProductID , p.ProductName, sum(ods.Qty * p.Price) as totalsalesamount from OrderDetails ods join 
Products p on ods.ProductID = p.ProductID group by p.ProductID,p.ProductName order by totalsalesamount desc

--3
select c.City , count(distinct c.CustId) as totalcustomers ,count(o.OrderID) as totalorder from Customers c left join 
Orders o on c.CustID = o.CustID group by c.City

--4
select OrderID from OrderDetails group by OrderID having count(distinct ProductId) > 2

--5
select o.OrderId , sum(ods.Qty * p.price) as totalpayamount from Orders o inner join OrderDetails ods on o.OrderID = ods.OrderID 
inner join Products p on ods.ProductID = p.ProductID group by o.OrderID having sum(ods.Qty * p.Price) > 10000

--6
select c.CustID , c.CustName ,ods.ProductID from Customers c inner join Orders o on c.CustID = o.CustID inner join
OrderDetails ods on o.OrderID = ods.OrderID group by c.CustID,c.CustName,ods.ProductID having count(*) > 1

--7
select e.EmpID ,count(o.OrderID) as totalorder , sum(p.Amount) as totalamount from Employee e inner join Orders o on e.EmpID = o.EmpID
inner join Payments p on o.OrderID = p.OrderID group by e.EmpID

----------------------------------------------------------------------------------------------------------------------------------------------------------

               -------- VIEWS --------


create view vw_LowStockProducts with schemabinding , encryption as select ProductID,ProductName,Price,Stock from dbo.Products where Stock < 5

select * from vw_LowStockProducts

------------------------------------------------------------------------------------------------------------------------------------------------------------

             -------- FUNCTIONS ---------

--1

create function dbo.fn_getCustomerOrderHistoryy(@custid int)
returns @temp_order table
( orderid int,orderdate date,totalamount decimal(18,2))
as begin
insert into @temp_order (orderid, orderdate, totalamount)
select o.orderid,o.orderdate,sum(od.qty * p.price) as totalamount from orders o inner join 
orderdetails od on o.orderid = od.orderid inner join products p on od.productid = p.productid
where o.custid = @custid group by o.orderid, o.orderdate;
return
end

select * from fn_getCustomerOrderHistoryy(1)

--2

create function dbo.fn_GetCustomerLevel(@CustID int)
returns varchar(20)
as begin
declare @totalpurchase decimal(10,2)
declare @customerlvl varchar(20)
select @totalpurchase = sum(ods.Qty*p.Price) from Orders o inner join OrderDetails ods
inner join Products p on ods.ProductId = p.ProductID on o.CustID = @CustID
if @totalpurchase >100000
set @customerlvl = 'Platinum'
else if @totalpurchase >= 50000 and @totalpurchase <=100000
set @customerlvl = 'Gold'
else 
set @customerlvl = 'Silver'
return @customerlvl
end

SELECT dbo.fn_GetCustomerLevel(1) AS CustomerLevel;

-----------------------------------------------------------------------------------------------------------------------------------------------------

              -------- STORED PROCEDURES ---------


create procedure sp_updateproductprice(@productid int,@newprice decimal(10,2))
as begin
declare @oldprice decimal(10,2)
if @newprice <= 0
begin
raiserror('invalid price and it must be greater than 0', 16, 1)
return
end
select @oldprice = price from products where productid = @productid
if @oldprice is null
begin
raiserror('product not found', 16, 1)
return
end
update products set price = @newprice where productid = @productid
 insert into pricehistory (productid, oldprice, newprice) values (@productid, @oldprice, @newprice)
end

EXEC sp_updateproductprice 101, 80000;


-- 2

create procedure sp_SearchOrders (@CustomerName varchar(100) = null,@City varchar(100) = null,@ProductName varchar(100) = null,
@StartDate date = null,@EndDate date = null)
as begin
select o.OrderID, o.OrderDate, o.Status, c.CustName, c.City, p.ProductName, od.Qty, (od.Qty * p.Price) as ItemTotal
from Orders o inner join Customers c on o.CustID = c.CustID inner join OrderDetails od on o.OrderID = od.OrderID
inner join Products p on od.ProductID = p.ProductID where (@CustomerName is null or c.CustName like '%' + @CustomerName + '%')
and (@City is null or c.City = @City) and (@ProductName is null or p.ProductName like '%' + @ProductName + '%')
and (@StartDate is null or o.OrderDate >= @StartDate)
and (@EndDate is null or o.OrderDate <= @EndDate)
end


exec sp_SearchOrders;

---------------------------------------------------------------------------------------------------------------------

         --------- TRIGGERS ---------


--1

create trigger t1
on products
instead of delete
as begin
if exists (select * from orderdetails od inner join deleted d on od.productid = d.productid)
begin
raiserror('you cannot delete product it already exists', 16, 1)
rollback transaction
return
end
delete from products where productid in (select productid from deleted)
end

delete from products where productid = 101

--2

create trigger tr2
on Payments after update
as begin
insert into PaymentAudit(PaymentID, OldAmount, NewAmount)
select d.PaymentID, d.Amount as oldamount,i.Amount as newamount
from deleted d join inserted i on d.PaymentID = i.PaymentID;
end
 
update Payments set Amount = 5500 where PaymentID = 201;
 
select * from PaymentAudit

--3

create trigger t3
on customers
instead of delete
as
begin
update c
set status = 'Inactive' from customers c
inner join deleted d on c.custid = d.custid
where exists (select * from orders o where o.custid = d.custid )
delete c from customers c inner join deleted d on c.custid = d.custid
where not exists (select 1 from orders o where o.custid = d.custid )
end

delete from customers where custid = 1
delete from customers where custid = 6

