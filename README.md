# webapi-net5
## Entity Framework Core (Code First)
 ```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
```
Migrations: \
– CLI Add / Remove a Migration
```
dotnet ef migrations add “{name}”
dotnet ef migrations remove
dotnet ef database update
```
– Package Manager Console
```
Add-Migration {name}
Remove-Migration
Update-Database
```