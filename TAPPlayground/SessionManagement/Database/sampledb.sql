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