# task 2

## first action create all table

```sql
create table Product (
    Id int primary key,
    "Name" text
);

create table Category (
    Id int primary key,
    "Name" text
);

create table ProductCategories (
    ProductId int foreign key references Product(Id),
    CategoryId int foreign key references Category(Id),
    primary key (ProductId, CategoryId)
);
```

## second action insert mock data

```sql
insert into Product
values
    (1,'Apple'),
    (2, 'Grokking Algorithms'),
    (3, 'MackBook pro 14');

insert into Category
values
    (1, 'Food'),
    (2, 'Book'),
    (3,'Technic'),
    (4,'Gift');

insert into ProductCategories
values
    (1,1),
    (2,2),
    (3,3),
    (3,4);
```

## third action make select query

```sql
select P."Name", C."Name" from Product as P 
    left join ProductCategories PC on P.Id = PC.ProductId
    left join Category C on PC.CategoryId = C.Id;
```
