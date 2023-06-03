## RU
Администратор сайта с пользователями уехал в отпуск и оставил на вас задачу добавлять новых пользователей.

Чтобы не запутаться он оставил инструкции о том как устроена база и как происходит добавление, но сказали что таблица с ключами уже не используется, так-что не обращайте не нее внимание :)

---
## EN
The website administrator went on vacation and left you with the task of adding new users.

To avoid getting confused, he left instructions on how the database is structured and how the adding process works, but they mentioned that the table with keys is no longer in use, so please ignore it completely :)

```sql
CREATE TABLE IF NOT EXISTS users
                      (id INTEGER PRIMARY KEY AUTOINCREMENT,
                      name TEXT NOT NULL,
                      email TEXT NOT NULL,
                      password TEXT NOT NULL)

CREATE TABLE IF NOT EXISTS keys
                      (id INTEGER PRIMARY KEY AUTOINCREMENT,
                      name TEXT NOT NULL)
.
.
.
--happens when want to insert new user
f'INSERT INTO users (name, email, password) VALUES ('{name}', '{email}', '{password}')'
```
