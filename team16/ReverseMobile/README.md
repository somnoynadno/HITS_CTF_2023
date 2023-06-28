# ReverseMobile

## Описание

Автор: C. А. Великанова (solntselikaya)  
Название: Очень-очень плохая ОПГ  
Лицензия: MIT License  
Сложность: см. [Предыстория](#Предыстория)  
Описание: Реверс-инжиниринг и исследование мобильных приложений на предмет наличия флагов  
Теги: mobile, reverse  

## Предыстория

Команда очень, _ОЧЕНЬ_ плохих ребят решила создать свою социальную сеть, чтобы планировать и организовывать свои очень, _ОЧЕНЬ_ плохие дела. Так уж вышло, что все эти ребята, помимо того что были очень _ОЧЕНЬ_ плохими людьми, были настолько же плохими мобильными разработчиками (и не беспокоились о безопасности).  
Нам удалось получить копию их очень, _ОЧЕНЬ_ плохого мобильного приложения и теперь вам предстоит примерить на себя роль очень, _ОЧЕНЬ_ хороших безопасников и найти все тайные послания для членов очень, _ОЧЕНЬ_ плохой организации.

##### 1. Получите день и время еженедельных собраний (Low)

Так как очень, _ОЧЕНЬ_ плохие ребята считают себя очень, _ОЧЕНЬ_ крутыми программистами, они общаются только на _1337_. На кнопке написано "wh47 71m3"... Что же это? На экране появились какие-то непонятные символы...

##### 2. Найдите кодовое слово для прохода на базу (Low)

"Navigate me!" - это фраза точно как-то связана с очень, _ОЧЕНЬ_ плохой организацией и её собранием... Может ли секретное слово прятаться где-то внутри?

##### 3. Найдите адрес базы (Medium)

Самое важное всегда сложнее всего найти. Нужно попытаться взломать их очень, _ОЧЕНЬ_ плохую социальную сеть и найти, где же проходят их очень, _ОЧЕНЬ_ плохие собрания.

## Флаги

1. HITS{day_f21d4y_time_8AM}
2. HITS{s3cr3t_w02d_1s_c4pyb4r4}
3. HITS{4ddr3ss_1s_l3n1na_36_k0rpu5_no_2}

## Развертывание

`docker compose up` для поднятия бэка для 3-й задачи

## Решение

##### 1. День и время

-) Запустить приложение, нажать на кнопку с текстом "wh47 71m3". На появившемся экране нажать на кнопку "WHEN?"   
-) На экране появились нечитаемые символы и снизу появился алерт-диалог с подсказкой: "wr0ng ch@rset"  
-) Reverse APK   
-) Зайти на главный экран. Найти экран(фрагмент), на который навигируемся при нажатии на кнопку с текстом "wh47 71m3" ([FirstFragment.kt](https://gitlab.com/ctfteam16/reversemobile/-/blob/app/app/src/main/java/com/example/ctfapp/fragments/FirstFragment.kt))  
-) При нажатии на кнопку "WHEN?" на этом экране, вызывается функция "getStringFromByteArray" из файла [Functions.kt](https://gitlab.com/ctfteam16/reversemobile/-/blob/app/app/src/main/java/com/example/ctfapp/everything/Functions.kt)   
-) Находим, где в функции используется Charset, заменяем его на стандартный UTF-8
```kotlin
fun getStringFromByteArray(byteArray: ByteArray): Pair<String, Charset> {
    val charset: Charset = Charsets.UTF_8
    var result = SECRET_BYTE_ARRAY.toString(charset)
    var cnt = ""
    for (byte in byteArray) {
        val char = byte.toString()
        result += char
        cnt += char
    }
    return Pair(result.replace(cnt, ""), charset)
}

```  
-) Вновь запускаем приложение и повторяем действия с кнопками, на экране видим искомый флаг

##### 2. Кодовое слово

-) Запустить приложение, нажать на кнопку с текстом "Navigate me!"  
-) На появившемся экране видим текст с подсказкой(You've got to be careful if you don't know where you're going). Значит, задача каким-то образом связана с проходом, т.е. навигацией  
-) Reverse APK  
-) Зайти на главный экран. Найти экран(фрагмент), на который навигируемся при нажатии на кнопку с текстом "Navigate me!" ([SecondFragment.kt](https://gitlab.com/ctfteam16/reversemobile/-/blob/app/app/src/main/java/com/example/ctfapp/fragments/SecondFragment.kt))  
-) Посмотреть файл навигации([nav_graph.xml](https://gitlab.com/ctfteam16/reversemobile/-/blob/app/app/src/main/res/navigation/nav_graph.xml)) и найти там предопределенное значение nav_arg
```kotlin
<argument
            android:name="this_is_key"
            app:argType="string"
            android:defaultValue="HITS{s3cr3t_w02d_1s_c4pyb4r4}"
            app:nullable="true" />

```

##### 3. Адрес

-) Запустить приложение, нажать на кнопку логина  
-) Попробуем заполнить поле логина и пароля произвольными данными - получаем ошибку от сервера 400 (неверные логин или пароль)  
-) Reverse APK  
-) Найдем фрагмент, на который происходит навигация при нажатии на кнопку ([ThirdFragment.kt](https://gitlab.com/ctfteam16/reversemobile/-/blob/app/app/src/main/java/com/example/ctfapp/fragments/ThirdFragment.kt))  
-) Найдем, какая функция вызывается при нажатии на кнопку "Sign In"  
-) Функция вызывает usecase, который использует запросы на сервер. В API находим эндпоинт для получения флага  
-) Несмотря на то, что в запросе прописано наличие хедера авторизации, пробуем отправить запрос на сервер и получаем флаг! Т.к. хедер на самом деле не нужен.

