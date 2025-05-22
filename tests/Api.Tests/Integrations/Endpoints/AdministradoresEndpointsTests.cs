using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Tests;

public class AdministradoresEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient httpClient;

    public AdministradoresEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        HttpClient _httpClient = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_Administradores_DeveRetornarOk()
    {
        // Arrange
        var url = "/administradores";

        // Act
        var response = await httpClient.GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_Login_DeveRetornarToken()
    {
        // Arrange
        var loginDTO = new { Email = "admin@teste.com", Senha = "senha123" };

        // Act
        var response = await httpClient.PostAsJsonAsync("/administradores/login", loginDTO);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("token", content.ToLower());
    }
}