from datetime import timedelta

from flask import Flask, jsonify
import os

from src.blueprints.hiv import hiv

from src.constants.http_status_codes import HTTP_500_INTERNAL_SERVER_ERROR

from flasgger import Swagger, swag_from
from src.config.swagger import template, swagger_config


def create_app(test_config=None):
    app = Flask(__name__,
                instance_relative_config=True)

    if test_config is None:
        app.config.from_mapping(
            SWAGGER={'title': 'Epidemic Management System (EMS) API',
                     'uiversion': 3}

        )
    else:
        app.config.from_mapping(test_config)

    app.register_blueprint(hiv)

    Swagger(app, config=swagger_config, template=template)

    @app.errorhandler(HTTP_500_INTERNAL_SERVER_ERROR)
    def handle_500(ex):
        return jsonify({'message': 'something went wrong and we are working on it'}), HTTP_500_INTERNAL_SERVER_ERROR

    return app
