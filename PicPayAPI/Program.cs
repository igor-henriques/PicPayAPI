var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PicPaySecrets>(builder.Configuration.GetSection("Secrets:PicPay"));
builder.Services.AddHttpClient<PicPayService>();
builder.Services.AddScoped<IPicPayService, PicPayService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.RegisterPicPayEndpoints();

app.Run();