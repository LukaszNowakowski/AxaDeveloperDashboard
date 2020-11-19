CREATE TABLE users
(
	`id` INT AUTO_INCREMENT NOT NULL,
	`externalid` BINARY(16) NOT NULL,
	`username` VARCHAR(50) NOT NULL,
	`passwordSalt` BINARY(128) NOT NULL,
	`passwordHash` BINARY(64) NOT NULL,
	`displayName` VARCHAR(100) NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `users`
	ADD UNIQUE INDEX `UX_users_username` (`username`);

ALTER TABLE `users`
	ADD UNIQUE INDEX `UX_users_externalid` (`externalid`);

ALTER TABLE `users`
	ADD UNIQUE INDEX `UX_users_id` (`id`);

CREATE TABLE environments
(
	`id` INT AUTO_INCREMENT NOT NULL,
	`displayName` VARCHAR(50) NOT NULL,
	`userid` INT NOT NULL,
	`order` INT NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `environments`
	ADD UNIQUE INDEX `UX_environments_displayName` (`displayName`);

ALTER TABLE `environments`
	ADD UNIQUE INDEX `UX_environments_id` (`id`);

ALTER TABLE `environments`
	ADD CONSTRAINT `FK_environments_userid`
	FOREIGN KEY (`userid`)
	REFERENCES `users` (`id`);

CREATE TABLE links
(
	`id` INT AUTO_INCREMENT NOT NULL,
	`environmentid` INT NOT NULL,
	`displayName` VARCHAR(50) NOT NULL,
	`icon` NVARCHAR(50) NOT NULL,
	`url` NVARCHAR(4000) NOT NULL,
	`order` INT NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_displayName` (`environmentid`, `displayName`);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_icon` (`environmentid`, `icon`);

ALTER TABLE `links`
	ADD UNIQUE INDEX `UX_links_id` (`id`);

ALTER TABLE `links`
	ADD CONSTRAINT `FK_links_environmentid`
	FOREIGN KEY (`environmentid`)
	REFERENCES `environments` (`id`);
