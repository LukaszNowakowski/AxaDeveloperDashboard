DROP PROCEDURE IF EXISTS `FetchEnvironments`;
DELIMITER $$
CREATE PROCEDURE `FetchEnvironments`
(
	IN `userNameParam` VARCHAR(50)
)
BEGIN
	SELECT
		envs.id AS EnvironmentId,
		envs.displayName AS EnvironmentName,
		envs.order AS EnvironmentOrder
		FROM
			environments AS envs;
END $$
DELIMITER ;
