using System.Net;
using System.Net.Http.Json;

using api.Models.Response;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Pathfinder.Tests.Controllers;

public class SpellControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public SpellControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task FindSpells_WithNoFilters_ReturnsSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(50)]
    public async Task FindSpells_WithLimit_RespectsLimit(int limit)
    {
        // Act
        var response = await _client.GetAsync($"/api/Spell?limit={limit}");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.True(spells.Count <= limit);
    }

    [Fact]
    public async Task FindSpells_WithInvalidLimit_ReturnsBadRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?limit=101");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task FindSpells_WithInvalidClass_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?className=InvalidClass");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task FindSpells_WithValidClass_ReturnsFilteredSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?className=Wizard");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
    }

    [Fact]
    public async Task FindSpells_WithSchool_ReturnsFilteredSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?school=Evocation");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.All(spells, s => Assert.Equal("Evocation", s.School));
    }

    [Fact]
    public async Task GetSpellsByClass_WithValidClass_ReturnsSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/Wizard");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.All(spells, s => Assert.True(s.ClassLevels.ContainsKey("Wizard")));
    }

    [Fact]
    public async Task GetSpellsByClass_WithInvalidClass_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/InvalidClass");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetSpellsByClass_WithLevel_ReturnsFilteredSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/Wizard?level=1");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.All(spells, s =>
        {
            Assert.True(s.ClassLevels.ContainsKey("Wizard"));
            Assert.Equal(1, s.ClassLevels["Wizard"]);
        });
    }

    [Fact]
    public async Task FindSpells_WithLevelOnly_ReturnsFilteredSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?level=0");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        // All returned spells should have at least one class with level 0
        Assert.All(spells, s => Assert.Contains(0, s.ClassLevels.Values));
    }

    [Fact]
    public async Task FindSpells_WithClassAndLevel_ReturnsFilteredSpells()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell?className=Wizard&level=1");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.All(spells, s =>
        {
            Assert.True(s.ClassLevels.ContainsKey("Wizard"));
            Assert.Equal(1, s.ClassLevels["Wizard"]);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task FindSpells_WithInvalidPage_ReturnsBadRequest(int page)
    {
        // Act
        var response = await _client.GetAsync($"/api/Spell?page={page}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(2, 5)]
    public async Task FindSpells_WithPagination_ReturnsPaginatedResults(int page, int limit)
    {
        // Act
        var response = await _client.GetAsync($"/api/Spell?page={page}&limit={limit}");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.True(spells.Count <= limit);
    }

    [Fact]
    public async Task GetSpellsByClass_WithPagination_ReturnsPaginatedResults()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/Wizard?page=1&limit=5");

        // Assert
        response.EnsureSuccessStatusCode();
        var spells = await response.Content.ReadFromJsonAsync<List<SpellResponse>>();
        Assert.NotNull(spells);
        Assert.True(spells.Count <= 5);
    }

    [Fact]
    public async Task GetSpellsByClass_WithInvalidLimit_ReturnsBadRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/Wizard?limit=101");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetSpellsByClass_WithInvalidPage_ReturnsBadRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/Spell/Class/Wizard?page=0");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
