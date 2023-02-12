
# AI LIBRARIES
import spacy
import nltk

# API LIBRARIES
from flask import *
from distutils.log import debug
from typing_extensions import dataclass_transform



import pyodbc
import json, time


# database conn
cn = pyodbc.connect('DRIVER={Devart ODBC Driver for SQL Server};Server=ISURU;Database=isuru.Lunar.dbo;User Trusted_Connection=yes')
cursor = cn.cursor()



app = Flask(__name__)

@app.route('/', methods=['GET'])
def home():
    data_set = {
                'Page': 'Home',
                'Message' : 'Home Loaded',
                'Timestamp' : time.time()
                }

    
    return json.dumps(data_set)

@app.route('/analyze/', methods=['GET'])
def user():
    
    user_query = str(request.args.get('user_id')) # analyze/?user_id=<text>

    data_set = {
                'Page': 'Request',
                'Message' : f'Successful query request = {user_query}',

                'Timestamp' : time.time()
                }

    
    return json.dumps(data_set)


if __name__ == '__main__':
    app.run(port=777, debug=True)
