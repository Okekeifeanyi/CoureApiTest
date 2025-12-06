using CoureBeTest.Data;
using CoureBeTest.Data.DataBases;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(); // Your DB + DI registration

var app = builder.Build();

// THIS IS THE CORRECT WAY FOR IN-MEMORY DATABASE
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CourDb>();

    // This applies your HasData() seeding immediately
    dbContext.Database.EnsureCreated();
}

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();