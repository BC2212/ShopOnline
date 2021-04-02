create proc Q_Product_GetProducts
as
select * from Product
go

create proc Q_Product_GetProductByID
@ProductID int
as
select * from Product where @ProductID = ProductID
go

create proc Q_Product_InsertUpdate
@ProductID int,
@ProductName nvarchar(50),
@Vendor nvarchar(50),
@Quantity int
as
if exists(select 1 from Product where @ProductID = ProductID)
begin
	update Product
	set ProductName = @ProductName, Vendor = @Vendor, Quantity = @Quantity
	where @ProductID = ProductID
end
else
begin
	insert into Product(ProductName, Vendor, Quantity)

	values (@ProductName, @Vendor, @Quantity)
end
go

create proc Q_Product_Delete
@ProductID int
as
if exists(select 1 from Product where @ProductID = ProductID)
begin
	delete from Product where @ProductID = ProductID
end