namespace PaymentGateway.Api.Models;

public class CreatePaymentRequest
{
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string Currency { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Cvv { get; set; }
}