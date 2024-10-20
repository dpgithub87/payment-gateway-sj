using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Infrastructure.Entities;

namespace PaymentGateway.Infrastructure.PaymentRepository;

public class PaymentRepository: IPaymentRepository
{
    private readonly PaymentDbContext _paymentDbContext;

    public PaymentRepository(PaymentDbContext paymentDbContext)
    {
        _paymentDbContext = paymentDbContext;
    }

    public async Task<Payment?> GetPayment(string paymentId)
    {
        return await _paymentDbContext.Payments.FirstOrDefaultAsync(p => p.PaymentId == paymentId);
    }
    
    public async Task SavePayment(Payment paymentCommand)
    {
        _paymentDbContext.Payments.Add(paymentCommand);
        await _paymentDbContext.SaveChangesAsync();
    }
    
}