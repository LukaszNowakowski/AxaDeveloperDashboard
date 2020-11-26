DROP PROCEDURE IF EXISTS `FetchEnvironments`;
DELIMITER $$
CREATE PROCEDURE `FetchEnvironments`
(
	IN `usernameparam` VARCHAR(50)
)
BEGIN
	SELECT
		envs.id AS EnvironmentId,
		envs.displayName AS EnvironmentName,
		envs.order AS EnvironmentOrder
		FROM
			environments AS envs
			JOIN users AS us
				ON envs.userid = us.id
		WHERE
			us.username = usernameparam;
END $$
DELIMITER ;
