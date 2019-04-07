Run:

```bash
docker run -v ${PWD}:/app --workdir /app microsoft/aspnetcore-build:lts dotnet new mvc --auth Individual
```

Docker file:

```bash
FROM microsoft/aspnetcore-build:lts
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
```

Then create `entrypoint.sh`:

```sh
#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:80"

until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
```

Create a `docker-compose.yml` file:

```yaml
version: "3"
services:
    web:
        build: .
        ports:
            - "8000:80"
        depends_on:
            - db
    db:
        image: "mcr.microsoft.com/mssql/server"
        environment:
            SA_PASSWORD: "Your_password123"
            ACCEPT_EULA: "Y"
```

Update `appsettings.json` with this connection string:

```
Server=db;Database=master;User=sa;Password=Your_password123;
```

Add `UseSqlServer` to `Startup.cs`:

```cs
 services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(connection));
```

Add `SqlServer` package to project file:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="1.1.2" />
```

