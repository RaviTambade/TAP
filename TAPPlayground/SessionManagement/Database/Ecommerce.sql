CREATE DATABASE Ecommerce;

USE Ecommerce ;

CREATE TABLE
    users(
        user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        contact_number BIGINT NOT NULL UNIQUE,
        otp INT NOT NULL
    );

CREATE TABLE
    customers(
        cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        first_name VARCHAR(255),
        last_name VARCHAR(255),
        email VARCHAR(255) UNIQUE,
        contact VARCHAR(20) UNIQUE,
        user_id INT NOT NULL,
        CONSTRAINT fk_user_id_2 FOREIGN KEY (user_id) REFERENCES users(user_id) ON UPDATE CASCADE
    );

/*
 possible vales  for addressmode:
 1:only residential
 2:only delivery address
 3:residentail and delivery
 */

CREATE TABLE
    addresses(
        address_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        cust_id INT NOT NULL,
        address_mode INT NOT NULL,
        CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE,
        house_No VARCHAR(255),
        landmark VARCHAR(55),
        city VARCHAR(255),
        state VARCHAR(255),
        country VARCHAR(255),
        pincode VARCHAR(255)
    );

CREATE TABLE
    products (
        product_id INT PRIMARY KEY AUTO_INCREMENT,
        title VARCHAR(20) NOT NULL,
        description VARCHAR(50),
        stock_available INT NOT NULL,
        unit_price DOUBLE NOT NULL,
        image VARCHAR(200) NOT NULL
    );

CREATE TABLE
    orders(
        order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        order_date DATETIME,
        cust_id INT NOT NULL,
        CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE,
        status VARCHAR(200)
    );

CREATE TABLE
    orderdetails(
        orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        order_id INT NOT NULL,
        CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE,
        product_id INT NOT NULL,
        CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE,
        quantity INT NOT NULL
    );

<<<<<<< HEAD
INSERT INTO
    users (contact_number, otp)
VALUES
(7498035692, 233145), (9807542378, 456778), (9045676545, 123456), (9850250927, 654332);

INSERT INTO
    customers(
        first_name,
        last_name,
        email,
        contact,
        user_id
    )
VALUES
(
        'Rohit',
        'Gore',
        'rohitG123@gmail.com',
        '759862356',
        1
    ), (
        'Akshay',
        'Tanpure',
        'akashay123@gmail.com',
        '7596782356',
        2
    ), (
        'Akash',
        'Ajab',
        'akash123@gmail.com',
        '7598645672',
        4
    ), (
        'Abhay',
        'Navale',
        'abhayG123@gmail.com',
        '9856235690',
        3
    );

INSERT INTO
    addresses(
        cust_id,
        address_mode,
        house_no,
        landmark,
        city,
        state,
        country,
        pincode
    )
VALUES
(
        1,
        1,
        'flat no.23,Niranjan heights',
        'Behind chandrama garden',
        'Satara',
        'Maharashtra',
        'India',
        '410505'
    ), (
        2,
        2,
        'flat no.45,Sai heights',
        'Behind season mall',
        'Nashik',
        'Maharashtra',
        'India',
        '410503'
    ), (
        3,
        1,
        'flat no.56,Neha heights',
        'Behind avenue mall',
        'Pune',
        'Maharashtra',
        'India',
        '410504'
    ), (
        4,
        3,
        'flat no.32,Shiv heights',
        'Behind rubi hospital',
        'Manchar',
        'Maharashtra',
        'India',
        '410507'
    );

INSERT INTO
    products(
        title,
        description,
        stock_available,
        unit_price,
        image
    )
VALUES (
        'Maggi',
        'Ready To Cook',
        1000,
        12,
        './images/maggi.jpg'
    ), (
        'GoodDay',
        'Snacks',
        1500,
        20,
        './images/goodday.jfif'
    ), (
        'ParleG',
        'Delicious',
        2000,
        10,
        './images/parleg.jfif'
    ), (
        'Sting',
        'Energy Drink',
        2500,
        20,
        './images/sting.jpg'
    );

INSERT INTO
    orders(order_date, cust_id, status)
