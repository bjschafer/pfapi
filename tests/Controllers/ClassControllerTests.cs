using System.Net;
using System.Net.Http.Json;

using api.Models.Response;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Pathfinder.Tests.Controllers;

public class ClassControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ClassControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task GetClasses_ReturnsSuccessAndClasses()
    {
        // Act
        var response = await _client.GetAsync("/api/Class");

        // Assert
        response.EnsureSuccessStatusCode();
        var classes = await response.Content.ReadFromJsonAsync<List<ClassResponse>>();
        Assert.NotNull(classes);
        Assert.NotEmpty(classes);
    }

    [Theory]
    [InlineData("Wizard")]
    [InlineData("wizard")]
    [InlineData("WIZARD")]
    public async Task GetClass_WithValidName_ReturnsClass(string className)
    {
        // Act
        var response = await _client.GetAsync($"/api/Class/{className}");

        // Assert
        response.EnsureSuccessStatusCode();
        var classResponse = await response.Content.ReadFromJsonAsync<ClassResponse>();
        Assert.NotNull(classResponse);
        Assert.Equal("Wizard", classResponse.Name);
    }

    [Fact]
    public async Task GetClass_WithInvalidName_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/Class/InvalidClass");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetSpellsPerDay_WithValidParameters_ReturnsCount()
    {
        // Arrange - Wizard at level 5 can cast level 2 spells
        // Act
        var response = await _client.GetAsync("/api/Class/Wizard/SpellsPerDay?classLevel=5&spellLevel=2&abilityScore=16");

        // Assert
        response.EnsureSuccessStatusCode();
        var count = await response.Content.ReadFromJsonAsync<int>();
        Assert.True(count >= 0);
    }

    [Fact]
    public async Task GetSpellsPerDay_WithInvalidClass_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/Class/InvalidClass/SpellsPerDay?classLevel=1&spellLevel=0&abilityScore=10");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetHighestSpellLevel_WithValidParameters_ReturnsLevel()
    {
        // Act
        var response = await _client.GetAsync("/api/Class/Wizard/HighestSpellLevel?classLevel=5");

        // Assert
        response.EnsureSuccessStatusCode();
        var level = await response.Content.ReadFromJsonAsync<int?>();
        Assert.NotNull(level);
        Assert.True(level >= 0 && level <= 9);
    }

    [Fact]
    public async Task GetHighestSpellLevel_WithInvalidClass_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/Class/InvalidClass/HighestSpellLevel?classLevel=1");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
