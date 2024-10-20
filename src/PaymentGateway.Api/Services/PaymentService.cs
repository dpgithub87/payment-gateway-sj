using PaymentGateway.Api.Models;
using PaymentGateway.CrossCutting.Models;
using PaymentGateway.Infrastructure.Entities;
using PaymentGateway.Infrastructure.PaymentRepository;
using PaymentGateway.WebClients;
using PaymentGateway.WebClients.AcquiringBank;

namespace PaymentGateway.Api.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IAcquiringBankClient _bankSimulatorClient;

    public PaymentService(IPaymentRepository paymentRepository, IAcquiringBankClient bankSimulatorClient)
    {
        _paymentRepository = paymentRepository;
        _bankSimulatorClient = bankSimulatorClient;
    }
    
    public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest)
    {
        var paymentId = Guid.NewGuid().ToString();

        var paymentEntity = new Payment()
        {
            PaymentId = paymentId,
            PaymentStatus = PaymentStatus.Initiated,
            CardNumber = createPaymentRequest.CardNumber,
            Amount = createPaymentRequest.Amount,
            ExpiryMonth = createPaymentRequest.ExpiryMonth,
            ExpiryYear = createPaymentRequest.ExpiryYear
        };

        await _paymentRepository.SavePayment(paymentEntity);

        var createBankPaymentRequest = new CreateBankPaymentRequest()
        {
            CardNumber = createPaymentRequest.CardNumber,
            Amount = createPaymentRequest.Amount,
            ExpiryDate = createPaymentRequest.ExpiryMonth + "/" + createPaymentRequest.ExpiryYear,
            Currency = createPaymentRequest.Currency,
            Cvv = createPaymentRequest.Cvv
        };

        try
        {
            var createBankPaymentResponse = await _bankSimulatorClient.CreatePayment(createBankPaymentRequest);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return new CreatePaymentResponse()
        {
            PaymentId = paymentId,
            PaymentStatus = PaymentStatus.Authorized
        };
    }
}