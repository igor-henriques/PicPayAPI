namespace PicPayAPI.Services;

public class PicPayService : IPicPayService
{
    private readonly PicPayClient client;
    private readonly ILogger<PicPayService> logger;

    public PicPayService(IOptions<PicPaySecrets> secrets, HttpClient client, ILogger<PicPayService> logger)
    {
        this.client = new PicPayClient(secrets.Value.Token, client);
        this.logger = logger;
    }

    public async Task<PaymentResponse> CreatePaymentRequestAsync(PaymentRequest request)
    {
        return await client.Payment.GeneratePaymentAsync(request);
    }

    public async Task<PaymentStatus> GetPaymentStatusAsync(string referenceId)
    {
        return await client.Notification.GetPaymentStatusAsync(referenceId);
    }

    public async Task ProcessCallbackAsync(PaymentCallback callback)
    {
        logger.LogInformation("Callback processed");
    }

    public async Task<PaymentCancellationResponse> CancelPaymentAsync(string referenceId)
    {
        return await client.Payment.CancelPaymentAsync(referenceId);
    }
    public async Task<PaymentCancellationResponse> CancelPurchaseAsync(string referenceId, string authorizationId)
    {
        return await client.Payment.CancelPurchaseAsync(referenceId, authorizationId);
    }
}