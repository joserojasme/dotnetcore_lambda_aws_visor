# Vysorshop Backend

//crear proyecto
dotnet new serverless.AspNetCoreWebAPI --name client.vysorShop.microServices


agregar nuget mysqlframework


dotnet ef dbcontext scaffold "Server=dondiegodb.ch5z6v0zxug7.us-east-2.rds.amazonaws.com;database=dondiegoDB;user=admin;password=admin2019.;" MySql.Data.EntityFrameworkCore -o Models

dotnet ef dbcontext scaffold "Server=dondiegodb.ch5z6v0zxug7.us-east-2.rds.amazonaws.com;database=donDiegoDBDev;user=adminDev;password=admin2019.Dev;" MySql.Data.EntityFrameworkCore -o Models



//actualizar entity
dotnet ef dbcontext scaffold "Server=dondiegodb.ch5z6v0zxug7.us-east-2.rds.amazonaws.com;database=donDiegoDBDev;user=adminDev;password=admin2019.Dev;" MySql.Data.EntityFrameworkCore -o Models -f