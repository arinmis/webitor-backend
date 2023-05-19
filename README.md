# Webitor backend with .net 6


## Docker 

- Run For Development
```
docker run --rm  -p  8080:80  -e ASPNETCORE_ENVIRONMENT=Development webitor
```

- Run For Production
```
docker run --rm  -p  8080:80
```

- Build
```
sudo docker build -f Dockerfile -t webitor .
```


### Example Request: Singup
```
curl -X 'POST' \
  'http://localhost:8080/api/account/signup' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "foo",
  "lastName": "bar",
  "email": "foo@example.com",
  "userName": "foobar",
  "password": "Foo$ar1",
  "confirmPassword": "Foo$ar1"
}'
```



curl -X 'POST' \
  'https://webitor1.azurewebsites.net:8080/api/account/signup' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "foo",
  "lastName": "bar",
  "email": "foo@example.com",
  "userName": "foobar",
  "password": "Foo$ar1",
  "confirmPassword": "Foo$ar1"
}'
