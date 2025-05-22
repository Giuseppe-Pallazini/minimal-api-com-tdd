using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;
using Moq;

namespace Api.Tests.Fixtures;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Mock do IAdministradorServico
            var mockAdminService = new Mock<IAdministradorServico>();
            mockAdminService
                .Setup(s => s.Login(It.IsAny<LoginDTO>()))
                .Returns(new Administrador { Email = "admin@teste.com", Perfil = "Adm" });

            services.AddScoped(_ => mockAdminService.Object);
        });
    }
}