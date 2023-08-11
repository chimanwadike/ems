from flasgger import swag_from
from flask import Blueprint, request
from src.services.prediction_service import predict_hiv

hiv = Blueprint("hiv", __name__, url_prefix="/api/v1/hiv")


@hiv.post('/risk/predict')
@swag_from('../docs/hiv_predict.yaml')
def predict():
    return predict_hiv(request.get_json())
