using FitnessJournal.Application.Repository;
using FitnessJournal.Application.Services;
using FitnessJournal.Infrastructure.Data;
using FitnessJournal.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", "https://localhost:7067")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


// Add services to the container.
builder.Services.AddDbContext<FitnessJournalContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddApplicationServices();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(FitnessRepository<>));
builder.Services.AddScoped(typeof(ILoginRepository), typeof(LoginRepository));
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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
