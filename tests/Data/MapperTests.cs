using api.Data;
using api.Models.Database;
using api.Models.Request;
using api.Models.Response;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

namespace Pathfinder.Tests.Data;

public class MapperTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly IMapper _mapper;

    public MapperTests(CustomWebApplicationFactory<Program> factory)
    {
        var scope = factory.Services.CreateScope();
        _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    }

    [Fact]
    public void Spell_ToSpellResponse_MapsCorrectly()
    {
        // Arrange
        var spell = new Spell
        {
            Id = 1,
            Name = "Fireball",
            Description = "A ball of fire",
            Summary = "Fire damage",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "instantaneous",
            ClassLevels =
            [
                new() { ClassName = "Wizard", Level = 3 },
                new() { ClassName = "Sorcerer", Level = 3 }
            ],
            Source = new SourceMaterial { Id = 1, Name = "Core Rulebook" }
        };

        // Act
        var response = _mapper.Map<SpellResponse>(spell);

        // Assert
        Assert.Equal("Fireball", response.Name);
        Assert.Equal("A ball of fire", response.Description);
        Assert.Equal("Evocation", response.School);
        Assert.Equal(2, response.ClassLevels.Count);
        Assert.Equal(3, response.ClassLevels["Wizard"]);
        Assert.Equal("Core Rulebook", response.Source.Name);
    }

    [Fact]
    public void SpellRequest_ToSpell_MapsCorrectly()
    {
        // Arrange
        var request = new SpellRequest
        {
            Name = "Magic Missile",
            Description = "Missiles of magical energy",
            Summary = "Force damage",
            School = "Evocation",
            CastingTime = "1 standard action",
            Duration = "instantaneous",
            ClassLevels = new Dictionary<string, int>
            {
                { "Wizard", 1 },
                { "Sorcerer", 1 }
            },
            Source = "Core Rulebook"
        };

        // Act
        var spell = _mapper.Map<Spell>(request);

        // Assert
        Assert.Equal("Magic Missile", spell.Name);
        Assert.Equal("Evocation", spell.School);
        Assert.Equal(2, spell.ClassLevels.Count);
    }

    [Fact]
    public void Class_ToClassResponse_MapsCorrectly()
    {
        // Arrange
        var @class = new Class
        {
            Id = 1,
            Name = "Wizard",
            SpellsPerDay = new Dictionary<int, IDictionary<int, int>>
            {
                { 1, new Dictionary<int, int> { { 0, 3 }, { 1, 1 } } }
            }
        };

        // Act
        var response = _mapper.Map<ClassResponse>(@class);

        // Assert
        Assert.Equal("Wizard", response.Name);
        Assert.NotNull(response.SpellsPerDay);
        Assert.Equal(3, response.SpellsPerDay[1][0]);
    }

    [Fact]
    public void ClassLevel_MapsWithTitleCase()
    {
        // Arrange
        var kvp = new KeyValuePair<string, int>("wizard", 3);

        // Act
        var classLevel = _mapper.Map<ClassLevel>(kvp);

        // Assert
        Assert.Equal("Wizard", classLevel.ClassName);
        Assert.Equal(3, classLevel.Level);
    }
}
