var builder = WebApplication.CreateBuilder(args);

var MyAllowAllOrigins = "_myAllowAllOrigins";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/bookings"));


app.MapControllers();

app.Run();
