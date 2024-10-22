using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(Program).Assembly));
#pragma warning restore CS0618 // Type or member is obsolete
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();