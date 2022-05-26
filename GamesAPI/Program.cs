using GamesAPI;
using GamesAPI.Interfaces;
using GamesAPI.Middleware;
using GamesAPI.Repositories;
using GamesAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IDeveloperStudioService, DeveloperStudioService>();

builder.Services.AddDbContext<DbMainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainEntities"),
                    b => b.MigrationsAssembly("GamesAPI")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
