DROP PROCEDURE IF EXISTS `VerifyCredentials`;
DELIMITER $$
CREATE PROCEDURE VerifyCredentials
(
	IN `userNameParam` VARCHAR(50),
	IN `passwordParam` BINARY(64)
)
BEGIN
	DECLARE entriesCount INT DEFAULT 0;
	
	SELECT
		COUNT(*) 
	INTO entriesCount
		FROM
			users
		WHERE
			username = usernameParam
			AND passwordHash = passwordParam;
	
	SELECT entriesCount AS entriesCount;
END$$
DELIMITER ;
