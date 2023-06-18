# Описание

(краткое описание для проверяющих)

- Задача предлагает юному программисту решить 1000 задачек. 
- Скрипт не поможет, потому что после примерно 500 задач вываливается сообщение о том, что нужно решать лапками. 
- Также не получится облегчить изменить сам пример, потому что вместе с ним идёт хэш, который в дальнейшем проверяет, что это действительно тот пример, который был изначально
 

### Автор
Команда 9
### Подсказки
- <input type="hidden"...
- guid нужен для того, чтобы генерировать **уникальное** значение, а не для того, чтобы генерировать **случайное** значение
### Интрукция по развёртыванию
1. Билдим образ
    - **docker build -t ctf-guid -f Dockerfile .**
1. Запускаем контейнер
    - **docker run --name ctf-guid -p 80:80 ctf-guid**
### Флаг
HITS{Mama, ya matematic!!}


Он находится во View/Home/Flag.cshtml
### Сложность
Medium
### Решение
Если проследить за тем, как меняется guid при отправки решения, можно заметить, что у него инкрементируются числа под определёнными индексами. 

Сначала под индексом 32:
1. 3b1937f4-e652-4b6b-b547-c298d959**4**ddb
2. 3b1937f4-e652-4b6b-b547-c298d959**5**ddb
3. 3b1937f4-e652-4b6b-b547-c298d959**6**ddb
4. 3b1937f4-e652-4b6b-b547-c298d959**7**ddb
5. 3b1937f4-e652-4b6b-b547-c298d959**8**ddb
6. 3b1937f4-e652-4b6b-b547-c298d959**9**ddb

Подом под 21
7. 3b1937f4-e652-4b6b-b5**5**7-c298d959**0**ddb
8. 3b1937f4-e652-4b6b-b5**5**7-c298d959**1**ddb
9. 3b1937f4-e652-4b6b-b5**5**7-c298d959**2**ddb
1. 3b1937f4-e652-4b6b-b5**5**7-c298d959**3**ddb
1. 3b1937f4-e652-4b6b-b5**5**7-c298d959**4**ddb

И так далее.

Чтобы решить ctf'ку, нужно дойти до вот такого id **4**b1937f4-e652-**4**b6b-b5**4**7-c298d959**4**ddb
### Лицензия
Copyright 2023 team 9

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.