VALUES
(
        '2022-07-28  12:35:25',
        1,
        'Approved'
    ), (
        '2022-07-23  12:35:25',
        3,
        'Inprogress'
    ), (
        '2022-07-18  12:35:25',
        4,
        'Approved'
    ), (
        '2022-07-05  12:35:25',
        3,
        'Approved'
    ), (
        '2022-07-10  12:35:25',
        2,
        'Approved'
    ), (
        '2022-07-15  12:35:25',
        4,
        'Approved'
    ), (
        '2022-07-20  12:35:25',
        2,
        'Approved'
    );

INSERT INTO
    orderdetails(order_id, product_id, quantity)
VALUES
(1, 2, 78), (2, 3, 53), (3, 1, 30), (4, 4, 45);
=======
INSERT INTO users (contact_number , otp) 
            VALUES(7498035692,233145),
                  (9807542378,456778),
                  (9045676545,123456),
                  (9850250927,654332);
INSERT INTO users (contact_number , otp) VALUES(1234567811,123456);
INSERT INTO users (contact_number , otp) VALUES(8765412300,654321);
INSERT INTO users (contact_number , otp) VALUES(7498035678,987456);
INSERT INTO users (contact_number , otp) VALUES(9874561230,025869);
INSERT INTO users (contact_number , otp) VALUES(8745612309,987654);
INSERT INTO users (contact_number , otp) VALUES(2345458796,123456);
INSERT INTO users (contact_number , otp) VALUES(9123456589,981236);
INSERT INTO users (contact_number , otp) VALUES(7495035692,321654);
                  
INSERT INTO customers(first_name,last_name,email,contact,user_id)
			   VALUES('Rohit', 'Gore','rohitG123@gmail.com','759862356',1),
                     ('Akshay', 'Tanpure','akashay123@gmail.com','7596782356',2),
                     ('Akash', 'Ajab','akash123@gmail.com','7598645672',4),
                     ('Abhay', 'Navale','abhayG123@gmail.com','9856235690',3);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Nikhil','Jambhulkar','nikhilj@1234','1234567811',5);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Gaurav','Desai','gauravg@1234','8765412300',6);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Aman','Lavande','amanl@1234','9874561230',4);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Shubham','Patil','shubhamp@1234','8745612309',3);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Shubham','Amate','shubhamt@1234','2345654123',9);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Adity','Gangadare','@1234','0123456789',10);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Mangesh','Savant','mangeshs@1234','8945612307',11);
INSERT INTO customers(first_name, last_name, email, contact, user_id) VALUES('Sanket','Bobade','sanketb@1234','89876543210',12);

INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) 
			   VALUES(1,1,'flat no.23,Niranjan heights','Behind chandrama garden','Satara','Maharashtra','India','410505'),
					 (2,2,'flat no.45,Sai heights','Behind season mall','Nashik','Maharashtra','India','410503'),
					 (3,1,'flat no.56,Neha heights','Behind avenue mall','Pune','Maharashtra','India','410504'),
					 (4,3,'flat no.32,Shiv heights','Behind rubi hospital','Manchar','Maharashtra','India','410507');	
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(5,1,'House no.25, Ajad Nagar','Behind Ruby Hall and Clinic','Pune','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(6,2,'flat no.23, Ashirvad Park ','Near Old MIDC','Satara','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(7,3,'Survey number no.45/5, Kp','Near Poonaval Circule','Pune','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(8,1,'House no.13, Heaven Park','Behind Mountain High Hotel','Nagpure','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(9,3,'Flat no.02, OX Ford Village','Kedari Nagar','Nashik','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(10,1,'House no.101 , CH.Shivaji Maharaj Nagar','Behind Empress garden','Nanded','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(11,2,'Survey no. 201/08, Krushnkunj','Near Alankar Hall','Solapur','Maharashtra','India','410505');
INSERT INTO addresses(cust_id,address_mode,house_no,landmark,city,state,country,pincode) VALUES(12,1,'House No.01, Silver Lake','Behind Gardan Vadapav','Nashik','Maharashtra','India','410505');

INSERT INTO products(title, description, stock_available,unit_price,image)
             VALUES ('Maggi', 'Ready To Cook',1000,12,'./images/maggi.jpg'),
					('GoodDay','Snacks',1500,20,'./images/goodday.jfif'),
					('ParleG','Delicious',2000,10,'./images/parleg.jfif'),
					('Sting','Energy Drink',2500,20,'./images/sting.jpg');

INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Potato chips','Testy', 2000,15,'./images/potato chips'),
                   ('chocolate','Testy', 200,12,'./images/chocolate'),
                   ('pen','Testy', 500,5,'./images/pen'),
                   ('notebook','Testy', 400,50,'./images/notebook'),
                   ('Laptop','Testy', 50,50000,'./images/Laptop'),
                   ('Mobile','Testy', 200,15000,'./images/Mobile'),
                   ('Books','Testy', 1000,100,'./images/Books'),
                   ('Headphones','Testy', 150,1600,'./images/Headphones'),
                   ('Watch','Testy', 400,2000,'./images/Watch');
		
   
INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Water Bottle','clean ',1500,20,'./images/Water Bottle');
            
 INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Water Filter','5* rated  ',200,8000,'./images/Water Filter');
            
INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Freze','5 * rated ',500,12000,'./images/Freze');
            
INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Grass Cutter',' Saftey  ',150,25000,'./images/Grass Cutter');
  
INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Fan',' Saftey  ',1500,2500,'./images/Fan');

INSERT INTO products(title, description, stock_available,unit_price,image)
            VALUES ('Television',' Saftey  ',700,25000,'./images/Television');
            

INSERT INTO orders(order_date,cust_id,status)
            VALUES('2022-07-28  12:35:25',1,'Approved'), 
				  ('2022-07-23  12:35:25',3,'Inprogress'),
				  ('2022-07-18  12:35:25',4,'Approved'),
				  ('2022-07-05  12:35:25',3,'Approved'),
				  ('2022-07-10  12:35:25',2,'Approved'),
				  ('2022-07-15  12:35:25',4,'Approved'),
				  ('2022-07-20  12:35:25',2,'Approved');
INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-05-13  10:35:19',2,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2023-01-15  01:12:02',3,'Inprocesss');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2022-08-14  11:35:45',1,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2022-08-13  12:45:25',12,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2022-08-12  02:45:45',6,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2022-06-09  10:15:28',11,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-05-11  04:21:24',10,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2020-04-13  02:35:25',10,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2020-05-12  04:35:25',8,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-05-14  05:35:25',5,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2020-08-25  06:35:25',6,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-06-04  08:35:25',11,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2010-01-16  09:35:25',12,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-05-15  11:35:25',3,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2023-05-04  09:46:25',12,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-09-16  04:13:25',8,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-05-28  05:42:25',7,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2023-06-28  10:45:24',8,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-04-28  11:06:24',4,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-05-28  09:14:24',5,'Approved'); 

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2021-06-28  09:24:45',6,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2020-04-05  10:24:24',8,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-05-04  07:11:10',1,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2018-05-06  10:12:40',3,'Approved');

INSERT INTO orders(order_date,cust_id,status)
            VALUES        ('2019-06-04  01:30:57',4,'Approved');
            
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78),   
						(2,3,53),
						(3,1,30),
						(4,4,45);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,1,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,3,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,4,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,5,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,6,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,7,31);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,8,20);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,9,1);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,10,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,11,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(2,7,9);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(3,3,10);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(3,11,5);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(4,7,15);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(30,17,21);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(31,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(31,4,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(31,18,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(31,19,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(18,18,5);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(11,11,9);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(19,12,4);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(20,15,3);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,7,2);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,3,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,12,10);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,19,14);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(13,2,5);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(13,3,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(15,5,9);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(29,10,10);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(29,15,15);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(28,5,34);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(28,17,42);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(15,15,24);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(12,12,12);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(12,8,20);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(25,18,32);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(2,8,21);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,5,13);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(11,1,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(12,2,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(13,3,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(7,7,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(7,8,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,8,28);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,15,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(6,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(6,5,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(5,10,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(4,12,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(4,13,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(11,14,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(21,15,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,16,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,17,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,18,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,19,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(12,12,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,3,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,5,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,6,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,7,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(14,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(16,2,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(18,2,6);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(19,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(20,2,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(21,2,8);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(22,2,7);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,78);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,4);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,48);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(1,2,48);
INSERT INTO orderdetails(order_id,product_id,quantity) 
                  VALUES(19,2,78);

 
>>>>>>> 40c693edac06cdb7a6bbe9532dfd00715b8c7933

SELECT * FROM users;

SELECT * FROM customers;

SELECT * FROM addresses;

SELECT * FROM products;

SELECT * FROM orders;

SELECT * FROM orderdetails;