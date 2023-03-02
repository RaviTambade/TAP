create database simpledb;
drop database simpledb;
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
                      
 insert into customers(firstName,lastName,email,contact,permanentAdd)values('Rohit', 'Gore','rohitG123@gmail.com','759862356','Secrete HartTown,Wanavdi,Hadapsar,Pune');
 
 select * from customers;
 
 create table orders(orderId int not null auto_increment primary key,
				     orderDate datetime,
                     custId int  not null,
					 constraint fk_customerId foreign key (custId) references customers(custId) on update CASCADE,
                     status varchar(200)
                     );
 
insert into orders(orderDate,custId,status)values(now(),1,'Approved');    

select * from orders;

create table orderDetails( orderDetailsId int not null auto_increment primary key,
						   orderId int  not null,
					       constraint fk_orderId foreign key (orderId) references orders(orderId) on update CASCADE,
                           productId int  not null,
					       constraint fk_productId foreign key (productId) references products(productId) on update CASCADE,
                           quantity int  not null
                           );
                           
insert into orderDetails(orderId,productId,quantity) values(1,2,50);    

select * from orders
where custId in(select custId from customers where custId=1);

     