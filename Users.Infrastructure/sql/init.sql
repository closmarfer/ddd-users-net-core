CREATE SCHEMA IF NOT EXISTS users;
USE users;
CREATE TABLE IF NOT EXISTS `users` (
    `uuid` varchar(255) NOT NULL,
    `email` varchar(200) NOT NULL,
    `password` varchar(254) NOT NULL,
    `name` varchar(200) NOT NULL,
    `surname` varchar(200) NOT NULL,
    `phone_number` int(11) NOT NULL,
    `postal_code` mediumint(9) NOT NULL,
    `country_code` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE USER 'root'@'%' IDENTIFIED BY 'root';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;