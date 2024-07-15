using System.Reflection;
using Server.Data;
using Server.Interfaces;
using Server.Repositories;
using Server.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalHost",
		policy =>
		{
			policy.WithOrigins("https://localhost:7109", "http://localhost:5196").AllowAnyMethod().AllowAnyHeader();
		});
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IRequestAccessRepository, RequestAccessRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalHost");

app.MapEndpoints(Assembly.GetExecutingAssembly());

app.Run();