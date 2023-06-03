import psycopg2
from psycopg2 import sql
from psycopg2.extensions import ISOLATION_LEVEL_AUTOCOMMIT
from flask import Flask, request, render_template
app = Flask(__name__)


def get_db_connection():
    conn = psycopg2.connect(
        dbname="kt0_db",
        user="postgres",
        password="admin",
        host="db",
        port="5432"
    )
    return conn

def create_database():
    conn = psycopg2.connect(
        dbname="postgres",
        user="postgres",
        password="admin",
        host="db",
        port="5432"
    )
    conn.set_isolation_level(ISOLATION_LEVEL_AUTOCOMMIT)
    cursor = conn.cursor()
    create_db_query = sql.SQL("CREATE DATABASE {}").format(sql.Identifier("kt0_db"))
    cursor.execute(create_db_query)
    cursor.close()
    conn.close()

def create_table():
    conn = get_db_connection()
    cursor = conn.cursor()
    create_table_query = """
        CREATE TABLE IF NOT EXISTS Users (
            id SERIAL PRIMARY KEY,
            login VARCHAR(255) NOT NULL,
            password VARCHAR(255) NOT NULL
        )
    """

    cursor.execute(create_table_query)
    users = [
        ('user1', '$2b$10$gSd4ntHj96biDLMgR0GMIOzH6KjprzN3OJKZ8mdUnS9gnrsC7SC/O'),
        ('user2', '$2b$12$AeDzRGXWZ1KqQbATKboeUu/V21LWuQ8rrz7X.3oxmzMFs8r6heQKC'),
        ('user3', '$2y$10$ZHFXQ08NpPQ85kXCMiMDGO1.7GqLH0GhGvI8JPN/J1s8Sqf3AQ8aa'),
        ('admin', "HITS{why-th1s-passw0rd-1s-n0t-hashed}")
    ]
    
    insert_query = "INSERT INTO Users (login, password) VALUES (%s, %s)"
    
    cursor.executemany(insert_query, users)

    conn.commit()
    cursor.close()
    conn.close()

try:
    conn = get_db_connection()
    print("Подключение к базе данных успешно установлено!")
    cursor = conn.cursor()
    cursor.execute("SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';")
    tables = cursor.fetchall()
    for table in tables:
        print(table[0])
    conn.close()
except psycopg2.Error as e:
    create_database()
    create_table()


@app.route('/', methods=['GET'])
def users():
    search_keyword = request.args.get('search')
    conn = get_db_connection()
    cursor = conn.cursor()
    if search_keyword:
        if not ("DELETE" in search_keyword or "UPDATE" in search_keyword or "DROP" in search_keyword or "INSERT" in search_keyword):
            search_query = f"SELECT login FROM Users WHERE login LIKE '%{search_keyword}%'"
            print(f"SELECT login FROM Users WHERE login LIKE '%{search_keyword}%'")
            cursor.execute(search_query)
        else:
            cursor.execute("SELECT login FROM Users")
    else:
        cursor.execute("SELECT login FROM Users")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return render_template('Users.html', rows=rows)