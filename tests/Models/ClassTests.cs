using api.Models.Database;

namespace Pathfinder.Tests.Models;

public class ClassTests
{
    [Fact]
    public void MaxSpellLevel_WithNullCharacterLevel_ReturnsNull()
    {
        // Arrange
        var @class = new Class
        {
            Name = "Wizard",
            SpellsPerDay = new Dictionary<int, IDictionary<int, int>>
            {
                { 1, new Dictionary<int, int> { { 0, 3 }, { 1, 1 } } }
            }
        };

        // Act
        var result = @class.MaxSpellLevel(null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MaxSpellLevel_WithNullSpellsPerDay_ReturnsNull()
    {
        // Arrange
        var @class = new Class
        {
            Name = "Fighter",
            SpellsPerDay = null
        };

        // Act
        var result = @class.MaxSpellLevel(5);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MaxSpellLevel_WithInvalidLevel_ReturnsNull()
    {
        // Arrange
        var @class = new Class
        {
            Name = "Wizard",
            SpellsPerDay = new Dictionary<int, IDictionary<int, int>>
            {
                { 1, new Dictionary<int, int> { { 0, 3 }, { 1, 1 } } }
            }
        };

        // Act
        var result = @class.MaxSpellLevel(99); // Level not in dictionary

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void MaxSpellLevel_WithValidLevel_ReturnsHighestSpellLevel()
    {
        // Arrange
        var @class = new Class
        {
            Name = "Wizard",
            SpellsPerDay = new Dictionary<int, IDictionary<int, int>>
            {
                { 5, new Dictionary<int, int> { { 0, 4 }, { 1, 3 }, { 2, 2 }, { 3, 1 } } }
            }
        };

        // Act
        var result = @class.MaxSpellLevel(5);

        // Assert
        Assert.Equal(3, result);
    }
}
