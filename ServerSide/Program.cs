using Microsoft.EntityFrameworkCore;
using ServerSide.Data;
using ServerSide.Repository;
using ServerSide.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<BuilderDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Builder")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GeneRepository<>));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PriceRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<StoreService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

