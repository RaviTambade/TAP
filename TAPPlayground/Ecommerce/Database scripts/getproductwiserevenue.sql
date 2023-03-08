CREATE DEFINER=`root`@`localhost` PROCEDURE `getproductwiserevenue`()
BEGIN
		SELECT
				orderdetails.product_id,products.title,
				SUM(orderdetails.quantity) * products.unit_price as revenue
		FROM orderdetails, products
		WHERE
			 orderdetails.product_id = products.product_id
		GROUP BY product_id;
END