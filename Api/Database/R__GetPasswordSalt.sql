DROP PROCEDURE IF EXISTS `GetPasswordSalt`;
DELIMITER $$
CREATE PROCEDURE `GetPasswordSalt`
(
	IN `userNameParam` VARCHAR(50)
)
BEGIN
	SELECT
		passwordSalt
		FROM
			users
		WHERE
			`username` = userNameParam;
END $$
DELIMITER ;
