import pickle
import base64
from flask import Flask, request, render_template

app = Flask(__name__)


MAX_FILE_SIZE = 10 * 1024 * 1024  # 10MB


@app.route('/')
def index():
    return render_template('index.html')


@app.route("/save", methods=["POST"])
def save_pickled_data():
    try:
        if 'file' not in request.files:
            return "No file provided.", 400

        uploaded_file = request.files['file']
        pickled_data = uploaded_file.read()
        if len(pickled_data) > MAX_FILE_SIZE:
            return "Your file is too huge! Do ya wanna crush the server with those sizes, huh?", 400

        pickle.loads(pickled_data)
        return "Data saved successfully.", 200

    except Exception as e:
        return f"An error occurred: {str(e)}", 500


if __name__ == "__main__":
    app.run()
