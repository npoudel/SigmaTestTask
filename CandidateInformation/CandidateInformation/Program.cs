using BLL.CandidateService;
using BLL;
using DAL;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using CandidateInformation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//codes to uncomment if using sql server
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDB"));
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
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
//add middleware
app.UseMiddleware<ErrorHandlingMiddleware>();
//remove this if you are using any persistent database
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

// Ensure the database schema is created
dbContext.Database.EnsureCreated();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
