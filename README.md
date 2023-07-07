# .NET + Appwrite Todo API

## Description

Todo CRUD API built with Appwrite Cloud and .NET 7

## Installation

### Appwrite Setup

- Sign up for [Appwrite Cloud](https://cloud.appwrite.io)
- Create your first project
  ![Create a project](https://github.com/adityaoberai/.NET-Appwrite-Todo-API/assets/31401437/0ecf6268-9df4-4ae5-b92b-156e24890963)
- Create an API Key with the scopes `documents.read` and `documents.write`
  ![API Key scopes](https://github.com/adityaoberai/.NET-Appwrite-Todo-API/assets/31401437/6f4caff6-930a-4cd9-91be-cccfc45c041f)
- Create a database, followed by a collection, and create the following:
  - Attributes
    | Attribute ID | Type    | Size | Default Value | Required | Array |
    |--------------|---------|------|---------------|----------|-------|
    | description  | string  | 255  |               | Yes      | No    |
    | isCompleted  | boolean |      |               | Yes      | No    |

    ![Collection attributes](https://github.com/adityaoberai/.NET-Appwrite-Todo-API/assets/31401437/c31deb0f-bb36-4996-8d35-ae2c2cdf786c)
      
  - Index
    | Index Key | Index type  | Attribute | Order |
    |-----------|-------------|-----------|-------|
    | Id        | Key         | $id       | ASC   |
    
    ![Collection indexes](https://github.com/adityaoberai/.NET-Appwrite-Todo-API/assets/31401437/a36538d8-d784-44ff-a4b3-6637649918e6)
- Keep your Project Id, Database Id, Collection Id, and API Key saved for the project setup

### Project Setup

- Install the [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download) if you haven't already
- Clone the repository
  ```sh
  https://github.com/adityaoberai/.NET-Appwrite-Todo-API.git
  ```
- Restore all NuGet packages
  ```sh
  dotnet restore
  ```
- Enter the project directory
  ```sh
  cd AppwriteCrudApi/
  ```
- Add the Project Id, Database Id, Collection Id, and API Key you saved from your Appwrite project in the `appsettings.json` file
- Run the project
  ```sh
  dotnet run
  ```
- Open the following URL in your browser
  ```
  https://localhost:7248/swagger
  ```
  
  OR

  ```
  http://localhost:5023/swagger
  ```
