# DDD users microservice made using C# and .NET Core

## Run:

```
docker-compose up -d
```

## Execute tests:

```
docker-compose exec web dotnet test
```

## Inspect endpoints:

Import the Postman collection stored within the [postman folder](postman) to the Postman app.

# TODO

* Add Unit tests to commands and queries in Application layer.
* Add Integration testing
* Add events queue
* Add error logs
* Move connection string to an environment dependant file
* Add migrations to create tables