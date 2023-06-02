// Importing the necessary namespaces for the code to work properly
using GameStore.Api.Entities;
using GameStore.Api.Endpoints;

// Creating a new instance of the WebApplication builder and passing in any command line arguments
var builder = WebApplication.CreateBuilder(args);

// Building the application using the builder
var app = builder.Build();

// Mapping the GamesEndpoints to the application
app.MapGamesEndpoints();

// Running the application
app.Run();