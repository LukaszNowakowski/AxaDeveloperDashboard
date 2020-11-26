DROP PROCEDURE IF EXISTS `AddEnvironment`;
DELIMITER $$
CREATE PROCEDURE `AddEnvironment`
(
	IN `usernameparam` INT,
	IN `displayNameParam` VARCHAR(50),
	IN `orderParam` INT
)
BEGIN
	DECLARE useridparam VARCHAR(50);
	SELECT
		useridparam = id
		FROM
			users
		WHERE
			username = usernameparam;

	INSERT INTO environments
		(displayName, `order`, userid)
		VALUES
		(displayNameParam, orderParam, useridparam);
END $$
DELIMITER ;
