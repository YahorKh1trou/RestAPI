using Data.Extensions;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddData(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddAuth();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
