
CREATE DATABASE Ecommerce;
use Ecommerce;

--  USE Ecommerce ;

CREATE TABLE users( user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, email VARCHAR(25) UNIQUE NOT NULL, contact_number VARCHAR(20) NOT NULL UNIQUE,password VARCHAR(15) NOT NULL);
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(25), last_name VARCHAR(25),email VARCHAR(25) UNIQUE NOT NULL,contact_number VARCHAR(20) UNIQUE NOT NULL, password VARCHAR(15) NOT NULL);
CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL, CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent', 'billing') NOT NULL,house_number VARCHAR(20),landmark VARCHAR(25) NOT NULL,city VARCHAR(25) NOT NULL,state VARCHAR(25) NOT NULL,country VARCHAR(25) NOT NULL,pincode VARCHAR(25) NOT NULL);
CREATE TABLE products (product_id INT PRIMARY KEY AUTO_INCREMENT,title VARCHAR(20) NOT NULL,description VARCHAR(50),stock_available INT NOT NULL,unit_price DOUBLE NOT NULL,image VARCHAR(40));
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME DEFAULT CURRENT_TIMESTAMP,delivery_date DATETIME DEFAULT CURRENT_TIMESTAMP,cust_id INT NOT NULL,CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,total decimal(4,2) ,status ENUM('delivered','initiated','inprogress','cancelled','approved') NOT NULL);
CREATE TABLE orderdetails(orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL);

INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Sahil','Mankar','sahil.m@gmail.com','9960916323','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Abhay','Navle','abhay.navale@gmail.com','9075966080','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Sachin','Patil','sachin.patil@gmail.com','9881723458','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Minal','Sagade','minal.sagade@outlook.com','9887454372','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Jai','Kinikar','jai.kinikar@gmail.com','98543234','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Rakhi','Sharma','rakhi.sharma@gmail.com','9845834534','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Shivam','Pethe','shivam.pethe@gmai.com','9881734798','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('Manisha','Pant','manisha.pant@gmail.com','9884578673','sahil@123');


INSERT INTO products(title,description,stock_available,unit_price,image) VALUES('ParleG','tasty biscuits',20000,10,'./images/Parleg.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('GoodDay','tasty cookies',50000,15,'./images/goodday.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('MariGold','tasty biscuits',40000,16,'./images/marigold.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('20-20','tasty biscuits', 70000, 10,'./images/2020.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg');

/*possible vales  for addressmode:1:only residential ,2:only delivery address,3:residentail and delivery*/
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'permanent','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'billing','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','121321');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,500,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 8,200,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 6,200,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,400,'inprogress');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 4,500,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 8,300,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,450,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 2,450,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,500,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 2,350,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,500,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,250,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 3,450,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 5,250,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,500,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 6,800,'inprogress');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,400,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 3,350,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 8,500,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 1,400,'inprogress');



INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 1, 70);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 2, 700);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 3, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 4, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 1, 78);
insert into orderdetails(order_id,product_id,quantity) VALUES (7,2,2000);

CREATE TRIGGER insert_user AFTER INSERT ON customers 
FOR EACH ROW 
BEGIN 
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password)
END;

/*select month(order_date),sum(unit_price*quantity) from orders,products,orderdetails where products.product_id=orderdetails.product_id and order_date > now() - INTERVAL 12 month group by month(order_date);*/

SELECT orderdetails.product_id, products.title,products.description,products.unit_price, products.image, orderdetails.order_id,orderdetails.quantity,(products.unit_price*orderdetails.quantity) as  totalprice
FROM products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1;
    
SELECT SUM(products.unit_price*orderdetails.quantity) as totalamount  from products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1 ;  

SELECT orderdetails.product_id,products.title, SUM(orderdetails.quantity) * products.unit_price 
FROM orderdetails, products
WHERE orderdetails.product_id = products.product_id
GROUP BY product_id;

