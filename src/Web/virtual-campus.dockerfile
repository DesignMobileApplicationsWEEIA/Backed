FROM microsoft/dotnet:latest

COPY . /var/www/virtual-campus

WORKDIR /var/www/virtual-campus

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5000/tcp

CMD ["dotnet", "run", "--server.urls", "http://*:5000"]
