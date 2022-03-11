namespace MercadoPagoAPI.Endpoints;

public static class MercadoPagoEndpoints
{
    public static void RegisterMercadoPagoEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/payment-create-request", async (PaymentCreateRequest request, IMercadoPagoService service) =>
        {
            var paymentResponse = await service.CreatePaymentRequestAsync(request);

            if (paymentResponse == null) return Results.BadRequest("Ops! Algo deu errado.");

            return Results.Ok(paymentResponse);

        }).WithName("PaymentRequest");
    }
}