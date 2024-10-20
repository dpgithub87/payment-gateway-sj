using PaymentGateway.CrossCutting.Models;

namespace PaymentGateway.Api.Models;

public class CreatePaymentResponse
{
    public string PaymentId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}