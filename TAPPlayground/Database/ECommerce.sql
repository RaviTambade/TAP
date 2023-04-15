
-- Active: 1680703777390@@127.0.0.1@3306@ecommerce
--CREATE DATABASE Ecommerce;


CREATE DATABASE Ecommerce;

USE Ecommerce;


CREATE TABLE users( user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, email VARCHAR(25) UNIQUE NOT NULL, contact_number VARCHAR(20) NOT NULL ,password VARCHAR(15) NOT NULL);
CREATE TABLE roles(role_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(50));
CREATE TABLE user_roles(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,user_id INT NOT NULL,CONSTRAINT fk_user_id FOREIGN KEY(user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE ,role_id INT NOT NULL,CONSTRAINT fk_role_id FOREIGN KEY(role_id) REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE accounts(account_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,account_number BIGINT UNIQUE, ifsc_code VARCHAR(50) ,register_date DATETIME ,balance DOUBLE);
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(25), last_name VARCHAR(25),email VARCHAR(25) UNIQUE NOT NULL,contact_number VARCHAR(20) UNIQUE NOT NULL, password VARCHAR(15) NOT NULL,account_number BIGINT NOT NULL UNIQUE ,CONSTRAINT fk_account_no3 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE departments(dept_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, dept_name VARCHAR(50), location VARCHAR(50)); 
CREATE TABLE employees(employee_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,empfirst_name VARCHAR(100),emplast_name VARCHAR(50),birth_date DATETIME,hire_date DATETIME,contact_number VARCHAR(20),email VARCHAR(50),password VARCHAR(15) NOT NULL,photo varchar (50),reports_to INT NOT NULL,account_number BIGINT NOT NULL UNIQUE ,CONSTRAINT fk_account_no4 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE, dept_id INT NOT NULL ,CONSTRAINT fk_dept_id_no5 FOREIGN KEY(dept_id) REFERENCES departments(dept_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL, CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent', 'billing') NOT NULL,house_number VARCHAR(20),landmark VARCHAR(25) NOT NULL,city VARCHAR(25) NOT NULL,state VARCHAR(25) NOT NULL,country VARCHAR(25) NOT NULL,pincode VARCHAR(25) NOT NULL);
CREATE TABLE categories(category_id INT PRIMARY KEY AUTO_INCREMENT, category_title VARCHAR(20),description VARCHAR (100),image VARCHAR(50)) ;
CREATE TABLE suppliers(supplier_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR (50),supplier_name VARCHAR (20),contact_number VARCHAR (20),email VARCHAR(20),address VARCHAR(200),city VARCHAR(50),state VARCHAR(20),password VARCHAR(20) NOT NULL,account_number BIGINT NOT NULL UNIQUE,CONSTRAINT fk_account_no5 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE products (product_id INT PRIMARY KEY AUTO_INCREMENT,product_title VARCHAR(20) NOT NULL,description VARCHAR(50),stock_available INT NOT NULL,unit_price DOUBLE NOT NULL,image VARCHAR(40),category_id INT NOT NULL, CONSTRAINT fk_category_id FOREIGN KEY(category_id) REFERENCES categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE,supplier_id INT NOT NULL, CONSTRAINT fk_supplier_id FOREIGN KEY(supplier_id) REFERENCES suppliers(supplier_id) ON UPDATE CASCADE ON DELETE CASCADE);

-- Create Tables  to store shopping cart related information

CREATE TABLE carts( cart_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, cust_id INT NOT NULL,CONSTRAINT fk_cust_id_3 FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE cart_items( item_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, cart_id INT NOT NULL,CONSTRAINT fk_cart_id_3 FOREIGN KEY (cart_id) REFERENCES carts(cart_id) ON UPDATE CASCADE ON DELETE CASCADE, product_id INT NOT NULL,CONSTRAINT fk_product_id_3 FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE, quantity INT);
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME DEFAULT CURRENT_TIMESTAMP,shipped_date DATETIME DEFAULT CURRENT_TIMESTAMP,cust_id INT NOT NULL,CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,total double ,status ENUM('delivered','initiated','inprogress','cancelled','approved') NOT NULL);
CREATE TABLE orderdetails(orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL,discount float default 0);  
CREATE TABLE payments(payment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY ,payment_date DATETIME, payment_mode ENUM('cash on delivery','online payment'),transection_id INT NOT NULL,order_id INT NOT NULL, CONSTRAINT fk_order_id_1 FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE shippers(shipper_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,company_name VARCHAR(25),contact_number VARCHAR (20),email VARCHAR(50),password VARCHAR(15) NOT NULL,account_number BIGINT NOT NULL UNIQUE,CONSTRAINT account_number01 FOREIGN KEY(account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE transactions(transaction_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,from_account_number BIGINT NOT NULL ,CONSTRAINT fk_account_no FOREIGN KEY(from_account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE,to_account_number BIGINT NOT NULL ,CONSTRAINT fk_acountno2 FOREIGN KEY(to_account_number) REFERENCES accounts(account_number) ON UPDATE CASCADE ON DELETE CASCADE, transaction_date DATETIME,amount DOUBLE);


/*trigger for customer in users*/
DELIMITER //
CREATE TRIGGER insert_customer AFTER INSERT ON customers 
FOR EACH ROW 
BEGIN 
    DECLARE userId INT;
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
    SELECT user_id INTO userId FROM users where email=NEW.email;
    INSERT INTO user_roles(user_id,role_id) VALUES(userId,3);
END //
DELIMITER ;

/*trigger for employees in users*/
DELIMITER //
CREATE TRIGGER insert_employee AFTER INSERT ON employees 
FOR EACH ROW 
BEGIN 
    DECLARE userId INT;
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
    SELECT user_id INTO userId FROM users where email=NEW.email;
    INSERT INTO user_roles(user_id,role_id) VALUES(userId,2);
END //
DELIMITER ;


DELIMITER //
CREATE TRIGGER insert_supplier AFTER INSERT ON suppliers
FOR EACH ROW 
BEGIN 
    DECLARE userId INT;
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
    SELECT user_id INTO userId FROM users where email=NEW.email;
    INSERT INTO user_roles(user_id,role_id) VALUES(userId,5);
END //
DELIMITER ;

DELIMITER //
CREATE TRIGGER insert_shipper AFTER INSERT ON shippers
FOR EACH ROW 
BEGIN 
    DECLARE userId INT;
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
    SELECT user_id INTO userId FROM users where email=NEW.email;
    INSERT INTO user_roles(user_id,role_id) VALUES(userId,4);
END //
DELIMITER ;



INSERT INTO users(email,contact_number,password) VALUES ('pragatibangar12@gmail.com','7498035690','pragati@123');

/*Sample Data Entry for database*/

INSERT INTO roles(role) VALUES("Admin");
INSERT INTO roles(role) VALUES("Employee");
INSERT INTO roles(role) VALUES("Customer");
INSERT INTO roles(role) VALUES("Shipper");
INSERT INTO roles(role) VALUES("Supplier");

INSERT INTO user_roles(user_id,role_id) VALUES (1,1);

INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546601,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546602,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546603,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546604,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546605,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546606,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546607,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546608,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546609,'MAHB0000286','2023-03-01 12:40:40',22555);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546610,'MAHB0000286','2023-03-01 12:40:35',22500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546611,'UNB0000286','2023-04-15 02:45:35',2250025);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546612,'BARBO0000286','2023-03-04 02-40-35',225700);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546613,'MAHB000299','2022-03-16  03-40-35',24540);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546614,'MAHB0000886','2022-05-01 04-50-35',454500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546615,'AXIS0000296','2021-07-01 07-40-35',2352500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546616,'UBIN0000286','2021-08-01 07-10-35',23500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546617,'AXIS0000285','2021-05-02 07-40-35',232500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546618,'MAHB0000284','2021-08-03 07-40-35',235250);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546619,'UBIN0000286','2021-08-04 07-40-35',23520);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546620,'HDFC0000286','2021-02-05 07-40-35',52500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546621,'SBI0000286','2021-08-07 07-40-35',233500);
INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES( 39025546623,'AXIS0000236','2021-08-08 07-40-35',23500);

INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES(39025546601,39025546602,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025546602,39025546603,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025546604,39025546605,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES(39025546605,39025546606,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025546606,39025546607,'2023-03-01 12:40:35',22500);
INSERT INTO transactions(from_account_number, to_account_number,transaction_date,amount) VALUES( 39025546607,39025546608,'2023-03-01 12:40:35',22500);

INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Sahil','Mankar','sahil.m@gmail.com','9960916323','sahil@123',39025546601);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Abhay','Navle','abhay.navale@gmail.com','9075966080','sahil@123',39025546602);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Sachin','Patil','sachin.patil@gmail.com','9881723458','sahil@123',39025546603);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Minal','Sagade','minal.sagade@outlook.com','9887454372','sahil@123',39025546604);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Jai','Kinikar','jai.kinikar@gmail.com','98543234','sahil@123',39025546605);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Rakhi','Sharma','rakhi.sharma@gmail.com','9845834534','sahil@123',39025546606);
INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number) VALUES ('Shivam','Pethe','shivam.pethe@gmai.com','9881734798','sahil@123',39025546607);

