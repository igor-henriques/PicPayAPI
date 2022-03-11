namespace PicPayAPI.Interfaces;

public interface IPicPayService
{
    Task<PaymentResponse> CreatePaymentRequestAsync(PaymentRequest request);
    Task<PaymentStatus> GetPaymentStatusAsync(string referenceId);
    Task ProcessCallbackAsync(PaymentCallback callback);
    Task<PaymentCancellationResponse> CancelPaymentAsync(string referenceId);
    Task<PaymentCancellationResponse> CancelPurchaseAsync(string referenceId, string authorizationId);
}