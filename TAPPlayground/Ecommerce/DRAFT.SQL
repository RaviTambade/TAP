CREATE DATABASE Ecommerce;
USE Ecommerce;


CREATE TABLE users( user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, email VARCHAR(25) UNIQUE NOT NULL, contact_number VARCHAR(20) NOT NULL UNIQUE,password VARCHAR(15) NOT NULL);
CREATE TABLE accounts(account_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,account_number BIGINT UNIQUE, ifsc_code VARCHAR(50) ,register_date DATETIME ,balance DOUBLE);
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(25), last_name VARCHAR(25),email VARCHAR(25) UNIQUE NOT NULL,contact_number VARCHAR(20) UNIQUE NOT NULL, password VARCHAR(15) NOT NULL,account_number BIGINT NOT NULL ,CONSTRAINT fk_account_no3 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE employees(employee_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,empfirst_name VARCHAR(100),emplast_name VARCHAR(50),birth_date DATE,hire_date DATE,contact_number VARCHAR(20),email VARCHAR(50),password VARCHAR(15) NOT NULL,photo varchar (50),reports_to INT NOT NULL,account_number BIGINT NOT NULL ,CONSTRAINT fk_account_no4 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL, CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent', 'billing') NOT NULL,house_number VARCHAR(20),landmark VARCHAR(25) NOT NULL,city VARCHAR(25) NOT NULL,state VARCHAR(25) NOT NULL,country VARCHAR(25) NOT NULL,pincode VARCHAR(25) NOT NULL);
CREATE TABLE categories(category_id INT PRIMARY KEY AUTO_INCREMENT, category_title VARCHAR(20),description VARCHAR (100),image VARCHAR(50)) ;
CREATE TABLE products (product_id INT PRIMARY KEY AUTO_INCREMENT,product_title VARCHAR(20) NOT NULL,description VARCHAR(50),stock_available INT NOT NULL,unit_price DOUBLE NOT NULL,image VARCHAR(40),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY(category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME DEFAULT CURRENT_TIMESTAMP,shipped_date DATETIME DEFAULT CURRENT_TIMESTAMP,cust_id INT NOT NULL,CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,total double ,status ENUM('delivered','initiated','inprogress','cancelled','approved') NOT NULL);
CREATE TABLE suppliers(supplier_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR (50),supplier_name VARCHAR (20),contact_number VARCHAR (20),email VARCHAR(20),address VARCHAR(200),city VARCHAR(50),state VARCHAR(20),account_number BIGINT NOT NULL,CONSTRAINT fk_account_no5 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE); 
CREATE TABLE orderdetails(orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE,supplier_id INT NOT NULL,CONSTRAINT fk_supplier_id FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id) ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL,discount float default 0);  
CREATE TABLE payments(payment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY ,payment_date DATETIME, payment_mode ENUM('cash on delivery','online payment'),transection_id INT NOT NULL,order_id INT NOT NULL, CONSTRAINT fk_order_id_1 FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE shippers(shipper_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR(25),contact_number VARCHAR (20),email VARCHAR(50),account_number BIGINT NOT NULL,CONSTRAINT account_number01 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE transactions(transaction_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,from_account_number BIGINT NOT NULL,CONSTRAINT fk_account_no FOREIGN KEY(from_account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE,to_account_number BIGINT NOT NULL ,CONSTRAINT fk_acountno2 FOREIGN KEY(to_account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE, transaction_date DATETIME,amount DOUBLE);


/*
create table roles();
*/


/*trigger for customer in users*/
DELIMITER //
CREATE TRIGGER insert_user AFTER INSERT ON customers 
FOR EACH ROW 
BEGIN 
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
END //
DELIMITER ;

/*trigger for employees in users*/
DELIMITER //
CREATE TRIGGER insert_employee AFTER INSERT ON employees 
FOR EACH ROW 
BEGIN 
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
END //
DELIMITER ;

INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545654,'MAHB0000286','2023-03-01 12:40:35',22500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545656,'UNB0000286','2023-04-15 02:45:35',2250025);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545657,'BARBO0000286','2023-03-04 02-40-35',225700);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545658,'MAHB000299','2022-03-16  03-40-35',24540);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545659,'MAHB0000886','2022-05-01 04-40-35',454500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545660,'AXIS0000286','2021-08-01 07-40-35',2352500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025545655,'AXIS0000286','2021-08-01 07-40-35',2352500);


INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES(39025545655,39025545658,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025545656,39025545660,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025545657,39025545659,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES(39025545660,39025545658,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025545655,39025545659,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025545658,39025545655,'2023-03-01 12:40:35',22500);


select * from transactions;


INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Sahil','Mankar','sahil.m@gmail.com','9960916323','sahil@123',39025545654);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Abhay','Navle','abhay.navale@gmail.com','9075966080','sahil@123',39025545655);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Sachin','Patil','sachin.patil@gmail.com','9881723458','sahil@123',39025545655);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Minal','Sagade','minal.sagade@outlook.com','9887454372','sahil@123',39025545656);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Jai','Kinikar','jai.kinikar@gmail.com','98543234','sahil@123',39025545655);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Rakhi','Sharma','rakhi.sharma@gmail.com','9845834534','sahil@123',39025545657);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Shivam','Pethe','shivam.pethe@gmai.com','9881734798','sahil@123',39025545660);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Manisha','Pant','manisha.pant@gmail.com','9884578673','sahil@123',39025545660);


INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Akash','Ajab','1999-09-15','2022-09-07','8756320158','AkAjab@gmail.com','AK123654' ,'./images/crackjack.jpg', 2,39025545656);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Shubham','Teli','1999-02-10','2020-07-05','9876320158','Steli@gmail.com','ST5269' ,'./images/ST.jpg', 1,39025545656);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Sahil','Mankar','1997-05-19','2021-07-07','8756789158','Sahil@gmail.com','SM569654' ,'./images/SM.jpg', 1,39025545655);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Shubham','Navale','1995-07-25','2020-05-04','9996320158','SNavale@gmail.com','SN56987' ,'./images/SN.jpg', 3,39025545656);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Rohit','Gore','1996-05-12','2022-09-07','7776320158','RGore@gmail.com','RG123654' ,'./images/RG.jpg', 4,39025545660);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('Pragati','Bangar','1998-05-10','2022-11-09','9666320158','PBangar@gmail.com','PB123654' ,'./images/PB.jpg', 5,39025545657);


/*possible vales  for addressmode:1:only residential ,2:only delivery address,3:residentail and delivery*/
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'permanent','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'billing','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','121321');


INSERT INTO categories(category_title,description,image)values('biscuits','Daily Snack with Tea','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('colddrinks','Summer Drink','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('snacks','For daily Breakfast','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('electronics','Domastic Equipments','./images/crackjack.jpg');


INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id) VALUES('ParleG','tasty biscuits',20000,10,'./images/Parleg.jpg',1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('GoodDay','tasty cookies',50000,15,'./images/goodday.jpg',1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('MariGold','tasty biscuits',40000,16,'./images/marigold.jpg',1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('20-20','tasty biscuits', 70000, 10,'./images/2020.jpg',1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg',1);

INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Pepsi','Drinks Any time',50000,40,'./images/Pepsi.jpg',2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Fizz','Making from apple',2000,25,'./images/Fizz.jpg',2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Slice','Making from Mangoes',10000,40,'./images/Slice.jpg',2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('coco-cola','Drinking any time',6000,40,'./images/coco_cola.jpg',2);

INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Maggi','Making in 2 minutes',500,12,'./images/Maggi.jpg',3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('FrenchFries','Making for instatnt eat',1000,40,'./images/Francci.jpg',3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Idli','Light snack',20000,20,'./images/Idli.jpg',3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Makkesns','Fried snack',600,60,'./images/Makkens.jpg',3);

INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Tv','Entertenment Gadget',50,12000,'./images/samsung.jpg',4);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Mobiles','Communication Purpose',100,10,'./images/Oppo.jpg',4);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Fiidge','Kitchen Use',200,150,'./images/Samsung.jpg',4);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES('Laptops','Working Gaget',60,60000,'./images/Dell.jpg',4);


INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,50.00,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 2, 82.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 6,20.00,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,40.00,'inprogress');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 4,50.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 8,30.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,45.00,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 2,45.00,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,50.00,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 2,35.00,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,50.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,25.00,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 3,45.0,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 5,25.0,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,50.0,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 6,80.0,'inprogress');


INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,40.0,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 3,35.0,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 6,85.00,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,14.00,'inprogress');


INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('Hindustan pvt.ltd','Pragati','7845632569','pragati@gmail.com','Sinhagad Road Pune','Pune','Maharashtra',39025545658);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('Britinia pvt.ltd','Akash','9945632569','Akash@gmail.com','Hadapsar  Pune','Pune','Maharashtra',39025545657);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('Surya pvt.ltd','Akshay','9645632569','Akshay@gmail.com','Rajgurunagar Pune','Pune','Maharashtra',39025545656);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('Naturals pvt.ltd','Rohit','9855632569','Rohit@gmail.com','Wanavdi Fatima nagar Pune','Pune','Maharashtra',39025545660);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('Goukul pvt.ltd','Abhay','9345632569','Abhay@gmail.com','Avasari Pune','Pune','Maharashtra',39025545655);


INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(1, 1, 70,1);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(1, 2, 700,2);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(2, 3, 78,3);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(3, 4, 78,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(3, 1, 78,5);
INSERT INTO orderdetails(order_id,product_id,quantity,supplier_id) VALUES (7,2,2000,1);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(12, 1, 70,2);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(8, 2, 700,3);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(2, 3, 88,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(2, 4, 78,3);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 4, 90,5);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(6, 2, 45,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 3, 78,1);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(5, 2, 45,2);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(6, 4, 96,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(7, 3, 25,1);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 2, 46,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 3, 35,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 12, 35,3);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 15, 35,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 8, 35,4);
INSERT INTO orderdetails(order_id, product_id, quantity,supplier_id)VALUES(4, 7, 35,4);



INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-05-03','cash on delivery',1234,1);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-06-12','online payment',987514,2);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-06-12','online payment',987514,3);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-07-10','cash on delivery',747898,4);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-08-07','online payment',953125,5);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2023-08-07','online payment',953125,6);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-09-10','cash on delivery',43210,7);


INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Amazon','6985645987','amazone@gmail.com',39025545660);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Flipcart','69825645987','flipcart@gmail.com',39025545660);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Bluedrt','6912545987','bluedart@gmail.com',39025545660);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Essar Shipping Ltd','6982345987','essar@gmail.com',39025545659);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Greatship India Ltd','6985645697','greatship@gmail.com',39025545658);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Mercator Ltd','6985647887','mercator@gmail.com',39025545657);
INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('Cochin Shipyard Ltd','9985645987','cochinShipyard@gmail.com',39025545656);



/*   
Daily Completed Tasks
1)Retrive List of Customers that made purcheses after the date 2023-03-03 ?                                -----completed
2)Available products in stock ?                                                                           ------completed
3)view Sells  by category ?                                                                                ------completed
4)Creating  View products price above than average price                                                  -------completed
5)average price from all products                                                                         -------completed
6)getting all products by category id, category_title,products_title                                      -------completed 
7)getting  products from which category is given                                                          -------completed
8)getting all products by category id, category_title,products_title from which category is given             ---completed
9)This query will give products information present in  a order by giving order_id                          -----completed
10)This query  returns totalamount of a order                                                               ------completed
11)This query give totalamount of sold products from orderdetails table of each product                    -------completed
12)This query give order history of customer                                                               -------completed
13)This procedure insert products of  order in orderdetails table 
   and then updating stock_available of product by substracting  quantity of product bought by customer       ------completed
14) Procedure                                                                                               ///////////////
15)shows all list of orders on the basis of status =cancelled                                             ----------completed
16)this query shows details of orders whose cust id is 5 and status is cancelled                           ----------completed
17) we get ORDER_id ,title of product ,quantity & new column as total amount 
  (quantity and unit ptice of that product) through order _id                                                 --------completed


Remaining -
1)Quarter wise products selling data                                                                         ////////////////

*/

select * from products;
select * from customers;
select * from orders;
select * from orderdetails;
select * from categories;

/*1)Retrive List of Customers that made purcheses after the date 2023-03-03 */
SELECT customers.cust_id,customers.first_name, customers.last_name,orders.order_date FROM orders 
INNER JOIN customers ON orders.cust_id=customers.cust_id 
WHERE order_date > '2023-03-03';

/*2)Available products in stock*/
select product_id,product_title, stock_available from products;

/*3)view Sells  by category*/
SELECT   categories.category_title, SUM(orderdetails.quantity) 
FROM orderdetails, products,categories
WHERE orderdetails.product_id = products.product_id and products.category_id=categories.category_id 
GROUP BY categories.category_title  ;

/*4) Creating  View products price above than average price*/
create or replace view vw_products_above_avgprice
as select product_title , unit_price from products
where  unit_price  > (select avg(unit_price) from products)
order by unit_price; 

select * from vw_products_above_avgprice;

/*5)average price from all products*/
select avg(unit_price) from products;


  /* Products SQL's */
select * from products where category_id =1;

