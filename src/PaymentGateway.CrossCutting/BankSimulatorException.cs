using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.CrossCutting;

public class BankSimulatorException: ProblemDetailsException
{
    public BankSimulatorException(ProblemDetails problemDetails) : base(problemDetails)
    {
        
    }
}