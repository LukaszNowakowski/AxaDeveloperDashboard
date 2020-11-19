DROP PROCEDURE IF EXISTS `FetchEnvironments`;
DELIMITER $$
CREATE PROCEDURE `FetchEnvironments`
(
	IN `useridparam` INT
)
BEGIN
	SELECT
		envs.id AS EnvironmentId,
		envs.displayName AS EnvironmentName,
		envs.order AS EnvironmentOrder
		FROM
			environments AS envs
		WHERE
			envs.userid = useridparam;
END $$
DELIMITER ;
