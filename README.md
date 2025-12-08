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

## Environment Variables

To use GitHub Packages for private NuGet feeds, store credentials in environment variables.

1. A `.env.development` file is provided as an example:

```
# .env.development
GITHUB_USERNAME=your_github_username
GITHUB_PAT=your_personal_access_token_here
```

2. Copy it to `.env` and update your values:

```
cp .env.development .env
```

3. Load the environment variables in your shell:

**Linux / macOS / WSL:**

```
export $(grep -v '^#' .env | xargs)
```

**Windows PowerShell:**

```
Get-Content .env | ForEach-Object {
    if ($_ -match '^(.*?)=(.*)$') {
        Set-Item -Path Env:$($matches[1]) -Value $matches[2]
    }
}
```

> ⚠ Note: Environment variables are only available for the current terminal session. You need to reload them for each new session.

---

## NuGet Configuration

`nuget.config` is configured to use environment variables:

```
<packageSources>
  <add key="github" value="https://nuget.pkg.github.com/Sundy-Studios/index.json" />
  <add key="nuget" value="https://api.nuget.org/v3/index.json" />
</packageSources>

<packageSourceCredentials>
  <github>
    <add key="Username" value="%GITHUB_USERNAME%" />
    <add key="ClearTextPassword" value="%GITHUB_PAT%" />
  </github>
</packageSourceCredentials>
```

-   `Username` → your GitHub account username
-   `ClearTextPassword` → your PAT
-   Feed URL → your GitHub organization name

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
