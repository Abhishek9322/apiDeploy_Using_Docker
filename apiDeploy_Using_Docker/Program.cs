using apiDeploy_Using_Docker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//// Configure Kestrel to listen on port 5000
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5000); // Listen on all interfaces
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//app.Urls.Add("http://0.0.0.0:5000");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Api Is running ");

app.Run();
