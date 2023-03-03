create database simpledb;

use simpledb;

CREATE TABLE
    products (
        productId INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(20) NOT NULL,
        description VARCHAR(50),
        totalQuantity int not null,
        availableQuantity int not null,
        soldQuantity int not null,
        price DOUBLE NOT NULL
    );
    
    INSERT INTO
    products(name, description, price,totalQuantity,availableQuantity,soldQuantity)
VALUES ('Maggi', 'Ready To Cook', 12,12000,12000,0),
       ('GoodDay','Snacks',10,10000,10000,0),
       ('ParleG','Delicious',5,15000,15000,0),
       ('Sting','Energy Drink',20,20000,20000,0);

use simpledb;
SELECT * FROM products;

create table customers(custId int not null auto_increment primary key,
                      firstName varchar(255),
                      lastName varchar(255),
                      email varchar (255) unique,
                      contact varchar(20) unique,
                      permanentAdd varchar(255));
select * from customers;
 insert into customers(firstName,lastName,email,contact,permanentAdd)values('Rohit', 'Gore','rohitG123@gmail.com','759862356','Secrete HartTown,Wanavdi,Hadapsar,Pune');
insert into customers(firstName,lastName,email,contact,permanentAdd)values('Akshay', 'Tanpure','akashay123@gmail.com','7596782356','Awasari');
insert into customers(firstName,lastName,email,contact,permanentAdd)values('Akash', 'Ajab','akash123@gmail.com','7598645672','Pune');
insert into customers(firstName,lastName,email,contact,permanentAdd)values('Abhay', 'Navale','abhayG123@gmail.com','9856235690','Mumbai');
													
 select * from customers;
 
 create table orders(orderId int not null auto_increment primary key,
				     orderDate datetime,
                     custId int  not null,
					 constraint fk_customerId foreign key (custId) references customers(custId) on update CASCADE,
                     status varchar(200)
                     );
 
insert into orders(orderDate,custId,status)values('2022-07-28  12:35:25',1,'Approved');  
insert into orders(orderDate,custId,status)values('2022-07-23  12:35:25',1,'Inprogress');
insert into orders(orderDate,custId,status)values('2022-07-18  12:35:25',1,'Approved');  
insert into orders(orderDate,custId,status)values('2022-07-05  12:35:25',2,'Approved');
insert into orders(orderDate,custId,status)values('2022-07-10  12:35:25',2,'Approved');
insert into orders(orderDate,custId,status)values('2022-07-15  12:35:25',2,'Approved');
insert into orders(orderDate,custId,status)values('2022-07-20  12:35:25',2,'Approved');
select * from orders;

create table orderDetails( orderDetailsId int not null auto_increment primary key,
						   orderId int  not null,
					       constraint fk_orderId foreign key (orderId) references orders(orderId) on update CASCADE,
                           productId int  not null,
					       constraint fk_productId foreign key (productId) references products(productId) on update CASCADE,
                           quantity int  not null
                           );
                           
insert into orderDetails(orderId,productId,quantity) values(1,2,78);    
insert into orderDetails(orderId,productId,quantity) values(2,3,53);
insert into orderDetails(orderId,productId,quantity) values(3,1,30);
insert into orderDetails(orderId,productId,quantity) values(4,4,45);
/* */
select * from customers 
join orders on customers.custId=orders.custId join orderdetails on 
orders.orderid=orderdetails.orderId where orders.orderId=2;

select * from customers;

select * from orders;
select * from orderDetails;

create table address( addressId int not null auto_increment primary key,
                      custId int not null,
                      constraint fk_customerId_2 foreign key (custId) references customers(custId) on update CASCADE,
					  houseNo varchar(255),
                      landmark varchar(55),
                      city varchar(255),
                      state varchar(255),
                      country varchar(255),
                      pincode varchar(255));
                      
insert into address(custId,houseNo,landmark,city,state,country,pincode) 
values(1,'flat no.23,Niranjan heights','Behind chandrama garden','Satara','Maharashtra','India','410505'),
       (2,'flat no.45,Sai heights','Behind season mall','Nashik','Maharashtra','India','410503'),
       (3,'flat no.56,Neha heights','Behind avenue mall','Pune','Maharashtra','India','410504'),
       (4,'flat no.32,Shiv heights','Behind rubi hospital','Manchar','Maharashtra','India','410507');

select * from address;


