using Xunit;
using ClienteApi.Controllers;
using ClienteApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ClienteControllerTests
{
    private ClienteContext GetContextWithData()
    {
        var options = new DbContextOptionsBuilder<ClienteContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var context = new ClienteContext(options);
        context.Clientes.Add(new Cliente { CPF = "12345678901", Email = "teste@teste.com", Nome = "Teste" });
        context.SaveChanges();

        return context;
    }

    [Fact]
    public void GetClientes_ReturnsAllClientes()
    {
        var context = GetContextWithData();
        var controller = new ClienteController(context);

        var result = controller.GetClientes();

        Assert.Equal(1, result.Value.Count());
    }

    // Adicione mais testes conforme necessário
}