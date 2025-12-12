# SS-TemplateMongo

[![codecov](https://codecov.io/github/Sundy-Studios/SS-TemplateMongo/graph/badge.svg?token=SZFLWQM7WU)](https://codecov.io/github/Sundy-Studios/SS-TemplateMongo)

A lightweight REST API starter built with an N-Tier architecture. Includes MongoDB integration, a NuGet client project, and a unit test project, providing a clean foundation for modular backend development.

---

## Table of Contents

-   [Setup](#setup)
-   [Environment Variables](#environment-variables)
-   [NuGet Configuration](#nuget-configuration)
-   [API Configuration](#api-configuration)
-   [Run the API](#run-the-api)

---

## Setup

Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

Clone the repo and navigate to the solution:

```
git clone https://github.com/Sundy0828/SS-TemplateMongo.git
cd SS-TemplateMongo
```

Restore packages:

```
dotnet restore
```

---

## Setting Up Access to the Private NuGet Feed

To restore packages from the private GitHub Packages feed, each developer needs to create a Personal Access Token and add the GitHub NuGet source to their local machine.

### 1. Create a Personal Access Token (PAT)

1. Open GitHub settings  
   https://github.com/settings/tokens?type=beta
2. Choose **Fine-grained personal access token**.
3. Select the organization: **Sundy-Studios**.
4. Under **Permissions**, enable:
    - **Packages** [Read]
5. Set an expiration date and generate the token.
6. Copy the token and store it securely. GitHub will not show it again.

### 2. Add the GitHub Package Source Locally

Run the following command in **PowerShell**. This stores your credentials in your user-level NuGet configuration so all solutions on your machine can restore packages without placing secrets in the repository.

```powershell
dotnet nuget add source "https://nuget.pkg.github.com/Sundy-Studios/index.json" `
  --name github `
  --username <your-github-username> `
  --password <your-pat-token> `
  --store-password-in-clear-text `
  --configfile "$env:APPDATA\NuGet\NuGet.Config"
```

After running the command:

-   The file %APPDATA%\NuGet\NuGet.Config will be created if it does not exist.
-   The GitHub NuGet source and credentials will be stored on your machine.
-   dotnet restore will work normally for this project.

---

## API Configuration

Inside the `TemplateMongo` folder, include these configuration files:

### `appsettings.json`

```
{
  "MongoDb": {
    "ConnectionString": "mongodb+srv://xxx:xxx@xxx.mongodb.net/",
    "DatabaseName": "TemplateMongoDb"
  },
  "Firebase": {
      "ProjectId": "xxx"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### `appsettings.Development.json`

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> Replace sensitive information (`xxx`) with your credentials.

---

## Run the API

Navigate to the API project:

```
cd TemplateMongo
dotnet run
```

By default, the API will run at:

-   `http://localhost:5070`

Swagger UI is available at `http://localhost:5070/swagger` for exploring the endpoints.

---

## Notes

-   Only changes affecting `Common/` or `Directory.Packages.props` / `Directory.Build.props` should trigger NuGet builds.
-   Main/master branch builds produce a package with `BASE_VERSION`.
-   Feature branches produce `BASE_VERSION-branchname.INC` for prerelease packages.
