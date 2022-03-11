namespace MercadoPagoAPI.Interfaces;

public interface IMercadoPagoService
{
    Task<Payment> CreatePaymentRequestAsync(PaymentCreateRequest request);
}