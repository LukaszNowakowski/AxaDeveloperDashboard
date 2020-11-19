DROP PROCEDURE IF EXISTS `AddEnvironment`;
DELIMITER $$
CREATE PROCEDURE `AddEnvironment`
(
	IN `useridparam` INT,
	IN `displayNameParam` VARCHAR(50),
	IN `orderParam` INT
)
BEGIN
	INSERT INTO environments
		(displayName, `order`, userid)
		VALUES
		(displayNameParam, orderParam, useridparam);
END $$
DELIMITER ;
