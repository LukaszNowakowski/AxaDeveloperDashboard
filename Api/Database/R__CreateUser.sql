DROP PROCEDURE IF EXISTS `CreateUser`;
DELIMITER $$
CREATE PROCEDURE `CreateUser`
(
	IN `externalIdParam` BINARY(16),
	IN `userNameParam` VARCHAR(50),
	IN `passwordSaltParam` BINARY(128),
	IN `passwordHashParam` BINARY(64),
	IN `displayNameParam` VARCHAR(100)
)
BEGIN
	INSERT INTO users
		(externalid, username, passwordsalt, passwordhash, displayname)
		VALUES
		(externalidparam, usernameparam, passwordsaltparam, passwordhashparam, displaynameparam);
END $$
DELIMITER ;
