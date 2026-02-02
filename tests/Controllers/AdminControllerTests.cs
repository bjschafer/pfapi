using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using api.Models.Request;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Pathfinder.Tests.Controllers;

public class AdminControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly HttpClient _authenticatedClient;

    public AdminControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        _authenticatedClient = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _authenticatedClient.DefaultRequestHeaders.Add("X-Test-Auth", "true");
    }

    [Fact]
    public async Task PostSpell_WithoutAuthorization_ReturnsUnauthorized()
    {
        // Arrange
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/Admin", content);

        // Assert - Should return 401 Unauthorized
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task PutSpell_WithoutAuthorization_ReturnsUnauthorized()
    {
        // Arrange
        var content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync("/api/Admin/1", content);

        // Assert - Should return 401 Unauthorized
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task PostSpell_WithAuthorization_AndValidSpell_ReturnsCreated()
    {
        // Arrange
        var spellRequest = new SpellRequest
        {
            Name = "Test Spell",
            Description = "A test spell for unit testing",
            Summary = "Test summary",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "instantaneous",
            ClassLevels = new Dictionary<string, int> { { "Wizard", 1 } },
            Source = "Test Source"
        };

        // Act
        var response = await _authenticatedClient.PostAsJsonAsync("/api/Admin", spellRequest);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task PostSpell_WithAuthorization_AndInvalidClass_ReturnsBadRequest()
    {
        // Arrange
        var spellRequest = new SpellRequest
        {
            Name = "Invalid Class Spell",
            Description = "A spell with invalid class",
            Summary = "Test summary",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "instantaneous",
            ClassLevels = new Dictionary<string, int> { { "InvalidClassName", 1 } },
            Source = "Test Source"
        };

        // Act
        var response = await _authenticatedClient.PostAsJsonAsync("/api/Admin", spellRequest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Invalid class names", content);
    }

    [Fact]
    public async Task PostSpell_WithAuthorization_AndDescriptors_ReturnsCreated()
    {
        // Arrange
        var spellRequest = new SpellRequest
        {
            Name = "Spell With Descriptors",
            Description = "A spell with descriptors",
            Summary = "Fire damage",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "instantaneous",
            ClassLevels = new Dictionary<string, int> { { "Wizard", 3 } },
            Source = "Test Source",
            Descriptors = new List<string> { "Fire" }
        };

        // Act
        var response = await _authenticatedClient.PostAsJsonAsync("/api/Admin", spellRequest);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task PutSpell_WithAuthorization_AndNonExistentId_ReturnsNotFound()
    {
        // Arrange
        var spellRequest = new SpellRequest
        {
            Name = "Updated Spell",
            Description = "Updated description",
            Summary = "Updated summary",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "1 round",
            ClassLevels = new Dictionary<string, int> { { "Wizard", 1 } },
            Source = "Test Source"
        };

        // Act
        var response = await _authenticatedClient.PutAsJsonAsync("/api/Admin/99999", spellRequest);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PostSpell_WithAuthorization_AndMultipleClasses_ReturnsCreated()
    {
        // Arrange
        var spellRequest = new SpellRequest
        {
            Name = "Multi Class Spell",
            Description = "A spell available to multiple classes",
            Summary = "Multi-class test",
            School = "Conjuration",
            CastingTime = "1 standard action",
            Duration = "1 hour/level",
            ClassLevels = new Dictionary<string, int>
            {
                { "Wizard", 2 },
                { "Cleric", 2 },
                { "Druid", 3 }
            },
            Source = "Test Source"
        };

        // Act
        var response = await _authenticatedClient.PostAsJsonAsync("/api/Admin", spellRequest);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
