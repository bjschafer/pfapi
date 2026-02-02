using api.Utils;

namespace Pathfinder.Tests.Utils;

public class TablesTests
{
    [Theory]
    [InlineData(10, 0)]  // Base ability score
    [InlineData(11, 0)]
    [InlineData(12, 1)]
    [InlineData(13, 1)]
    [InlineData(14, 2)]
    [InlineData(15, 2)]
    [InlineData(16, 3)]
    [InlineData(17, 3)]
    [InlineData(18, 4)]
    [InlineData(20, 5)]
    [InlineData(8, -1)]
    [InlineData(6, -2)]
    [InlineData(1, -4)]
    public void GetAbilityModifier_ReturnsCorrectModifier(int score, int expectedModifier)
    {
        // Act
        var result = Tables.GetAbilityModifier(score);

        // Assert
        Assert.Equal(expectedModifier, result);
    }

    [Theory]
    [InlineData(1, 12, 1)]  // Level 1 spell, 12 ability (+1 mod) = 1 bonus
    [InlineData(1, 14, 1)]  // Level 1 spell, 14 ability (+2 mod) = 1 bonus
    [InlineData(2, 14, 1)]  // Level 2 spell, 14 ability (+2 mod) = 1 bonus
    [InlineData(1, 16, 1)]  // Level 1 spell, 16 ability (+3 mod) = 1 bonus
    [InlineData(3, 16, 1)]  // Level 3 spell, 16 ability (+3 mod) = 1 bonus
    [InlineData(1, 18, 1)]  // Level 1 spell, 18 ability (+4 mod) = 1 bonus
    [InlineData(1, 20, 2)]  // Level 1 spell, 20 ability (+5 mod) = 2 bonus
    public void GetBonusSpells_ReturnsCorrectBonus(int spellLevel, int abilityScore, int expectedBonus)
    {
        // Act
        var result = Tables.GetBonusSpells(spellLevel, abilityScore);

        // Assert
        Assert.Equal(expectedBonus, result);
    }

    [Fact]
    public void GetBonusSpells_WithZeroModifier_ReturnsZero()
    {
        // Arrange - ability score 10 gives +0 modifier
        var abilityScore = 10;

        // Act & Assert
        for (int spellLevel = 1; spellLevel <= 9; spellLevel++)
        {
            var result = Tables.GetBonusSpells(spellLevel, abilityScore);
            Assert.Equal(0, result);
        }
    }

    [Fact]
    public void BonusSpellsByAbilityMod_HasExpectedEntries()
    {
        // Assert - verify the table has entries for modifiers 0-17
        Assert.True(Tables.BonusSpellsByAbilityMod.ContainsKey(0));
        Assert.True(Tables.BonusSpellsByAbilityMod.ContainsKey(17));
        
        // Each entry should have 9 values (spell levels 1-9)
        foreach (var entry in Tables.BonusSpellsByAbilityMod)
        {
            Assert.Equal(9, entry.Value.Length);
        }
    }
}
