

CREATE TABLE `products` (
  `ProductID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(40) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `SupplierID` int(10) unsigned NOT NULL,
  `CategoryID` tinyint(5) unsigned NOT NULL,
  `QuantityPerUnit` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `UnitPrice` double NOT NULL DEFAULT '0',
  `UnitsInStock` smallint(5) unsigned NOT NULL DEFAULT '0',
  `UnitsOnOrder` smallint(5) unsigned NOT NULL DEFAULT '0',
  `ReorderLevel` smallint(5) unsigned NOT NULL DEFAULT '0',
  `Discontinued` enum('y','n') CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL DEFAULT 'n',
  PRIMARY KEY (`ProductID`),
  KEY `FK_products_categoryid` (`CategoryID`),
  KEY `FK_products_supplierid` (`SupplierID`),
  KEY `idx_products_product_name` (`ProductName`),
  CONSTRAINT `FK_products_categoryid` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`),
  CONSTRAINT `FK_products_supplierid` FOREIGN KEY (`SupplierID`) REFERENCES `suppliers` (`SupplierID`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8;




CREATE TABLE IF NOT EXISTS `categories` 
(
  `CategoryID` tinyint(5) unsigned NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(15) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `Description` mediumtext CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Picture` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`CategoryID`),
  UNIQUE KEY `Uidx_categories_category_name` (`CategoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;