using MarsRover.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
configDependencies(builder.Services);

//jquery cors config
var MyAllowSpecificOrigins = "jqueryApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5500") //port assigned by live server
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();

// Configure the dependency injection container
void configDependencies(IServiceCollection services)
{
    services.AddTransient<ISurface, Surface>();
    services.AddTransient<IRover, Rover>();
    services.AddTransient<ICommandCenter, CommandCenter>();
    services.AddTransient<IPosition, Position>();
}