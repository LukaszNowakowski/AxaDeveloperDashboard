DROP PROCEDURE IF EXISTS `FetchLinks`;
DELIMITER $$
CREATE PROCEDURE `FetchLinks`
(
	IN `userNameParam` VARCHAR(50)
)
BEGIN
	SELECT
		envs.id AS EnvironmentId,
		envs.displayName AS EnvironmentName,
		li.id AS LinkId,
		li.displayName AS LinkName,
		li.icon AS LinkIcon,
		li.url AS Url
		FROM
			environments AS envs
			JOIN links AS li
				ON envs.id = li.environmentId
		ORDER BY
			envs.order ASC,
			li.order ASC;
END $$
DELIMITER ;
