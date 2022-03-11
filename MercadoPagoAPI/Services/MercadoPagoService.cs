namespace MercadoPagoAPI.Services;

public class MercadoPagoService : IMercadoPagoService
{
    private readonly PaymentClient client;
    private readonly RequestOptions options;

    public MercadoPagoService(IOptions<MercadoPagoSecrets> secrets)
    {
        this.client = new PaymentClient();
        this.options = new RequestOptions() { AccessToken = secrets.Value.PrivateKey };        
    }

    public async Task<Payment> CreatePaymentRequestAsync(PaymentCreateRequest request)
    {
        return await client.CreateAsync(request, options);
    }
}