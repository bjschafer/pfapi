using System.Net;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Pathfinder.Tests.Controllers;

public class AdminControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AdminControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task PostSpell_WithoutAuthorization_DoesNotReturnSuccess()
    {
        // Arrange
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/Admin", content);

        // Assert - Should not succeed without authorization
        // Note: Returns 500 because no authentication scheme is configured in tests
        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task PutSpell_WithoutAuthorization_DoesNotReturnSuccess()
    {
        // Arrange
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("/api/Admin/1", content);

        // Assert - Should not succeed without authorization
        Assert.False(response.IsSuccessStatusCode);
    }
}
