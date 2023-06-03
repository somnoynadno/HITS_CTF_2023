# SqL1njecti0n (Easy)
# Legend
## RU
Некоторые люди совсем не умеют в безопасность сайтов, поможем им найти уязвимость в их приложении.
 
## EN
Some people do not know how to secure websites at all, we will help them find a vulnerability in their application.

# Description
Python Flask project with Postgre database.
Simple app vulnerable to sql injection

# Solution
- Past this `` ' UNION SELECT password FROM Users -- `` injection in search field.
- Observe the flag in admin password. 

# Flags
HITS{why-th1s-passw0rd-1s-n0t-hashed}

# Handout
Nothing
