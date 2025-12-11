from fastapi import FastAPI
from fastapi.responses import JSONResponse
from fastapi.encoders import jsonable_encoder
from fastapi.responses import FileResponse

app = FastAPI()

@app.get("/") #http://127.0.0.1:8000
def root():
    return FileResponse("public/index.html")

@app.get("/hello") #http://127.0.0.1:8000/hello
def hello():
    data = {"message": "Hello world!"}
    json_data = jsonable_encoder(data)
    return JSONResponse(content=json_data)

@app.get("/about") #http://127.0.0.1:8000/about
def about():
    return {"message": "О сайте"}

@app.get("/users/{id}") #http://127.0.0.1:8000/users/123
def users(id):
    return {"user_id": id}

@app.get("/users") #http://127.0.0.1:8000/users?name=Tom&age=38
def get_user(name, age):
    return {"user_name": name, "user_age": age}

@app.get("/notfound", status_code=404) #http://127.0.0.1:8000/notfound
def notfound():
    return  {"message": "Resource Not Found"}