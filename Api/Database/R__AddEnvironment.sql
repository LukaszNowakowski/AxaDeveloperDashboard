DROP PROCEDURE IF EXISTS `AddEnvironment`;
DELIMITER $$
CREATE PROCEDURE `AddEnvironment`
(
	IN `displayNameParam` VARCHAR(50),
	IN `orderParam` INT
)
BEGIN
	INSERT INTO environments
		(displayName, `order`)
		VALUES
		(displayNameParam, orderParam);
END $$
DELIMITER ;