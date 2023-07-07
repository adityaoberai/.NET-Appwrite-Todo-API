using Appwrite;
using Appwrite.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Appwrite - Todo CRUD API

var projectId = builder.Configuration["Appwrite:Project_Id"];
var apiKey = builder.Configuration["Appwrite:Api_Key"];
var databaseId = builder.Configuration["Appwrite:Database_Id"];
var collectionId = builder.Configuration["Appwrite:Collection_Id"];

var client = new Client()
    .SetEndpoint("https://cloud.appwrite.io/v1")
    .SetProject(projectId)
    .SetKey(apiKey);

var databases = new Databases(client);

app.MapGet("/todos", async () =>
{
    try
    {
        var todos = await databases.ListDocuments(
            databaseId: databaseId,
            collectionId: collectionId);

        return Results.Ok(todos);
    }
    catch (AppwriteException e)
    {
        return Results.NotFound(new Dictionary<string, string> { { "message", e.Message } });
    }
})
.WithName("GetAllTodos")
.WithOpenApi();

app.MapGet("/todos/{id}", async (string id) =>
{
    try
    {
        var todo = await databases.GetDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id);

        return Results.Ok(todo);
    }
    catch(AppwriteException e)
    {
        return Results.NotFound(new Dictionary<string,string> { { "message", e.Message } });
    }
})
.WithName("GetTodo")
.WithOpenApi();

app.MapPost("/todos", async (Todo todo) =>
{
    try
    {
        var document = await databases.CreateDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: ID.Unique(),
            data: todo);

        return Results.Created($"/todos/{document.Id}", document);
    }
    catch (AppwriteException e)
    {
        return Results.BadRequest(new Dictionary<string, string> { { "message", e.Message } });
    }
})
.WithName("CreateTodo")
.WithOpenApi();

app.MapPut("/todos/{id}", async (string id, Todo todo) =>
{
    try
    {
        var document = await databases.UpdateDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id,
            data: todo);

        return Results.NoContent();
    }
    catch (AppwriteException e)
    {
        return Results.BadRequest(new Dictionary<string, string> { { "message", e.Message } });
    }
})
.WithName("UpdateTodo")
.WithOpenApi();

app.MapDelete("/todos/{id}", async (string id) =>
{
    try
    {
        var document = await databases.DeleteDocument(
            databaseId: databaseId,
            collectionId: collectionId,
            documentId: id);

        return Results.Ok(document);
    }
    catch (AppwriteException e)
    {
        return Results.NotFound(new Dictionary<string, string> { { "message", e.Message } });
    }
})
.WithName("DeleteTodo")
.WithOpenApi();

app.Run();

public class Todo
{
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("isCompleted")]
    public bool IsCompleted { get; set; }
}
