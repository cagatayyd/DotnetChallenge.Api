using DotnetChallenge.Persistence;
using DotnetChallenge.Persistence.Contexts;
using DotnetChallenge.Persistence.Mapping;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddDbContext<DotnetChallengeDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddHangfire(config =>
{
	config.UseSqlServerStorage(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddHangfireServer();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingBuilder));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
	var recurringJobManager = scope.ServiceProvider.GetService<IRecurringJobManager>();
	var serviceProvider = scope.ServiceProvider;
	HangfireJobs.ConfigureHangfireJobs(recurringJobManager, serviceProvider);
}

app.UseHangfireDashboard("/hangfire");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
