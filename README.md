# Localization-Sample
Building a Localization Sample with ASP.NET Core 1.1 and EF Core 1.1

<strong>Using Visual Studio 2015 Update 3 in Windows</strong>
<ol>
<li>Install .NET Core SDK for Visual Studio (https://www.microsoft.com/net/core#windows)</li>
<li>Create a database in SQL Server</li>
<li>Update the connection string in appsettings.json</li>
<li>Open Package Manager Console Window and type "dotnet ef migrations add InitialCreate" for creating Migrations and then type "Update-Database". This action will create database schema</li>
<li>Run sqlserver_static.sql script to create sample data</li>
<li>Press Control + F5</li>
</ol>
<strong>Running the App with Docker Compose</strong>
<ol>
<li>Install Docker for Mac or Docker for Windows (or Docker Toolbox: http://docker.com/toolbox if you have to)</li>
<li>Run <code>docker-compose up --build</code></li>
<li>Navigate to http://localhost:5000 (http://192.168.99.100:5000 if using Docker Toolbox) in your browser to view the site.</li>
</ol>
