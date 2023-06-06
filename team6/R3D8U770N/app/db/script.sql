CREATE USER 'redbutton'@'%' IDENTIFIED WITH mysql_native_password BY 'ZvHqyEylzlSi1Ep3';GRANT SELECT ON *.* TO 'redbutton'@'%';ALTER USER 'redbutton'@'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;


CREATE TABLE `users`(
    `userid` varchar(36),
    `login` varchar(12) NOT NULL,
    `password` varchar(30) NOT NULL,
    `role` enum("User", "Admin") NOT NULL,
    PRIMARY KEY(`userid`),
    UNIQUE(`login`)
);

CREATE TABLE `users_info`(
    `userid` varchar(36),
    `fullName` varchar(60) NOT NULL,
    `email` varchar(30) NOT NULL,
    `gender` enum("Male", "Female") NOT NULL,
    `birthDate` datetime(3),
    `address` varchar(100),
    `phoneNumber` varchar(11),
    PRIMARY KEY(`userid`),
    UNIQUE(`email`),
    UNIQUE(`phoneNumber`),
    CONSTRAINT check_email_user CHECK(`email` LIKE "%_@__%.__%"),
    CONSTRAINT check_fullName_user CHECK(
        `fullName` NOT LIKE "%[^a-zA-Zа-яА-ЯёЁ]%"
        AND LENGTH(`fullName`) > 4
    ),
    CONSTRAINT check_birthDate_user CHECK(`birthDate` > "1900-01-01"),
    CONSTRAINT check_phoneNumber_user CHECK(
        `phoneNumber` NOT LIKE "%[^0-9]%"
        AND `phoneNumber` LIKE "0%"
        AND LENGTH(`phoneNumber`) = 11
    ),
    FOREIGN KEY(`userid`) REFERENCES `users`(`userid`) ON UPDATE CASCADE
);


INSERT INTO `users`(`userid`, `login`, `password`, `role`) VALUES
    (
       "4ee393fc-af18-4636-be23-08dac7a0ede1",
       "johndoe",
       "johndoe2345675311R23",
       "User"
    ),
    (
       "775d387d-f057-4b40-be24-08dac7a0ede1",
       "alan375",
       "827842728Q4737WE28282B9212",
       "User"
    ),
    (
       "b6b5d138-72fe-40c1-be1e-08dac7a0ede1",
       "Admin",
       "A1B2E3A4GEB6A7A8$$#1880077",
       "Admin"
    ),
    (
       "990f9ed0-f57c-4cbf-be1f-08dac7a0ede1",
       "joehidden",
       "joehidden",
       "User"
    ),
    (
       "7cafca3e-8c70-4d6a-be31-08dac7a0ede1",
       "janedoe",
       "21B234FE23458$$#1880033",
       "User"
    );

INSERT INTO `users_info`(`userid`, `fullName`, `email`, `gender`, `birthDate`, `address`, `phoneNumber`) VALUES
    (
       "4ee393fc-af18-4636-be23-08dac7a0ede1",
       "John Doe",
       "johndoe@example.com",
       "Male",
       "1980-05-07",
       "London",
       "01414960845"
    ),
    (
       "775d387d-f057-4b40-be24-08dac7a0ede1",
       "Alan Smithee",
       "alansmth573@example.com",
       "Male",
       "1983-06-11",
       "Manchester",
       "01214960483"
    ),
    (
       "b6b5d138-72fe-40c1-be1e-08dac7a0ede1",
       "John Smith",
       "admin@redbutton.com",
       "Male",
       "1970-01-03",
       "Birmingham",
       "01144960977"
    ),
    (
       "990f9ed0-f57c-4cbf-be1f-08dac7a0ede1",
       "Joe Hidden",
       "joehidden@gmail.com",
       "Male",
       "1980-05-07",
       "Birmingham",
       "01144960223"
    ),
    (
       "7cafca3e-8c70-4d6a-be31-08dac7a0ede1",
       "Jane Doe",
       "janedoe@example.com",
       "Female",
       "1979-07-03",
       "London",
       "01414960507"
    );