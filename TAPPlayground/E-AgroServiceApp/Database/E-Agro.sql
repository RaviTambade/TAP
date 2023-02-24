USE eagroservicesdb;


CREATE TABLE
  users(
    userId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    contactNumber BIGINT NOT NULL UNIQUE,
    password varchar(10) NOT NULL,
    role varchar(15) NOT NULL
  );


CREATE TABLE
  farmers(
    farmerId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    farmerName VARCHAR(30) NOT NULL,
    contactNumber BIGINT NOT NULL UNIQUE,
    password VARCHAR(10) NOT NULL,
    location varchar(20) NOT NULL,
    creditBalance DOUBLE DEFAULT 0,
    debitBalance DOUBLE DEFAULT 0,
    balance DOUBLE AS (creditBalance - debitBalance)
  );


CREATE TABLE
  transports(
    truckNumber VARCHAR(15) NOT NULL UNIQUE PRIMARY KEY,
    officeName VARCHAR(20) NOT NULL,
    ownerName VARCHAR(20) NOT NULL,
    contactNumber BIGINT NOT NULL,
    location VARCHAR(20) NOT NULL
  );


CREATE TABLE
  consignees(
    consigneeId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    consigneeName VARCHAR(20) NOT NULL,
    contactNumber BIGINT NOT NULL,
    location VARCHAR(20) NOT NULL
  );


CREATE TABLE
  purchasedItems (
    purchaseId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    farmerId INT NOT NULL,
    variety VARCHAR(20) NOT NULL,
    bags INT NOT NULL,
    totalWeight DOUBLE NOT NULL,
    tareWeight DOUBLE NOT NULL,
    netWeight DOUBLE AS (totalWeight - tareWeight),
    ratePerKg DOUBLE NOT NULL,
    labourCharges DOUBLE DEFAULT 0,
    totalAmount DOUBLE AS ((netWeight * ratePerKg) - labourCharges),
    date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_farmers FOREIGN KEY (farmerId) REFERENCES farmers(farmerId) ON UPDATE CASCADE ON DELETE CASCADE
  );


CREATE TABLE
  soldItems(
    sellid INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    purchaseId INT NOT NULL,
    consigneeId INT,
    truckNumber VARCHAR(15),
    netWeight DOUBLE NOT NULL,
    rateperkg DOUBLE,
    totalAmount DOUBLE AS (netWeight * rateperkg),
    date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_purchaseId FOREIGN KEY (purchaseId) REFERENCES purchasedItems(purchaseId) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT fk_consigneeId FOREIGN KEY (consigneeId) REFERENCES consignees(consigneeId) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT fk_truckNumber FOREIGN KEY (truckNumber) REFERENCES transports(truckNumber) ON UPDATE CASCADE ON DELETE CASCADE
  );


CREATE TABLE
  farmerPurchasesBilling(
    billId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    farmerId INT NOT NULL,
    item1 VARCHAR(20),
    quantity1 INT DEFAULT 0,
    rate1 DOUBLE DEFAULT 0,
    amount1 DOUBLE AS (quantity1 * rate1),
    item2 VARCHAR(20),
    quantity2 INT DEFAULT 0,
    rate2 DOUBLE DEFAULT 0,
    amount2 DOUBLE AS (quantity2 * rate2),
    item3 VARCHAR(20),
    quantity3 INT DEFAULT 0,
    rate3 DOUBLE DEFAULT 0,
    amount3 DOUBLE AS (quantity3 * rate3),
    item4 VARCHAR(20),
    quantity4 INT DEFAULT 0,
    rate4 DOUBLE DEFAULT 0,
    amount4 DOUBLE AS (quantity4 * rate4),
    item5 VARCHAR(20),
    quantity5 INT DEFAULT 0,
    rate5 DOUBLE DEFAULT 0,
    amount5 DOUBLE AS (quantity5 * rate5),
    totalAmount DOUBLE AS (
      (amount1) + (amount2) + (amount3) + (amount4) + (amount5)
    ),
    CONSTRAINT fk_farmers1 FOREIGN KEY (farmerId) REFERENCES farmers(farmerId) ON UPDATE CASCADE ON DELETE CASCADE
  );


CREATE TRIGGER sell_insert AFTER INSERT ON purchasedItems FOR EACH ROW BEGIN
INSERT INTO
  soldItems(purchaseId, netWeight)
VALUES
  (NEW.purchaseId, NEW.netWeight);


END;


CREATE TRIGGER add_user AFTER INSERT ON farmers FOR EACH ROW BEGIN
INSERT INTO
  users (contactNumber, password, role)
VALUES
  (NEW.contactNumber, NEW.password, 'farmer');


END;


CREATE TRIGGER del_user AFTER DELETE ON farmers FOR EACH ROW BEGIN
DELETE FROM
  users
WHERE
  contactNumber = OLD.contactNumber;


END;


CREATE TRIGGER credit_balance AFTER INSERT ON purchasedItems FOR EACH ROW BEGIN
UPDATE
  farmers
SET
  creditBalance = creditBalance + NEW.totalAmount
WHERE
  farmerId = NEW.farmerId;


END;


CREATE TRIGGER debit_balance AFTER INSERT ON farmerPurchasesBilling FOR EACH ROW BEGIN
UPDATE
  farmers
SET
  debitBalance = debitBalance + NEW.totalAmount
WHERE
  farmerId = NEW.farmerId;


END;


INSERT INTO
  users(contactNumber, password, role)
VALUES
  (9075966080, 'password', 'Admin');


INSERT INTO
  farmers(farmerName, contactNumber, password, location)
VALUES
  (
    'Shubham Balasaheb Teli',
    7448022744,
    'password',
    'Bhavadi'
  ),
  (
    'Sahil Sahebrao Mankar',
    8530728589,
    'password',
    'Pargaon'
  ),
  ('Kuldeep Apune', 9373306793, 'pass@123', 'Chakan');


INSERT INTO
  transports
VALUES
  (
    'MH14RE0001',
    'OMSAI transports',
    'Sohail Khan',
    8989878787,
    'Pargaon'
  );


INSERT INTO
  consignees(consigneeName, contactNumber, location)
VALUES
  ('BT Company', 9090909090, 'Manchar');


INSERT INTO
  purchasedItems(
    farmerId,
    variety,
    bags,
    totalWeight,
    tareWeight,
    ratePerKg,
    labourCharges
  )
VALUES
  (1, 'Potato', 100, 5000, 50, 25, 700), (2, 'Bhendi', 10, 50, 2, 25, 5),(3, 'Kobi', 10, 500, 10, 25, 50);


UPDATE
  soldItems
set
  consigneeId = 1,
  truckNumber = 'MH14RE0001',
  rateperkg = 27.40
WHERE
  purchaseId = 1;


INSERT INTO
  farmerPurchasesBilling(farmerId, item1, quantity1, rate1)
VALUES
  (1, 'Oberon', 3, 150),(2,'Topper 77',5,110),(3,'M-45',2,180);