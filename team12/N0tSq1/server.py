import os
import threading
import logging
from flask import Flask, jsonify, render_template, request
import sqlite3

database = 'example.db'
key = r'HITS{53rv3r_15_up537}'


def create_table():
    conn = sqlite3.connect(database)
    cursor = conn.cursor()
    cursor.execute('''CREATE TABLE IF NOT EXISTS users
                      (id INTEGER PRIMARY KEY AUTOINCREMENT,
                      name TEXT NOT NULL,
                      email TEXT NOT NULL,
                      password TEXT NOT NULL)''')
    cursor.execute('''CREATE TABLE IF NOT EXISTS keys
                      (id INTEGER PRIMARY KEY AUTOINCREMENT,
                      name TEXT NOT NULL)''')
    cursor.execute(
        f"INSERT INTO keys (name) VALUES ('{key}')")
    conn.commit()
    conn.close()


app = Flask(__name__)
app.logger.setLevel(logging.DEBUG)
create_table()
thread_local = threading.local()


def get_db():
    if not hasattr(thread_local, 'connection'):
        thread_local.connection = sqlite3.connect(database)
    return thread_local.connection


def get_cursor():
    db = get_db()
    if not hasattr(thread_local, 'cursor'):
        thread_local.cursor = db.cursor()
    return thread_local.cursor


@app.route('/')
def index():
    cursor = get_cursor()
    cursor.execute("SELECT * FROM users")
    users = cursor.fetchall()
    return render_template('index.html')


@app.route('/users', methods=['GET'])
def get_users():
    users = request.args.get('users')
    cursor = get_cursor()
    cursor.execute(f"SELECT {users} FROM users")
    users = cursor.fetchall()
    response = []
    for user in users:
        response.append({
            'id': user[0],
            'name': user[1],
            'email': user[2] if len(user) > 2 else None
        })
    return jsonify(response)


@app.route('/add_user', methods=['POST'])
def add_user():
    cursor = get_cursor()
    data = request.get_json()
    name = data['name']
    email = data['email']
    password = data['password']
    try:
        cursor.executescript(
            f"INSERT INTO users (name, email, password) VALUES ('{name}', '{email}', '{password}')")
        get_db().commit()
    except Exception as e:
        app.logger.error(e)
        cursor.execute(
            f"INSERT INTO users (name, email, password) VALUES ('pl3ase', 'd0nt hackm3', '123')")
        get_db().commit()
    return f'Added user'


@app.route('/keys')
def return_forbidden():
    return "<h1>Haha not so easy!</h1><br/><h2>pl3ase d0nt hackm3 （；´д｀）ゞ</h2>"


if __name__ == '__main__':
    app.run(host='localhost', port=8080, debug=True)
