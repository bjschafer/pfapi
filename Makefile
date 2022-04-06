PROJECT := ./api/api.csproj

.PHONY:
	dotnet build --project $(PROJECT)

help:
	@echo "This Makefile supports the following commands:"
	@echo "    clean        - clean build objects"
	@echo "    docker-build - build and tag the docker image"
	@echo "    docker-run   - build, tag, and run the docker image binding to :8080"
	@echo "    migratedb    - specify mig_name=foo, adds and runs migrations"
	@echo "    run          - runs a local environment"

docker-build:
	docker build -f api/Dockerfile api -t pfapi:latest

docker-run: docker-build
	docker run -it --rm -d -p 8080:80 pfapi:latest

migratedb:
ifdef mig_name
	dotnet ef migrations add $(mig_name) --project $(PROJECT)
	dotnet ef database update --project $(PROJECT)
else
	@echo specify a migration name with make migratedb mig_name=foo
endif

run:
	dotnet run --project $(PROJECT)

clean:
	rm -r ./api/bin/* ./api/obj/*
	rm -r './Data Helper/bin/'* './Data Helper/obj/'*
