CREATE TABLE environments
(
	`id` INT AUTO_INCREMENT NOT NULL,
	`displayName` VARCHAR(50) NOT NULL,
	`order` INT NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `environments`
	ADD UNIQUE INDEX `UX_environments_displayName` (`displayName`);

ALTER TABLE `environments`
	ADD UNIQUE INDEX `UX_credentials_id` (`id`);

CREATE TABLE links
(
	`id` INT AUTO_INCREMENT NOT NULL,
	`environmentId` INT NOT NULL,
	`displayName` VARCHAR(50) NOT NULL,
	`icon` NVARCHAR(50) NOT NULL,
	`url` NVARCHAR(4000) NOT NULL,
	`order` INT NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_displayName` (`environmentId`, `displayName`);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_icon` (`environmentId`, `icon`);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_id` (`id`);

INSERT INTO `environments` (`id`, `displayName`, `order`) VALUES
(1,	'LOCAL',	1),
(2,	'DIT01',	2),
(3,	'DIT02',	3)
ON DUPLICATE KEY UPDATE `id` = VALUES(`id`), `displayName` = VALUES(`displayName`), `order` = VALUES(`order`);

INSERT INTO `links` (`id`, `environmentId`, `displayName`, `icon`, `url`, `order`) VALUES
(1,	1,	'environments',	'dashboard',	'http://localhost/CustomerService',	1),
(2,	1,	'Private Domain',	'account_circle',	'http://localhost/Sandpiper.UI.FrontOffice/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn',	2),
(3,	1,	'Tools',	'build',	'http://localhost/Sandpiper.UI.Tools',	3),
(4,	2,	'CSA',	'dashboard',	'http://ext-env1.ppglobaldirect.intraxa/CustomerService',	1),
(5,	2,	'Private Domain',	'account_circle',	'http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn',	2),
(6,	2,	'Tools',	'build',	'http://ext-env1.ppglobaldirect.intraxa/Tools',	3),
(7,	3,	'CSA',	'dashboard',	'http://ext-env3.ppglobaldirect.intraxa/CustomerService',	1),
(8,	3,	'Private Domain',	'account_circle',	'http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn',	2),
(9,	3,	'Tools',	'build',	'http://ext-env3.ppglobaldirect.intraxa/Tools',	3)
ON DUPLICATE KEY UPDATE `id` = VALUES(`id`), `environmentId` = VALUES(`environmentId`), `displayName` = VALUES(`displayName`), `icon` = VALUES(`icon`), `url` = VALUES(`url`), `order` = VALUES(`order`);
