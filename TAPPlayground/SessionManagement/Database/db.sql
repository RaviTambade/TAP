-- Active: 1677504645201@@127.0.0.1@3306@productinfo
CREATE TABLE
    products (
        productId INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(20) NOT NULL,
        description VARCHAR(50),
        price DOUBLE NOT NULL
    );

INSERT INTO
    products(name, description, price)
VALUES ('Biscuits', 'Tasty Snacks', 10),
       ('Maggi','Ready To Cook',12),
       ('Momos','Delicious',70);


SELECT * FROM products;