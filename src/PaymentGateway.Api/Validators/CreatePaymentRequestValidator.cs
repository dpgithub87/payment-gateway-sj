using FluentValidation;

using PaymentGateway.Api.Models;

namespace PaymentGateway.Api.Validators;

public class CreatePaymentRequestValidator: AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentRequestValidator()
    {
        RuleFor(x => x.CardNumber)
            .NotNull()
            .Length(14, 19);
    }
}