import json
from flask import Flask, request
from Data.Pizzas import get_pizzas, add_pizzas
from Data.Drinks import get_drinks, add_drinks
from Data.Rolls import get_rolls, add_rolls
from flask_cors import CORS

app = Flask(__name__)
CORS(app)


def checkroot():
    return ''


@app.route('/catalog/drinks/')
def get_drink():
    return get_drinks()


@app.route('/catalog/pizza')
def get_pizza():
    return get_pizzas()


@app.route('/catalog/rolls')
def get_roll():
    return get_rolls()


@app.route('/')
def hello_world():
    return 'Hello World!'


@app.route('/dish/add/<categoryId>', methods=['POST'])
def add_dish(categoryId):
    if request.method == 'POST':
        element = request.get_json()
        print(element)
        match categoryId:
            case "pizza":
                try:
                    if element['name'].lower() == "гавайская пицца":
                        element['description'] = "flag: rmr_v0zm1t3_n4_st4zh1r0vku"
                        element['pic'] = "https://images7.memedroid.com/images/UPLOADED997/5e7f866f978dd.jpeg"
                    add_pizzas(element)
                except:
                    return json.dumps({'success': False, "message": "can't add pizza"}), 500, {
                        'ContentType': 'application/json'}
            case "roll":
                try:
                    print(element)
                    add_rolls(element)
                except:
                    return json.dumps({'success': False, "message": "can't add roll"}), 500, {
                        'ContentType': 'application/json'}
            case "drink":
                try:
                    add_drinks(element)
                except:
                    return json.dumps({'success': False, "message": "can't add drink"}), 500, {
                        'ContentType': 'application/json'}
            case _:
                return json.dumps({'success': False, "message": "no such category"}), 400, {
                    'ContentType': 'application/json'}

        return json.dumps({'success': True}), 200, {'ContentType': 'application/json'}


@app.route('/checkpass', methods=['POST'])
def compare_passwords():
    password = request.get_json()['password']
    if password == 'gfhag7532kdfat':
        return json.dumps({'success': True}), 200, {'ContentType': 'application/json'}
    else:
        return json.dumps({'success': False}), 200, {'ContentType': 'application/json'}


if __name__ == '__main__':
    app.run()
