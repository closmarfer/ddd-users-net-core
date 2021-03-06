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

CREATE USER IF NOT EXISTS 'root'@'%' IDENTIFIED BY 'root';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

# Inserting example user in order to test requests in Postman
INSERT INTO users (uuid, email, password, name, surname, phone_number, postal_code, country_code) 
VALUES ("08cfd822-66b4-4d10-a169-e9acea576ded", "test@test.com", "A8X0HynmsCNWHOCgKss9qGVEAY65T/sKhLcBWzWx5kw=", "User", "For Requests testing", 987456321, 13456, "es");