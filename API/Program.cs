using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//do not care about the order of the services that we add here 
builder.Services.AddDbContext<DataContext>(opt=>{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//the services above are scoped to http requests, so when we receive http request we might need to access the db. 
//when the http request is finished it will dispose the datacontext
var app = builder.Build();

// Configure the HTTP request pipeline. //MiddleWare: to do some operations on https requests through pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope(); //using is used here because after the work of scope is done; the memory is cleared 
var services = scope.ServiceProvider;

try
{    
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();//creates db if not exists // similar to database update through CLI
    await Seed.SeedData(context);//seed the DB asynchronously //upon completion of this async task,
    // we will receive notification from delegate
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migraton");
}


app.Run();
