CREATE database Ecommerce;
USE Ecommerce ;

CREATE TABLE
    users(
        user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        email VARCHAR(25) UNIQUE NOT NULL,
        contact_number VARCHAR(20) NOT NULL UNIQUE,
        password VARCHAR(15) NOT NULL
    );

CREATE TABLE
    customers(
        cust_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        first_name VARCHAR(25),
        last_name VARCHAR(25),
        email VARCHAR(25) UNIQUE NOT NULL,
        contact_number VARCHAR(20) UNIQUE NOT NULL,
        password VARCHAR(15) NOT NULL
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
        CONSTRAINT fk_customer_id_2 FOREIGN KEY(cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,
        address_mode ENUM('permanent', 'billing') NOT NULL,
        house_number VARCHAR(20),
        landmark VARCHAR(25) NOT NULL,
        city VARCHAR(25) NOT NULL,
        state VARCHAR(25) NOT NULL,
        country VARCHAR(25) NOT NULL,
        pincode VARCHAR(25) NOT NULL
    );

CREATE TABLE
    products (
        product_id INT PRIMARY KEY AUTO_INCREMENT,
        title VARCHAR(20) NOT NULL,
        description VARCHAR(50),
        stock_available INT NOT NULL,
        unit_price DOUBLE NOT NULL,
        image VARCHAR(40)
    );

CREATE TABLE
    orders(
        order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        order_date DATETIME DEFAULT CURRENT_TIMESTAMP,
        delivery_date DATETIME DEFAULT CURRENT_TIMESTAMP,
        cust_id INT NOT NULL,
        CONSTRAINT fk_customer_id FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON UPDATE CASCADE ON DELETE CASCADE,
        status ENUM('processing', 'deliverd') NOT NULL
    );

CREATE TABLE
    orderdetails(
        orderdetails_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        order_id INT NOT NULL,
        CONSTRAINT fk_order_id FOREIGN KEY (order_id) REFERENCES orders(order_id) ON UPDATE CASCADE ON DELETE CASCADE,
        product_id INT NOT NULL,
        CONSTRAINT fk_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON UPDATE CASCADE ON DELETE CASCADE,
        quantity INT NOT NULL
    );