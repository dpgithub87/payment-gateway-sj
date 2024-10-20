namespace PaymentGateway.CrossCutting.Models;

public enum PaymentStatus
{
    Initiated,
    Authorized,
    Declined,
    Rejected
}