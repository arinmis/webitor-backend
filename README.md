# Webitor backend with .net 6


## Migrations 

To add new migration, run those commands at the root of the repository 
```
dotnet ef migrations add <migration-name> --startup-project WebApi --project Infrastructure --context ApplicationDbContext -o WebApi/Migrations/

```

Apply migrations
```
dotnet ef   database update --project Infrastructure --startup-project WebApi --context ApplicationDbContext
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
