using UltimateParcelQuoter.DTOs.DHLService;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.DTOs.UPSService;
using UltimateParcelQuoter.Interfaces;
using UltimateParcelQuoter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParcelQuoter, ParcelQuoter>();
builder.Services.AddScoped(typeof(IPostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO>), typeof(DHLService));
builder.Services.AddScoped(typeof(IPostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO>), typeof(FedExService));
builder.Services.AddScoped(typeof(IPostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO>), typeof(UPSService));

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

app.Run();

