

USE Authentication;

CREATE TABLE roles (role_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, role varchar(25));
CREATE TABLE users( user_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, email VARCHAR(25) UNIQUE NOT NULL, contact_number VARCHAR(20) NOT NULL ,password VARCHAR(15) NOT NULL);
CREATE TABLE IF NOT EXISTS userroles(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,user_id INT,role_id INT,CONSTRAINT fk_Users FOREIGN KEY(user_id) REFERENCES users(user_id) ON UPDATE CASCADE ON DELETE CASCADE,CONSTRAINT fk_Roles FOREIGN KEY(role_id) REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE);

INSERT INTO roles (role) VALUES ("admin");
INSERT INTO roles (role) VALUES ("shipper");
INSERT INTO roles (role) VALUES ("supplier");
INSERT INTO roles (role) VALUES ("customer");
INSERT INTO roles (role) VALUES ("employee");

INSERT INTO users (email,contact_number,password) VALUES ("akash@gmail.com",9881571268,"akash@123");
INSERT INTO users (email,contact_number,password) VALUES ("veadnt@gmail.com",9881571267,"vedant@123");
INSERT INTO users (email,contact_number,password) VALUES ("akshay@gmail.com",9881571256,"akshay123");
INSERT INTO users (email,contact_number,password) VALUES ("pragati@gmail.com",9881571212,"pragati@123");
INSERT INTO users (email,contact_number,password) VALUES ("abhay@ajabgmail.com",9881571225,"abhay@123");
INSERT INTO users (email,contact_number,password) VALUES ("rohit@ajabgmail.com",9881571223,"rohit@123");
 
INSERT INTO userroles( user_id,role_id) VALUES (1,2);
INSERT INTO userroles( user_id,role_id) VALUES (1,3);
INSERT INTO userroles( user_id,role_id) VALUES (3,2);
INSERT INTO userroles( user_id,role_id) VALUES (5,2);
INSERT INTO userroles( user_id,role_id) VALUES (4,1);
INSERT INTO userroles( user_id,role_id) VALUES (2,2);
INSERT INTO userroles( user_id,role_id) VALUES (1,4);
INSERT INTO userroles( user_id,role_id) VALUES (3,5);
SELECT * from users;
SELECT * FROM userroles;
SELECT * FROM roles;



SELECT role from roles where role_id in  (select role_id from userroles where user_id=4);

SELECT * FROM users where email='akshay@gmail.com' AND password ='akshay123';
