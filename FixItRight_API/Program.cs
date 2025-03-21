using Azure.Identity;
using FixItRight_API;
using FixItRight_API.Extension;
using FixItRight_Service.ChatServices;
using FixItRight_Service.EmailServices;
using FixItRight_Service.Extensions;
using FixItRight_Service.TransactionServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(option =>
{
	option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
	{
		Description =
			"JWT Authorization header using the Bearer scheme. \r\n\r\n" +
			"Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
			"Example: \"Bearer 12345abcdef\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = JwtBearerDefaults.AuthenticationScheme,
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
	});
	option.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme()
			{
				Reference = new OpenApiReference()
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme = "oath2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
});

//Azure Key Vault
//var keyVaultUrl = new Uri(builder.Configuration.GetSection("KeyVaultUrl").Value!);
//var azureCredential = new DefaultAzureCredential();
//builder.Configuration.AddAzureKeyVault(keyVaultUrl, azureCredential);

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.ConfigureQuartz();
builder.Services.AddProblemDetails();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureBlobService(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<Utils>();
builder.Services.AddSignalR().AddAzureSignalR(builder.Configuration.GetConnectionString("SignalR"));
builder.Host.UseSerilog((hostContext, configuration) =>
{
	configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseExceptionHandler(opt => { });

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<MessageHub>("/message");

app.Run();
