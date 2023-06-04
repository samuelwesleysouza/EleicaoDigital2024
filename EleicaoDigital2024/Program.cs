using EleicaoDigital.Application;
using EleicaoDigital.Repository;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services
    .AddInfrastructure(configuration)
    .AddApplication();

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

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.MapControllers();


app.UseSwagger();

// Ativa o Swagger UI
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
    opt.RoutePrefix = string.Empty;
});

app.Run();
