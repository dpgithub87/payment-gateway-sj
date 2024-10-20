using PaymentGateway.CrossCutting;
using PaymentGateway.CrossCutting.Models;

namespace PaymentGateway.Infrastructure.Entities;

public class Payment
{
    public string PaymentId { get; set; } = string.Empty;
    public PaymentStatus PaymentStatus { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string Currency { get; set; } = string.Empty;
    public int Amount { get; set; }
}