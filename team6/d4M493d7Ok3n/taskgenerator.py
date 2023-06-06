import random
import base64
import string
import json

DEFAULT_FLAG = "JWT_41w4y5_st4rt5_w1th_3y"
LETTER_SHIFT = 11
DIGIT_SHIFT = 7
FLAG = "HITS{" + DEFAULT_FLAG + "}"

def letter_shift(plaintext, shift = LETTER_SHIFT):
    alphabet = string.ascii_lowercase
    shifted_alphabet = alphabet[shift:] + alphabet[:shift]
    table = str.maketrans(alphabet, shifted_alphabet)
    plaintext = plaintext.translate(table)
    
    alphabet = string.ascii_uppercase
    shifted_alphabet = alphabet[shift:] + alphabet[:shift]
    table = str.maketrans(alphabet, shifted_alphabet)
    return plaintext.translate(table)

def digit_shift(plaintext, shift = DIGIT_SHIFT):
    alphabet = string.digits
    shifted_alphabet = alphabet[shift:] + alphabet[:shift]
    table = str.maketrans(alphabet, shifted_alphabet)
    return plaintext.translate(table)

def shift(plaintext):
    return digit_shift(letter_shift(plaintext))

def string_to_ascii(string):
    answ = ""
    for s in string:
        answ = answ + str(ord(s))
    return answ

def token_header():
    header = json.dumps({"alg": "none", "digitShift": 7})
    header = base64.urlsafe_b64encode(header.encode("ascii")).decode("ascii")
    return header
    
def token_payload():
    payload_rubbish_keys = [string_to_ascii(i + "lag") for i in "qwertyuiopasdghjklzxcvbnm"]
    payload_rubbish_values = [shift("HITS{" + ''.join(random.choices(FLAG[5:-1], k=len(FLAG[5:-1]))) + "}") for key in payload_rubbish_keys]
    payload_rubbish_keys.append(string_to_ascii("flag"))
    payload_rubbish_values.append(shift(FLAG))
    payload_rubbish_keys_values = list(zip(payload_rubbish_keys, payload_rubbish_values))
    random.shuffle(payload_rubbish_keys_values)
    payload = dict(payload_rubbish_keys_values)
    payload = json.dumps(payload)
    payload = base64.urlsafe_b64encode(payload.encode("ascii")).decode("ascii")
    return payload
    
def token_signature():
    signature_sym = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXY0123456789"
    signature = ''.join(random.choices(signature_sym, k=50 + random.randrange(7)))
    signature = base64.urlsafe_b64encode(signature.encode("ascii")).decode("ascii")
    return signature
    
def token():
    return token_header() + "." + token_payload() + "." + token_signature()

def token_damaged():
    return token_header()[3:] + "." + token_payload()[2:] + "." + token_signature()



print(f"Флаг по умолчанию: {DEFAULT_FLAG}\nХотите использовать другой флаг? [y/n]")

choise = input().lower()
while choise != "y" and choise != "n":
    print(f"Некорректный ввод\nФлаг по умолчанию: {DEFAULT_FLAG}\nХотите использовать другой флаг? [y/n]")
    choise = input().lower()

if choise == "y":
    print("Введите флаг, он будет преобразован в формат HITS{...}. Пример: abcd => HITS{abcd}")
    user_flag = input()
    while (len(user_flag) < 1 or len(user_flag) > 64):
        print("Длина флага от 1 до 64 симв!")
        print("Введите флаг, он будет преобразован в формат HITS{...}. Пример: abcd => HITS{abcd}")
        user_flag = input()
    FLAG = "HITS{" + user_flag + "}"

task = token_damaged()
print(f"Задача сгенерирована\nТокен, в котором зашифрован флаг:\n{task}")
f = open("output.txt", "r+")
f.truncate(0)
f.write(task)
f.close()
print("Также токен был записан в файл output.txt")






