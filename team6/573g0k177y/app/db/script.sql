CREATE USER 'kitty'@'%' IDENTIFIED WITH mysql_native_password BY '7ud-JLM2.hVYFjY';GRANT SELECT ON *.* TO 'kitty'@'%';ALTER USER 'kitty'@'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;


CREATE TABLE users (
  cat_name VARCHAR(50),
  login VARCHAR(50),
  age INT,
  weight FLOAT,
  secret_code VARCHAR(100)
);

INSERT INTO users (cat_name, login, age, weight, secret_code)
VALUES
  ('Whiskers', 'johndoe', 4, 5.2, 'ABCD1234'),
  ('Mittens', 'janedoe', 2, 7.1, 'EFGH5678'),
  ('Snowball', 'snowball789', 1, 3.8, 'IJKL9012'),
  ('Felix', 'felixcat', 5, 6.5, 'MNOP3456'),
  ('Luna', 'lunacat', 3, 4.9, 'QRST7890'),
  ('AdminKitty', 'Admin', 11, 8.2, 'HITS{V45y4_L0v35_8lu3_c0L0UR}');