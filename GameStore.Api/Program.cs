using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;

// Creating a new instance of the WebApplication builder and passing in any command line arguments
var builder = WebApplication.CreateBuilder(args); // Creates a new instance of the WebApplication builder and passes in any command line arguments

builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>(); // Registers the InMemGamesRepository as a singleton service in the dependency injection container

// Building the application using the builder
var app = builder.Build(); // Builds the application using the builder

// Mapping the GamesEndpoints to the application
app.MapGamesEndpoints(); // Maps the GamesEndpoints to the application

// Running the application
app.Run(); // Runs the application