using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<BuilderDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Builder")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GeneRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

