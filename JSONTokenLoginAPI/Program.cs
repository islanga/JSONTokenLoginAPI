using JSONTokenLoginAPI.Helper;
using JSONTokenLoginAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

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

// set global cors policy
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Custom jwt auth middleware to authenticate the token
app.UseMiddleware<JwtMiddleware>();
//app.UseEndpoints(endpoints => {
//    endpoints.MapControllers();
//});

app.Run();
