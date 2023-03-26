using Assos_Ticket.Client;
using Assos_Ticket.Client.Pages.Payment;
using Assos_Ticket.Client.Services.ForAuthServices;
using Assos_Ticket.Client.Services.ForBusService;
using Assos_Ticket.Client.Services.ForCarService;
using Assos_Ticket.Client.Services.ForPlaneService;
using Assos_Ticket.Client.Services.ForVipCarService;
using Assos_Ticket.Client.Services.Rezervation.VipCars;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ICarImageService, CarImageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IVipCarService, VipCarService>();
builder.Services.AddScoped<IPlaneService, PlaneService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVipCarRezervation, VipCarRezervation>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