INSERT INTO departments(dept_name,location) VALUES('HR','Satara');
INSERT INTO departments(dept_name,location) VALUES('Finance','Pune');
INSERT INTO departments(dept_name,location) VALUES('Account','Mumbai');
INSERT INTO departments(dept_name,location) VALUES('Sales','Kolhapur');

INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Akash','Ajab','1999-09-15','2022-09-07','8756320150','Akjab@gmail.com','AK123654' ,'./images/crackjack.jpg', 2,39025546608,2);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Shubham','Teli','1999-02-10','2020-07-05','9876320158','Steli@gmail.com','ST5269' ,'./images/ST.jpg', 1,39025546609,1);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Sahil','Mankar','1997-05-19','2021-07-07','8756789158','Sahil22@gmail.com','SM569654' ,'./images/SM.jpg', 1,39025546610,3);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Shubham','Navale','1995-07-25','2020-05-04','9996320158','SNavale@gmail.com','SN56987' ,'./images/SN.jpg', 3,39025546611,4);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Rohit','Gore','1996-05-12','2022-09-07','7776320158','RGore@gmail.com','RG123654' ,'./images/RG.jpg', 4,39025546612,2);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Pragati','Bangar','1998-05-10','2022-11-09','9666320158','PBangar@gmail.com','PB123654' ,'./images/PB.jpg', 5,39025546613,3);
INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES('Vishwambhar','Kapare','1998-05-19','2023-03-15','70385488505','Rushi@gmail.com','Rc5269','./images/Rc.jpg',3,39025546605,2);

