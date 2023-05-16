# Webitor backend with .net 6


## Docker 

- Run
```
docker run --rm -p 5000:5000 -p 5001:5001  webitor/azure ENV ASPNETCORE_URLS=http://+:80
```

- Build
```
docker build --rm -t webitor/azure:latest .
```
