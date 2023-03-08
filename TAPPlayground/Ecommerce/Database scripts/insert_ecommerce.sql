INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('sahil','mankar','sahil@123','9960916323','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('abhay','navle','abhay','9075966080','sahil@123');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('akshay','gawali','ak@56','9960999801','akgwa@5656');
INSERT INTO customers(first_name,last_name,email,contact_number,password) VALUES ('pratik','sathe','pra@9999#','7786999801','prt@5676');

INSERT INTO products(title,description,stock_available,unit_price,image) VALUES('ParleG','tasty biscuits',20000,10,'./images/Parleg.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('GoodDay','tasty cookies',50000,15,'./images/goodday.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('MariGold','tasty biscuits',40000,16,'./images/marigold.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('20-20','tasty biscuits', 70000, 10,'./images/2020.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Crack-Jack','tasty biscuits',30000,10,'./images/crackjack.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Britania','healthy biscuits',40000,10,'./images/britania.jpg');
INSERT INTO products(title,description,stock_available,unit_price,image)VALUES('Hide&Seek','chocolate biscuits',50000,10,'./images/hideandseek.jpg');

/*possible vales  for addressmode:1:only residential ,2:only delivery address,3:residentail and delivery*/
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'permanent','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(1,'billing','houseNo.12','Pune-Nashik Highway','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','123321');
INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(2,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','121321');

INSERT INTO orders(order_date, cust_id)VALUES ('2020-08-25  06:35:25', 1);
INSERT INTO orders(order_date, cust_id)VALUES ('2021-06-04  08:35:25', 1);
INSERT INTO orders(order_date, cust_id)VALUES ('2010-01-16  09:35:25', 2);
INSERT INTO orders(order_date, cust_id)VALUES ('2021-05-15  11:35:25', 2);

INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 1, 70);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(1, 2, 700);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(2, 3, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 4, 78);
INSERT INTO orderdetails(order_id, product_id, quantity)VALUES(3, 1, 78);
insert into orderdetails(order_id,product_id,quantity) VALUES (7,2,2000);
insert into orderdetails(order_id,product_id,quantity) VALUES (8,3,3000);
insert into orderdetails(order_id,product_id,quantity) VALUES (9,5,5000);
