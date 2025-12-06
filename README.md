# SS-TemplateMongo

[![codecov](https://codecov.io/github/Sundy-Studios/SS-TemplateMongo/graph/badge.svg?token=SZFLWQM7WU)](https://codecov.io/github/Sundy-Studios/SS-TemplateMongo)

A lightweight REST API starter built with an N Tier architecture. Includes MongoDB integration, a NuGet client project and a unit test project, providing a clean foundation for modular backend development.

## Table of Contents

-   [Setup](#setup)
-   [Run the API](#run-the-api)

---

## Setup

Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

Clone the repo and navigate to the solution:

```bash
git clone https://github.com/Sundy0828/SS-TemplateMongo.git
cd SS-TemplateMongo
```

Restore packages:

```bash
dotnet restore
```

---

## Run the API

Navigate to the API project:

```bash
cd TemplateMongo
dotnet run
```

By default, the API will run at:

-   `http://localhost:5070`

Swagger UI is available at `http://localhost:5070/swagger` for exploring the endpoints.
