using PaymentGateway.Api.Models;

namespace PaymentGateway.Api.Services;

public interface IPaymentService
{
    Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest);
}