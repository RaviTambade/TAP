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

SELECT * FROM users;

SELECT * FROM customers;

SELECT * FROM addresses;

SELECT * FROM products;

SELECT * FROM orders;

SELECT * FROM orderdetails;