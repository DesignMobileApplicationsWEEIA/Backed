docker build -f virtual-campus.dockerfile -t dominikus1910/virtual-campus:latest .
docker network create --driver bridge isolated_network
docker run -d --net=isolated_network --name postgres -e POSTGRES_PASSWORD=password postgres
docker run -d --net=isolated_network --name virtual-campus -p 80:5000 dominikus1910/virtual-campus:latest