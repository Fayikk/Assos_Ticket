using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Helper;
using Assos_Ticket.Server.Helper.MailService;
using Assos_Ticket.Server.PaymentSystem;
using Assos_Ticket.Server.Services.ForAuth;
using Assos_Ticket.Server.Services.ForBus;
using Assos_Ticket.Server.Services.ForCarImage;
using Assos_Ticket.Server.Services.ForDiscount;
using Assos_Ticket.Server.Services.ForExpedition;
using Assos_Ticket.Server.Services.ForOrderBus;
using Assos_Ticket.Server.Services.ForPlane;
using Assos_Ticket.Server.Services.ForPlaneReserve;
using Assos_Ticket.Server.Services.ForVipCar;
using Assos_Ticket.Server.Services.ForVipCarRezerve;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBlazor", Version = "v1" });
});
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IExpeditionService,ExpeditionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IVipCarService, VipCarService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICarImageService, CarImageService>();
builder.Services.AddScoped<IOrderBusService,OrderBusService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IPlaneService,PlaneService>();
builder.Services.AddScoped<IPlaneReserveService, PlaneReserveService>();
builder.Services.AddScoped<IVipCarRezerveService, VipCarRezerveService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:SecretKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddSwaggerGen(c => {

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBlazor v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
//    RequestPath = "/images"
//});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
