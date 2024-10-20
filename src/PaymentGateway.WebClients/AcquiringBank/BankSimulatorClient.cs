using System.Net;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using PaymentGateway.CrossCutting;
using PaymentGateway.WebClients.AcquiringBank;

namespace PaymentGateway.WebClients.AcquiringBank;

public class BankSimulatorClient: IAcquiringBankClient
{
    private readonly HttpClient _httpClient;

    public BankSimulatorClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreateBankPaymentResponse?> CreatePayment(CreateBankPaymentRequest createBankPaymentRequest)
    {
        var content = JsonSerializer.Serialize(createBankPaymentRequest);

        var response = await
            _httpClient.PostAsync("/payments", new StringContent(content, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw response.StatusCode switch
            {
                HttpStatusCode.BadRequest => new BankSimulatorException(new ProblemDetails()
                {
                    Detail = "Its a bad request", Title = "Bad Request", Status = (int)HttpStatusCode.BadRequest
                }),
                _ => new BankSimulatorException(new ProblemDetails()
                {
                    Detail = "Something went wrong",
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.InternalServerError
                })
            };
        }

        return JsonSerializer.Deserialize<CreateBankPaymentResponse>(await response.Content.ReadAsStringAsync());
    }
    

}