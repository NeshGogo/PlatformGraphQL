using Microsoft.EntityFrameworkCore;
using PlatformGQL.Data;
using PlatformGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using PlatformGQL.GraphQL.Platforms;
using PlatformGQL.GraphQL.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Only accept one query.
// builder.Services.AddDbContext<AppDbContext>(opt => 
//     opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutations>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();
app.UseGraphQLVoyager("/graphQL-voyager");
app.Run("http://localhost:5000");
