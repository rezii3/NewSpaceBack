using NewSpace.Data;
using NewSpace.Model;
using NewSpace.Service.Abstraction;
using NewSpace.Service.Implementation;
using static Azure.Core.HttpHeader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContxt>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<Icoctaile,IcoctaileService>();
builder.Services.AddScoped<Ifood, IfoodService>();
builder.Services.AddScoped<Itea_coffe, Itea_coffeService>();
builder.Services.AddScoped<Iwine, IwineService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
