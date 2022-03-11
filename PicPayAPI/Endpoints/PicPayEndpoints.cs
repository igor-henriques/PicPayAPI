namespace PicPayAPI.Endpoints;

public static class PicPayEndpoints
{
    public static void RegisterPicPayEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/payment", async (PaymentRequest request, IPicPayService service) =>
        {
            var paymentResponse = await service.CreatePaymentRequestAsync(request);

            if (paymentResponse == null) return Results.BadRequest("Ops! Algo deu errado.");

            return Results.Ok(paymentResponse);
        });

        app.MapGet("/api/v1/payment/status/{referenceId}", async (string referenceId, IPicPayService service) =>
        {
            var paymentResponse = await service.GetPaymentStatusAsync(referenceId);

            if (paymentResponse == null) return Results.BadRequest("Ops! Algo deu errado.");

            return Results.Ok(paymentResponse);
        });

        app.MapPost("api/v1/payment/callback", async (PaymentCallback callback, IPicPayService service) =>
        {
            if (callback == null | string.IsNullOrEmpty(callback.ReferenceId)) return Results.BadRequest();

            await service.ProcessCallbackAsync(callback);

            return Results.Ok();
        });

        app.MapPost("/api/v1/payment/cancel-purchase/{referenceId}/{authorizationId}", async (string referenceId, string authorizationId, IPicPayService service) =>
        {
            var response = await service.CancelPurchaseAsync(referenceId, authorizationId);

            if (response == null) return Results.BadRequest("Ops! Algo deu errado.");

            return Results.Ok(response);
        });

        app.MapPost("/api/v1/payment/cancel-pending/{referenceId}", async (string referenceId, IPicPayService service) =>
        {
            var response = await service.CancelPaymentAsync(referenceId);

            if (response == null) return Results.BadRequest("Ops! Algo deu errado.");

            return Results.Ok(response);
        });
    }
}