/*possible vales  for addressmode:1:only residential ,2:only delivery address,3:residentail and delivery*/
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'permanent','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'billing','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','121321');

INSERT INTO categories(category_title,description,image)values('biscuits','Daily Snack with Tea','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('colddrinks','Summer Drink','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('snacks','For daily Breakfast','./images/crackjack.jpg');
INSERT INTO categories(category_title,description,image)values('electronics','Domastic Equipments','./images/crackjack.jpg');

INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,password,account_number)VALUES('Hindustan pvt.ltd','Pragati','7845632569','pragati@gmail.com','Sinhagad Road Pune','Pune','Maharashtra','pragati@123',39025546614);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,password,account_number)VALUES('Britinia pvt.ltd','Akash','9945632569','Akash@gmail.com','Hadapsar  Pune','Pune','Maharashtra','akash@123',39025546615);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,password,account_number)VALUES('Surya pvt.ltd','Akshay','9645632569','Akshay@gmail.com','Rajgurunagar Pune','Pune','Maharashtra','akshay@123',39025546616);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,password,account_number)VALUES('Naturals pvt.ltd','Rohit','9855632569','Rohit@gmail.com','Wanavdi Fatima nagar Pune','Pune','Maharashtra','rohit@123',39025546617);
INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,password,account_number)VALUES('Goukul pvt.ltd','Abhay','9345632569','Abhay@gmail.com','Avasari Pune','Pune','Maharashtra','abhay@123',39025546618); 


INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id) VALUES('ParleG','tasty biscuits',20000,10,'/images/Parleg.jpg',1,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('GoodDay','tasty cookies',50000,15,'/images/goodday.jpg',1,2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('MariGold','tasty biscuits',40000,16,'/images/marigold.jpg',1,3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('20-20','tasty biscuits', 70000, 10,'/images/2020.jpg',1,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Crack-Jack','tasty biscuits',30000,10,'/images/crackjack.jpg',1,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Pepsi','Drinks Any time',50000,40,'/images/Pepsi.jpg',2,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Fizz','Making from apple',2000,25,'/images/Fizz.jpg',2,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Slice','Making from Mangoes',10000,40,'/images/Slice.jpg',2,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('coco-cola','Drinking any time',6000,40,'/images/coco_cola.jpg',2,3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Maggi','Making in 2 minutes',500,12,'./images/Maggi.jpg',3,3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('FrenchFries','Making for instatnt eat',1000,40,'./images/Francci.jpg',3,1);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Idli','Light snack',20000,20,'./images/Idli.jpg',3,3);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Tv','Entertenment Gadget',50,12000,'./images/samsung.jpg',4,2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Mobiles','Communication Purpose',100,10,'./images/Oppo.jpg',4,2);
INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id,supplier_id)VALUES('Firdge','Kitchen Use',200,150,'./images/Samsung.jpg',4,4);


INSERT INTO carts(cust_id) VALUES (1);
INSERT INTO carts(cust_id) VALUES (2);
INSERT INTO carts(cust_id) VALUES (3);
INSERT INTO carts(cust_id) VALUES (4);
INSERT INTO carts(cust_id) VALUES (5);

INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (1,2,5);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (1,5,50);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (1,3,100);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (2,7,15);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (2,8,25);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (2,3,5);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (3,2,5);
INSERT INTO cart_items(cart_id,product_id,quantity) VALUES (4,2,5);

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-17  04:20:10', 1,85.00,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 2, 82.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 6,20.00,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,40.00,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 4,50.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 4,30.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,45.00,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-04-12  12:35:25', 1,75.00,'cancelled');
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

INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 1, 70);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 2, 700);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 3, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 4, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 1, 78);
INSERT INTO orderdetails(order_id,product_id,quantity) VALUES (7,2,2000);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(12, 1, 70);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(8, 2, 700);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 3, 88);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 4, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 4, 90);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(10, 2, 45);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 3, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(5, 2, 45);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(20, 4, 96);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(7, 3, 25);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 2, 46);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 3, 35);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 12, 35);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 15, 35);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 8, 35);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 7, 35);

INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-05-03','cash on delivery',1234,1);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-06-12','online payment',987514,2);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-06-12','online payment',987514,3);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-07-10','cash on delivery',747898,4);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-08-07','online payment',953125,5);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2023-08-07','online payment',953125,6);
INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES('2022-09-10','cash on delivery',43210,7);

INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES('Flipcart','69825645987','flipcart@gmail.com','flipcart@123',39025546619);
INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES('Bluedrt','6912545987','bluedart@gmail.com','bluedart@123',39025546620);
INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES('Essar Shipping Ltd','6982345987','essar@gmail.com','essar@123',39025546621);
INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES('Greatship India Ltd','6985645697','greatship@gmail.com','greatship@123',39025546623);


/*13) This procedure insert products of  order in orderdetails table 
    and then updating stock_available of product by substracting  quantity of product bought by customer   */

DELIMITER $$
CREATE PROCEDURE UpdateInventory(IN order_id INT ,IN product_id INT, IN quantity INT)
BEGIN 
START TRANSACTION;
INSERT INTO orderdetails(order_id,product_id,quantity) VALUES(order_id,product_id,quantity);
UPDATE products SET stock_available=stock_available-quantity WHERE products.product_id = product_id;
COMMIT;
END $$
DELIMITER ;

CALL UpdateInventory(1,4,5000);
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

  -- we give cart items with the help of cart Id and insert order in orders table as well as orders details table and 
--   then we delete this record from cart items table
DELIMITER $$
CREATE PROCEDURE CreateOrder(IN cartId BIGINT )
BEGIN
DECLARE noMoreRow INT default 0; 
DECLARE orderId INT;
DECLARE productId INT;
DECLARE quantity INT;
DECLARE custId INT;
DECLARE cart_cursor CURSOR  FOR SELECT cart_items.product_id,cart_items.quantity FROM cart_items WHERE cart_id=cartId; 
DECLARE CONTINUE HANDLER FOR NOT FOUND SET noMoreRow = 1;
SELECT cust_id INTO custId FROM carts WHERE cart_id=cartId;
INSERT INTO orders (order_date, cust_id,total,status) VALUES (now(),custId,0,'initiated');
SET orderId=last_insert_id();
OPEN cart_cursor ;
cart_items:LOOP
    FETCH cart_cursor INTO productId,quantity;
    IF noMoreRow=1 THEN 
		LEAVE cart_items;
    END IF;
     INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(orderId,productId,quantity); 
END LOOP cart_items;
DELETE FROM cart_items WHERE cart_id=cartId;
CLOSE cart_cursor;
END $$
DELIMITER ;
-- CALL CreateOrder();


select * from users;
select * from accounts;
select * from cart_items where cart_id=1;


-- Logic for hiking price of each product in products table
DELIMITER $$
CREATE PROCEDURE hike_price(IN percentage DOUBLE)
BEGIN
DECLARE nomorerows int default 0 ;
DECLARE productId INT;
DECLARE unitPrice double;
DECLARE hike_percent_cursor CURSOR  FOR SELECT unit_price,product_id FROM products ; 
DECLARE CONTINUE HANDLER FOR NOT FOUND SET nomorerows= 1;
OPEN hike_percent_cursor ;
hike_price:LOOP
    FETCH hike_percent_cursor INTO unitPrice,productId;
    IF nomorerows THEN 
		LEAVE hike_price;
    END IF;
    SET unitPrice=unitPrice+(unitPrice*percentage/100);
    UPDATE products SET unit_price=unitPrice WHERE product_id=productId;
