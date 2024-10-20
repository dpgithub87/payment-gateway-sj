using PaymentGateway.Infrastructure.Entities;

namespace PaymentGateway.Infrastructure.PaymentRepository;

public interface IPaymentRepository
{
    Task<Payment?> GetPayment(string paymentId);
    
    Task SavePayment(Payment payment);
}