SELECT products.product_id,products.title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date 
FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id 
WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id 
AND customers.cust_id=1 order by orders.order_id;



--  USE Ecommerce ;

CREATE TABLE users( user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, email VARCHAR(25) UNIQUE NOT NULL, contact_number VARCHAR(20) NOT NULL UNIQUE,password VARCHAR(15) NOT NULL);
CREATE TABLE customers(cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(25), last_name VARCHAR(25),email VARCHAR(25) UNIQUE NOT NULL,contact_number VARCHAR(20) UNIQUE NOT NULL, password VARCHAR(15) NOT NULL);
CREATE TABLE addresses(address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,cust_id INT NOT NULL, CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,address_mode ENUM('permanent', 'billing') NOT NULL,house_number VARCHAR(20),landmark VARCHAR(25) NOT NULL,city VARCHAR(25) NOT NULL,state VARCHAR(25) NOT NULL,country VARCHAR(25) NOT NULL,pincode VARCHAR(25) NOT NULL);
CREATE TABLE products (product_id INT PRIMARY KEY AUTO_INCREMENT,title VARCHAR(20) NOT NULL,description VARCHAR(50),stock_available INT NOT NULL,unit_price DOUBLE NOT NULL,image VARCHAR(40));
CREATE TABLE orders(order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_date DATETIME DEFAULT CURRENT_TIMESTAMP,total double,delivery_date DATETIME DEFAULT CURRENT_TIMESTAMP,cust_id INT NOT NULL,CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,status ENUM('Delivered','Cancelled','Inprogress','Initiated') NOT NULL);
CREATE TABLE orderdetails(orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,order_id INT NOT NULL,CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE,product_id INT NOT NULL,CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE,quantity INT NOT NULL);

INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('sahil','mankar','sahil@123','9960916323','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('abhay','navle','abhay','9075966080','sahil@123');

INSERT INTO products(title,description,stock_available,unit_price,image) VALUES('ParleG','tasty biscuits',20000,10,'./images/Parleg.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('GoodDay','tasty cookies',50000,15,'./images/goodday.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('MariGold','tasty biscuits',40000,16,'./images/marigold.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('20-20','tasty biscuits', 70000, 10,'./images/2020.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg');

/*possible vales  for addressmode:1:only residential ,2:only delivery address,3:residentail and delivery*/
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'permanent','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'billing','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','121321');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2020-08-25  06:35:25', 1 ,45.00,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2021-06-04  08:35:25', 1 ,30.00,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2010-01-16  09:35:25', 2 ,20.00,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2021-05-15  11:35:25', 2 ,50.00,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25',1, 50.00,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25',4, 80.25,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25',5,30.25,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,40.20,'inprogress');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 4,50.45,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 8,30.47,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,45.45,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 2,45.24,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,54.25,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 8,35.35,'inprogress');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,50.45,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 7,47.58,'cancelled');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 3,40.65,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 5,45.25,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 4,78.52,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 6,88.25,'inprogress');

INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-08-25  06:35:25', 1,25.36,'initiated');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-06-04  08:35:25', 3,35.75,'delivered');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-01-16  09:35:25', 8,45.75,'cancelled');
INSERT INTO orders(order_date, cust_id,total,status)VALUES ('2023-05-15  11:35:25', 4,47.25,'inprogress');

SELECT * FROM customers;

SELECT * FROM orders;
DESCRIBE orders;





INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 1, 70);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 2, 700);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 3, 88);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(15, 4, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 4, 90);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(6, 2, 45);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(4, 3, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(5, 2, 45);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(6, 4, 96);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(7, 3, 25);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(25, 2, 46);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(14, 3, 35);


CREATE TRIGGER insert_user AFTER INSERT ON customers 
FOR EACH ROW 
BEGIN 
	INSERT INTO users(email,contact_number,password)VALUES (NEW.email,NEW.contact_number,NEW.password);
END;

/*select month(order_date),sum(unit_price*quantity) from orders,products,orderdetails where products.product_id=orderdetails.product_id and order_date > now() - INTERVAL 12 month group by month(order_date);*/

SELECT orderdetails.product_id, products.title,products.description,products.unit_price, products.image, orderdetails.order_id,orderdetails.quantity,(products.unit_price*orderdetails.quantity) as  totalprice
FROM products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1;

SELECT products.title,products.description,products.unit_price,products.image,orderdetails.order_id,orderdetails.quantity
from products, orders
INNER JOIN customers ON customers.cust_id=orders.cust_id
INNER JoIN orderdetails ON  orderdetails.order_id=orders.order_id
where customers.cust_id=1 ;
    
SELECT SUM (products.unit_price*orderdetails.quantity) as totalamount  from products
INNER JOIN orderdetails ON products.product_id =  orderdetails.product_id 
WHERE orderdetails.order_id=1 ;  

SELECT orderdetails.product_id,products.title, SUM(orderdetails.quantity) * products.unit_price 
FROM orderdetails, products
WHERE orderdetails.product_id = products.product_id
GROUP BY product_id;

SELECT products.product_id,products.title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date 
FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id 
WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id 
AND customers.cust_id=1 order by orders.order_id;


CREATE PROCEDURE SimpleTransaction()
BEGIN 
BEGIN TRANSACTION  
-- SQL Statements  
 INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg');
 INSERT INTO orders(order_date, cust_id)VALUES ('2021-05-15  11:35:25', 2);
 -- Commit changes   
COMMIT TRANSACTION 
END
CALL SimpleTransaction()





-- Start a new transaction    
BEGIN TRANSACTION  
-- SQL Statements  
 INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg');
 INSERT INTO orders(order_date, cust_id,to)VALUES ('2021-05-15  11:35:25', 2);
 -- Commit changes   
 

CREATE PROCEDURE  transaction(IN order_id INT ,IN product_id INT, IN quantity INT)
BEGIN
INSERT INTO orderdetails(order_id,product_id,quantity)VALUES(order_id,product_id,quantity);
UPDATE products SET stock_available=stock_available-quantity;
END;


SELECT * FROM products;









 

















use Ecommerce;
CREATE PROCEDURE UpdateInventory(IN order_id INT ,IN product_id INT, IN quantity INT)
BEGIN 
START TRANSACTION;
INSERT INTO orderdetails(order_id,product_id,quantity) VALUES(order_id,product_id,quantity);
UPDATE products SET stock_available=stock_available-quantity WHERE products.product_id = product_id;
COMMIT;
END;

CALL UpdateInventory(1,3,5000);

SELECT * FROM products;



SELECT * FROM products;

 


USE  ECOMMERCE;

CREATE PROCEDURE get_order_by_cust(
	IN cust_no INT,
	OUT delivered INT,
	OUT cancelled INT,
	OUT inprogress INT,
	OUT initiated INT)
BEGIN
		-- shipped
		SELECT
            count(*) INTO delivered
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'delivered';

		-- cancelled
		SELECT
            count(*) INTO cancelled
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'Cancelled';

		-- resolved
		SELECT
            count(*) INTO inprogress
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'inprogress';

		-- disputed
		SELECT
            count(*) INTO initiated
        FROM
            orders
        WHERE
            cust_id = cust_no
                AND status = 'initiated';

END;
DROP PROCEDURE get_order_by_cust;
CALL get_order_by_cust (1,@delivered,@cancelled,@inprogress,@initiated);


SELECT @delivered , @cancelled ,@inprogress, @initiated;


/* shows all list of orders on the basis of status =cancelled */
SELECT * FROM orders WHERE status = "cancelled";


/* this query shows details of orders whose cust id is 5 and status is cancelled */
SELECT * FROM orders WHERE status = "cancelled" AND cust_id=5;


/* this query shows ordersdetails whose orderid=13;*/

SELECT * FROM orderdetails WHERE order_id =13 ;


SELECT * FROM orders;