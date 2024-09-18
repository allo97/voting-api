using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VoterContext>(opt => opt.UseInMemoryDatabase("VoterList"));
builder.Services.AddDbContext<CandidateContext>(opt => opt.UseInMemoryDatabase("CandidateList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "VotingAPI";
    config.Title = "VotingAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "VotingAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

VoterRouteMapper.Map(app);
CandidateRouteMapper.Map(app);

app.Run();