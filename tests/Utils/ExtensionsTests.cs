using api.Utils;

namespace Pathfinder.Tests.Utils;

public class ExtensionsTests
{
    [Theory]
    [InlineData("wizard", "Wizard")]
    [InlineData("WIZARD", "Wizard")]
    [InlineData("WiZaRd", "Wizard")]
    [InlineData("fire ball", "Fire Ball")]
    [InlineData("MAGIC MISSILE", "Magic Missile")]
    [InlineData("evocation", "Evocation")]
    public void ToTitleCase_ConvertsCorrectly(string input, string expected)
    {
        // Act
        var result = input.ToTitleCase();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTitleCase_WithEmptyString_ReturnsEmpty()
    {
        // Act
        var result = "".ToTitleCase();

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void ToTitleCase_WithSingleCharacter_ReturnsTitleCase()
    {
        // Act
        var result = "a".ToTitleCase();

        // Assert
        Assert.Equal("A", result);
    }

    [Fact]
    public void WhereIf_WhenConditionTrue_AppliesFilter()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();

        // Act
        var result = items.WhereIf(true, x => x > 3).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(4, result);
        Assert.Contains(5, result);
    }

    [Fact]
    public void WhereIf_WhenConditionFalse_DoesNotApplyFilter()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();

        // Act
        var result = items.WhereIf(false, x => x > 3).ToList();

        // Assert
        Assert.Equal(5, result.Count);
    }

    [Fact]
    public void WhereIf_CanBeChained()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();

        // Act
        var result = items
            .WhereIf(true, x => x > 1)
            .WhereIf(true, x => x < 5)
            .ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.DoesNotContain(1, result);
        Assert.DoesNotContain(5, result);
    }

    [Fact]
    public void WhereIfs_WhenConditionExpressionTrue_AppliesFilter()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();
        var shouldFilter = true;

        // Act
        var result = items.WhereIfs(() => shouldFilter, x => x > 3).ToList();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void WhereIfs_WhenConditionExpressionFalse_DoesNotApplyFilter()
    {
        // Arrange
        var items = new[] { 1, 2, 3, 4, 5 }.AsQueryable();
        var shouldFilter = false;

        // Act
        var result = items.WhereIfs(() => shouldFilter, x => x > 3).ToList();

        // Assert
        Assert.Equal(5, result.Count);
    }
}
