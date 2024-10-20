using PaymentGateway.CrossCutting.Models;

namespace PaymentGateway.WebClients;

public class CreateBankPaymentResponse
{
    public string PaymentId { get; set; } = string.Empty;
    public PaymentStatus PaymentStatus { get; set; }
}