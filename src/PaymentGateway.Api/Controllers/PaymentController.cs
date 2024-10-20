using FluentValidation;

using Microsoft.AspNetCore.Mvc;

using PaymentGateway.Api.Models;

namespace PaymentGateway.Api.Controllers;

[Route("v1/payments")]
[ApiController]
public class PaymentController: ControllerBase
{
    private readonly IValidator<CreatePaymentRequest> _createPaymentRequestValidator;

    public PaymentController(IValidator<CreatePaymentRequest> createPaymentRequestValidator)
    {
        _createPaymentRequestValidator = createPaymentRequestValidator;
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePayment(CreatePaymentRequest createPaymentRequest)
    {
        var validatedResponse = await _createPaymentRequestValidator.ValidateAsync(createPaymentRequest);
        
        if (!validatedResponse.IsValid)
        {
            return BadRequest(validatedResponse);
        }
        
        return await Task.FromResult(Ok(new CreatePaymentResponse()));
    }
}