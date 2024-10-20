namespace PaymentGateway.WebClients.AcquiringBank;

public interface IAcquiringBankClient
{
    Task<CreateBankPaymentResponse?> CreatePayment(
        CreateBankPaymentRequest createPaymentRequestDomainModel);

}