END LOOP hike_price;
CLOSE hike_percent_cursor;
END $$
DELIMITER ;
-- CALL hike_price();
select * from products;

---------------------------------------------------------------------------------


/*19)This Store procedure show Transaction History*/
DELIMITER $$
CREATE PROCEDURE TransferMoney(IN from_account_number BIGINT ,IN to_account_number BIGINT, IN transaction_date DATETIME,IN amount DOUBLE )
BEGIN 
DECLARE Debit double;
START TRANSACTION;
UPDATE accounts SET balance=balance-amount WHERE account_number = from_account_number;
UPDATE accounts SET balance=balance+amount WHERE account_number = to_account_number;
INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount) VALUES(from_account_number,to_account_number,transaction_date,amount);
COMMIT;
END $$
DELIMITER ;

DESC employees;
select * from users;
select * from roles;
select * from user_roles;
select * from departments;
select * from employees;
select * from customers;
select * from orders;
select * from orderdetails;
select * from categories;
select * from accounts;
SELECT * FROM transactions;



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


/* 15)shows all list of orders on the basis of status =cancelled */
SELECT * FROM orders WHERE status = "cancelled";


/* 16)this query shows details of orders whose cust id is 5 and status is cancelled */
SELECT * FROM orders WHERE status = "cancelled" AND cust_id=5;


/*17) we get ORDER_id ,title of product ,quantity & new column as total amount (quantity and unit ptice of that product) through order _id*/

SELECT orderdetails.order_id,products.product_title, orderdetails.quantity ,(products.unit_price*orderdetails.quantity) AS total_amount 
FROM orderdetails, products 
WHERE  products.product_id =orderdetails.product_id 
AND order_id= 4;

/*19) This Query show how many times Money credited or debited in customers account */
select transactions.transaction_id,transactions.amount,transactions.transaction_date,
CASE WHEN transactions.from_account_number=customers.account_number then 'debit'
	 WHEN transactions.to_account_number=customers.account_number then 'credit'
	 END AS MODETYPE FROM transactions,customers
WHERE transactions.from_account_number=(select account_number from customers where cust_id=2) or transactions.to_account_number=(select account_number from customers where cust_id=2);

/*20) This Query show how many times Money credited or debited in customers account */
select customers.cust_id, customers.first_name, customers.last_name, transactions.amount,transactions.transaction_date,
CASE WHEN transactions.from_account_number=customers.account_number then 'debit'
	 WHEN transactions.to_account_number=customers.account_number then 'credit'
	 END AS MODETYPE FROM transactions,customers
WHERE ( transactions.from_account_number=(select account_number from customers where cust_id=2) and customers.cust_id=2)
  or (transactions.to_account_number=(select account_number from customers where cust_id=2)  and customers.cust_id=2) ;

/*21) This Query show how many times Money credited or debited in account where customer id is 2*/
select transactions.transaction_date,transactions.amount,transactions.from_account_number,
CASE WHEN transactions.from_account_number=(select account_number from customers where cust_id=2) then 'debit'
	 WHEN transactions.to_account_number=(select account_number from customers where cust_id=2) then 'credit'
	 END AS MODETYPE FROM transactions,customers
WHERE transactions.from_account_number=(select account_number from customers where cust_id=2) or transactions.to_account_number=(select account_number from customers where cust_id=2);


CALL TransferMoney(39025546601,39025546602,'2023-03-09 02:15:05',500);

select customers.first_name,customers.last_name,customers.email,customers.contact_number,accounts.account_number,accounts.ifsc_code,accounts.balance FROM customers  INNER JOIN  accounts ON accounts.account_number=customers.account_number ;-- WHERE customers.cust_id=1; 

/* insert employee query*/

select customers.first_name,customers.last_name,customers.email,customers.contact_number,accounts.account_number,accounts.ifsc_code,accounts.balance FROM customers  INNER JOIN  accounts ON accounts.account_number=customers.account_number;-- WHERE customers.cust_id=1; 

SELECT suppliers.supplier_id,products.product_id,products.product_title,SUM(orderdetails.quantity) FROM (products INNER JOIN orderdetails ON products.product_id=orderdetails.product_id)INNER JOIN suppliers ON products.supplier_id=suppliers.supplier_id   WHERE suppliers.supplier_name="Akshay" GROUP BY products.product_id;
SELECT * FROM cart_items;
SELECT * FROM  orderDetails;