/*6)getting all products by category id, category_title,products_title*/
SELECT categories.category_id,categories.category_title,products.product_title 
FROM products INNER JOIN categories ON products.category_id=categories.category_id;

/*7)getting  products from which category is given */
SELECT product_title  
FROM products 
where category_id in (select category_id from categories where category_title='colddrinks');

/*8)getting all products by category id, category_title,products_title from which category is given*/
SELECT categories.category_id,categories.category_title, products.product_title FROM categories 
INNER JOIN products ON products.category_id=categories.category_id 
WHERE categories.category_title='colddrinks';  /* biscuits,snacks,colddrinks,electronics*/


   
/*select month(order_date),sum(unit_price*quantity) from orders,products,orderdetails where products.product_id=orderdetails.product_id and order_date > now() - INTERVAL 12 month group by month(order_date);*/

/*9)This query will give products information present in  a order by giving order_id  */
SELECT orderdetails.product_id, products.product_title,products.description,products.unit_price, products.image, orderdetails.order_id,orderdetails.quantity,(products.unit_price*orderdetails.quantity) as  totalprice
FROM products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1;
    
/*10)This query  returns totalamount of a order   */
SELECT SUM(products.unit_price*orderdetails.quantity) as totalamount  from products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1 ;  

/* 11) This query give totalamount of sold products from orderdetails table of each product  */
/*  Used in dashboard */
SELECT orderdetails.product_id,products.product_title, SUM(orderdetails.quantity) * products.unit_price 
FROM orderdetails, products
WHERE orderdetails.product_id = products.product_id
GROUP BY product_id;

/*12) This query give order history of customer */
SELECT products.product_id,products.product_title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date 
FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id 
WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id 
AND customers.cust_id=1 order by orders.order_id;

/*13) This procedure insert products of  order in orderdetails table 
    and then updating stock_available of product by substracting  quantity of product bought by customer   */

DELIMITER $$
CREATE PROCEDURE UpdateInventory(IN order_id INT ,IN product_id INT, IN quantity INT,IN supplier_id INT)
BEGIN 
START TRANSACTION;
INSERT INTO orderdetails(order_id,product_id,quantity,supplier_id) VALUES(order_id,product_id,quantity,supplier_id);
UPDATE products SET stock_available=stock_available-quantity WHERE products.product_id = product_id;
COMMIT;
END $$
DELIMITER ;

CALL UpdateInventory(1,4,5000,1);
/*  This procedure return count of orders by its status (delivered,cancelled,inprogress,initiated) of a customer*/


/*14) Procedure */

DELIMITER $$
CREATE PROCEDURE get_order_by_cust(
	IN cust_no INT,
	OUT delivered INT,
	OUT cancelled INT,
	OUT inprogress INT,
	OUT initiated INT)
BEGIN
		SELECT
            count(*) INTO delivered
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'delivered';

		SELECT
            count(*) INTO cancelled
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'Cancelled';

		SELECT
            count(*) INTO inprogress
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'inprogress';

		SELECT
            count(*) INTO initiated
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'initiated';

END $$
DELIMITER ;


CALL get_order_by_cust (1,@delivered,@cancelled,@inprogress,@initiated);


SELECT @delivered , @cancelled ,@inprogress, @initiated;


/* 15)shows all list of orders on the basis of status =cancelled */
SELECT * FROM orders WHERE status = "cancelled";


/* 16)this query shows details of orders whose cust id is 5 and status is cancelled */
SELECT * FROM orders WHERE status = "cancelled" AND cust_id=5;


/*17) we get ORDER_id ,title of product ,quantity & new column as total amount (quantity and unit ptice of that product) through order _id*/

SELECT orderdetails.order_id,products.product_title, orderdetails.quantity ,(products.unit_price*orderdetails.quantity) AS total_amount 
FROM orderdetails, products 
WHERE  products.product_id =orderdetails.product_id 
AND order_id= 4;

DELIMITER $$
CREATE PROCEDURE TransferMoney(IN from_account_number BIGINT ,IN to_account_number BIGINT, IN transaction_date DATETIME,IN amount DOUBLE )
BEGIN 
START TRANSACTION;
UPDATE accounts SET balance=balance-amount WHERE account_number = from_account_number;
UPDATE accounts SET balance=balance+amount WHERE account_number = to_account_number;
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES(from_account_number,to_account_number,transaction_date,amount);
COMMIT;
END $$
DELIMITER ;

CALL TransferMoney(39025545659,39025545658,'2023-03-09 02:15:05',500);
select * from  transactions;
select * from accounts;
