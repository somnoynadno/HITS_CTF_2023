DROP TABLE IF EXISTS arrays;
DROP TABLE IF EXISTS secret;

CREATE TABLE arrays (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    created TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    title TEXT NOT NULL,
    content TEXT NOT NULL
);

CREATE TABLE secret (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    content TEXT NOT NULL
);