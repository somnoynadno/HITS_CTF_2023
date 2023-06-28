import logging
import os
from cryptography.fernet import Fernet

from flask import Flask, request


logging.basicConfig(level=logging.INFO if os.getenv("ENV") == "PRODUCTION" else logging.DEBUG,
        format='[%(asctime)s] [%(name)s] [%(levelname)s]: %(message)s', datefmt='%d-%b-%y %H:%M:%S')

FLAG = "HITS{game_An3o$n_w1N12}" #os.getenv("FLAG")

FERNET_KEY = b'gNVoRkn46rMECawSZcbEvLeypU1EDsQE_9Z_ahzNYt8='

_HelloIn9 = "1081526044305"  # "Hello" in the number system with a base of 9
_helloIn9 = "1525306621637"  # "hello" in the number system with a base of 9    

app = Flask(__name__)

baseHint = '<script>console.log(\'{}"\')</script>'
helloHint = 'hint:secret word is "Hello'
rickHint = 'https://clck.ru/3vyXS'


placeTaskPublicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDPhFo3ivPiZyX0f70AQgsdm1YucedOLLZtdg1A5PYQpfhJ00PR80ZpOdu4l/uhAEQwXrAW7c8/ZEixUpjxsq2/lDltwRMFPXGlFkYxpdbGB1WRm2eWkUsg1rGRCdyRoxRcVOz7d03pCNY5WKkorfdN+8O7ZET7Y9t4Wbh0tlwGYwIDAQAB"
placeTaskPrivateKey = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAM+EWjeK8+JnJfR/vQBCCx2bVi5x504stm12DUDk9hCl+EnTQ9HzRmk527iX+6EARDBesBbtzz9kSLFSmPGyrb+UOW3BEwU9caUWRjGl1sYHVZGbZ5aRSyDWsZEJ3JGjFFxU7Pt3TekI1jlYqSit9037w7tkRPtj23hZuHS2XAZjAgMBAAECgYEAyNHudJ3V0p27j1cm0l8XXrl6t0unanG+wUNjJA/vSME0/Eyk70KcOyyww3zhGDenxZ98jVPqIhCsgF3MgOpHVMRsbeI7p5TS00KPNgRw9rG3l4uXFw8B9tMXg4kw3T5PJoKj39dg4dXbv7Znzy095S53j2opHcAbui3x9qfoGcECQQD/V8YmpeIHLMi5qbVLUKA88zWnWs1LtQltFDXhMoyTELkN0NrIuEvY8WUtVylQKm9cKlGygPgTqyL3Q5nVxgkzAkEA0A0RzsfvLh8tFdN78XvC4vkfrRxZIXKk3J61tbZenE/LWC65x5VTmXsqCkWRInnpJBa+yLLbvjNPr7rSCbjuEQJACEyAAi2OBRGtjGs5mzMJojF9Yu0OkxFVNxhbD/CmpPj8KrjJA5EJ1gkycqDMlPBsIiC1+wk6BtmfD05BJ7OCBQJBAIJmvrOhwztgVQzqGjR4guVqij0hmIgLaGPTokb7wH8u0GA8ITuET/rSJL59bgNy7/srunbnDC5B0P9vFDj9zVECQHr1KU5HmOR7VcopCOE7BdFIPSS/R8fJipm1PdqKOTLHTvbm80gCBL2FQmfNY1thaDSvWptFg6hB9irOjXdQZVU="

placeTaskFirstCoordinate = "44.505911"
placeTaskSecondCoordinate = "-79.724613"

placeTaskFirstCoordinateEncrypted = "RDSerCmUFeCOBZH7LpKP2FPbp60vwwfvpb9YfXI52PQ1vd3dIF4hF8HwlQs1yi+IloiEHh+5p5A55FfyQ7Uh3JMpaLXsYxzGWQd2ZJbGxF+RjVJPTG2rlW5zWYbN94C92a8Dqh2s9FzwAVUwexXH9vZ+05zrbOV6egA62KEnp6E="
placeTaskSecondCoordinateEncrypted = "Bwn7pJZi94mjGCpRJvG54GFWMW6Pu2wXOollR5REohJCBScbaIfzVBDrpLL8z5FlDw29Id8cP7uX/KJh8J2lxIPE9HWu4KlgsYQbqRwIin01WqAVY2ozdTGNIdgeY+4CD/MfBD+JYSTWecsUvw3XeeFsctbsTaa/KW32GkpOd10="


@app.route('/', methods=['GET'])
def start_page():
    return '<title>Welcome</title>\
    <h1>Welcome to Anton Game</h1> \
    <p>To pass this game, you need to complete several tasks, the first is to send a special encrypted greeting to the endpoint /api/hellokey=...</p> or use form' \
    '<form action=\"/api/hello\" method=\"GET\">' \
                        '<label for=\"data\">Input secret message</label><br />' \
                        '<input name=\"key\"><br />' \
                        '<input type=\"submit\" id=\"submit_button\" /></form>'\
        + baseHint.format(helloHint)

@app.route('/api/hello', methods=['GET'])
def hello_page():
    print("Request from " + request.headers["User-Agent"])
    key = request.args.get('key')
    if not "Android" in request.headers["User-Agent"]:
        return "You are not from my app 😤😤😤"
    else:
        if len(key) == 0:
            return "<p>Where is you answer?...</p>"
        print(key)
        if key == _HelloIn9 or key == _helloIn9:
            return "Yessss😃😃😃. Now go to api/first and get your task. GL" + '<form action="/api/first"><input type="submit" value="Next task..." /></form>'
        return "<p>Wrong!</p>" + baseHint.format(rickHint)

@app.route('/api/first', methods=['GET'])
def place_task_page():
    print("Request from " + request.headers["User-Agent"])
    key = request.args.get('key')
    if not "Android" in request.headers["User-Agent"]:
        return "You are not from my app 😤😤😤"
    return "<p>looks like rsa... find the solution to the riddle😃 </p>" + placeTaskFirstCoordinateEncrypted + "</br>" + placeTaskSecondCoordinateEncrypted + baseHint.format("next station is api/flag?key=...")


@app.route('/api/flag', methods=['GET'])
def get_flag_page():
    print("Request from " + request.headers["User-Agent"])
    key = request.args.get('key')
    if not "Android" in request.headers["User-Agent"]:
        return "You are not from my app 😤😤😤"
    if key != "2000":
        return "<p>Wrong!</p>" + baseHint.format(rickHint)
    f = Fernet(FERNET_KEY)
    token = f.encrypt(bytes(FLAG, encoding='utf8'))
    # flag decrypt
    # f.decrypt(token)
    return "You're almost done, the last task is to decrypt the flag!!!</br>" + str(token)


if __name__ == "__main__":
  debug = False if os.getenv("ENV") == "PRODUCTION" else True
  app.run(host="0.0.0.0", port=7004, debug=debug)
