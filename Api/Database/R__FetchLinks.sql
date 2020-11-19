DROP PROCEDURE IF EXISTS `FetchLinks`;
DELIMITER $$
CREATE PROCEDURE `FetchLinks`
(
	IN `useridparam` INT
)
BEGIN
	SELECT
		envs.id AS EnvironmentId,
		li.id AS LinkId,
		li.displayName AS LinkName,
		li.icon AS LinkIcon,
		li.url AS Url,
		li.order AS LinkOrder
		FROM
			environments AS envs
			JOIN links AS li
				ON envs.id = li.environmentId
		WHERE
			envs.userid = useridparam;
END $$
DELIMITER ;
