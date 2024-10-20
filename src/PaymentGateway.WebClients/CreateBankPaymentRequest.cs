namespace PaymentGateway.WebClients;

public class CreateBankPaymentRequest
{
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string Currency { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Cvv { get; set; }
}