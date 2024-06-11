using Microsoft.Extensions.Logging;
using StoneEmployee.API.Configuration;
using StoneEmployee.API.Filters;
using StoneEmployee.API.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddLogging();
builder.Services.AddServicesConfiguration();
builder.Services.AddRepositoryConfiguration();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new HttpResponseExceptionFilter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(EmployeeMapper));

var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    logger.LogInformation("Handling request: {Path}", context.Request.Path);
//    await next.Invoke();
//    logger.LogInformation("Finished handling request.");
//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
