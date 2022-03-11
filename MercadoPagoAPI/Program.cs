var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MercadoPagoSecrets>(builder.Configuration.GetSection("Secrets:MercadoPago"));
builder.Services.AddScoped<IMercadoPagoService, MercadoPagoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterMercadoPagoEndpoints();

app.Run();