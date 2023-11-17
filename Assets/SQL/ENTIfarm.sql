DROP TABLE IF EXISTS savedgames_cells;
DROP TABLE IF EXISTS savedgames;
DROP TABLE IF EXISTS plants_users;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS plants;

CREATE TABLE plants (
	id_plant INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
	plant VARCHAR(24) NOT NULL,
	time FLOAT NOT NULL,
	quantity INT NOT NULL,
	sell DECIMAL(9,2) NOT NULL,
	buy DECIMAL(9,2) NOT NULL,
	season INT
);

CREATE TABLE users (
	id_user INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
	user VARCHAR(12) NOT NULL,
	password CHAR(32) NOT NULL
);

CREATE TABLE plants_users (
	id_plant_user INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
	id_plant INT UNSIGNED NOT NULL,
	id_user INT UNSIGNED NOT NULL,
	FOREIGN KEY (id_plant) REFERENCES plants(id_plant),
	FOREIGN KEY (id_user) REFERENCES users(id_user)
);

CREATE TABLE savedgames (
	id_savedgame INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
	time FLOAT NOT NULL,
	size INT NOT NULL,
	money DECIMAL(9,2) NOT NULL,
	saved DATETIME DEFAULT NOW(),
	id_user INT UNSIGNED NOT NULL,
	FOREIGN KEY (id_user) REFERENCES users(id_user)
);

CREATE TABLE savedgames_cells (
	id_savedgame_cell INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
	x INT NOT NULL,
	y INT NOT NULL,
	time FLOAT NOT NULL,
	id_plant INT UNSIGNED NOT NULL,
	id_savedgame INT UNSIGNED NOT NULL,
	FOREIGN KEY (id_plant) REFERENCES plants(id_plant),
	FOREIGN KEY (id_savedgame) REFERENCES savedgames(id_savedgame)
);

INSERT INTO plants (plant, time, quantity, sell, buy)
	VALUES ("Nabo", 60, 8, 10, 56);
	
INSERT INTO users (user, password)
	VALUES ("enti", "enti");
	
INSERT INTO plants_users (id_plant, id_user)
	VALUES (1, 1);