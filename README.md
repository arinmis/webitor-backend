# Webitor backend with .net 6


## Docker 

- Run For Development
```
docker run --rm  -p  5000:80  -e ASPNETCORE_ENVIRONMENT=Development webitor
```

- Run For Production
```
docker run --rm  -p  5000:80
```

- Build
```
sudo docker build -f Dockerfile -t webitor .
```
