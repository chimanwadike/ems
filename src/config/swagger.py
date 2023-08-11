template = {
    "swagger": "2.0",
    "info": {
        "title": "Epidemic Management System (EMS) API",
        "description": "EMS API with current focus on predicting HIV risk",
        "contact": {
            "responsibleOrganization": "",
            "responsibleDeveloper": "",
            "email": "deve@gmail.com",
            "url": "www.github.com/chimanwadike",
        },
        "termsOfService": "www.github.com/chimanwadike",
        "version": "1.0"
    },
    "basePath": "/api/v1",  # base bash for blueprint registration
    "schemes": [
        "http",
        "https"
    ],
    "securityDefinitions": {
        "Bearer": {
            "type": "apiKey",
            "name": "Authorization",
            "in": "header",
            "description": "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
        }
    },
}

swagger_config = {
    "headers": [
    ],
    "specs": [
        {
            "endpoint": 'apispec',
            "route": '/apispec.json',
            "rule_filter": lambda rule: True,  # all in
            "model_filter": lambda tag: True,  # all in
        }
    ],
    "static_url_path": "/flasgger_static",
    "swagger_ui": True,
    "specs_route": "/"
}
