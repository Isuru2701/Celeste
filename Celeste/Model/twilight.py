
# AI LIBRARIES
import spacy
import nltk

# API LIBRARIES
from flask import *
from distutils.log import debug
from typing_extensions import dataclass_transform


import json, time

app = Flask(__name__)

@app.route('/', methods=['GET'])
def home():
    data_set = {
                'Page': 'Home',
                'Message' : 'Home Loaded',
                'Timestamp' : time.time()
                }

    
    return json.dumps(data_set)

@app.route('/user/', methods=['GET'])
def user():
    
    user_query = str(request.args.get('user')) # user/?user=<text>

    data_set = {
                'Page': 'Request',
                'Message' : f'Successful query request = {user_query}',

                'Timestamp' : time.time()
                }

    
    return json.dumps(data_set)


if __name__ == '__main__':
    app.run(port=777, debug=True)
