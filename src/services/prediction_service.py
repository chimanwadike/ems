from flask import jsonify
from src.constants.http_status_codes import *
from joblib import load
import os, sys
import numpy as np


def predict_hiv(data):

    wdir = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'ml_models'))
    rf = load(f"{wdir}/rf.joblib")
    int_features = [int(v) for x, v in data.items()]
    prediction = rf.predict([int_features])
    result = 'Undecided'

    if prediction[0] == 2:
        result = 'Not at risk'
    elif prediction[0] == 1:
        result = 'High risk'

    return jsonify({'status': result}), HTTP_200_OK
