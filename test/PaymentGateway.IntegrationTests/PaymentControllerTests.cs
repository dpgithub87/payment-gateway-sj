using System.Net;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc.Testing;

using PaymentGateway.Api.Models;

namespace PaymentGateway.IntegrationTests;

public class PaymentControllerTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public PaymentControllerTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact]
    public async Task Should_Return_Ok_When_Valid_Input_Given()
    {
        //Arrange
        var httpClient = _webApplicationFactory.CreateClient();
        var createPaymentRequest = new CreatePaymentRequest()
        {
            CardNumber = "1234123412341234",
            Amount = 100,
            ExpiryMonth = 12,
            ExpiryYear = 2025,
            Currency = "GBP",
            Cvv = 123
        };

        var content = JsonSerializer.Serialize(createPaymentRequest);

        //Act
        var response =
            await httpClient.PutAsync("v1/payments", new StringContent(content, Encoding.UTF8, "application/json"));
        
        //Assert
        response.EnsureSuccessStatusCode();
    }
    
    [Theory]
    [InlineData("0123401234012340123401234")]
    [InlineData("1234")]
    public async Task Should_Return_BadRequest_Error_When_InValid_Input_Given(string cardNumber)
    {
        //Arrange
        var httpClient = _webApplicationFactory.CreateClient();
        var createPaymentRequest = new CreatePaymentRequest()
        {
            CardNumber = cardNumber,
            Amount = 100,
            ExpiryMonth = 12,
            ExpiryYear = 2025,
            Currency = "GBP",
            Cvv = 123
        };

        var content = JsonSerializer.Serialize(createPaymentRequest);

        //Act
        var response =
            await httpClient.PutAsync("v1/payments", new StringContent(content, Encoding.UTF8, "application/json"));
        
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}