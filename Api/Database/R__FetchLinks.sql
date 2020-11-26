DROP PROCEDURE IF EXISTS `FetchLinks`;
DELIMITER $$
CREATE PROCEDURE `FetchLinks`
(
	IN `usernameparam` VARCHAR(50)
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
			JOIN users AS us
				ON envs.userid = us.id
		WHERE
			us.username = usernameparam;
END $$
DELIMITER ;
