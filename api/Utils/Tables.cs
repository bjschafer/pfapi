namespace api.Utils;

public static class Tables
{
    public static readonly Dictionary<int, int[]> BonusSpellsByAbilityMod = new Dictionary<int, int[]>
    {
        {
            0, new[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
            }
        },
        {
            1, new[]
            {
                1, 0, 0, 0, 0, 0, 0, 0, 0,
            }
        },
        {
            2, new[]
            {
                1, 1, 0, 0, 0, 0, 0, 0, 0,
            }
        },
        {
            3, new[]
            {
                1, 1, 1, 0, 0, 0, 0, 0, 0,
            }
        },
        {
            4, new[]
            {
                1, 1, 1, 1, 0, 0, 0, 0, 0,
            }
        },
        {
            5, new[]
            {
                2, 1, 1, 1, 1, 0, 0, 0, 0,
            }
        },
        {
            6, new[]
            {
                2, 2, 1, 1, 1, 1, 0, 0, 0,
            }
        },
        {
            7, new[]
            {
                2, 2, 2, 1, 1, 1, 1, 0, 0,
            }
        },
        {
            8, new[]
            {
                2, 2, 2, 2, 1, 1, 1, 1, 0,
            }
        },
        {
            9, new[]
            {
                3, 2, 2, 2, 2, 1, 1, 1, 1,
            }
        },
        {
            10, new[]
            {
                3, 3, 2, 2, 2, 2, 1, 1, 1,
            }
        },
        {
            11, new[]
            {
                3, 3, 3, 2, 2, 2, 2, 1, 1,
            }
        },
        {
            12, new[]
            {
                3, 3, 3, 3, 2, 2, 2, 2, 1,
            }
        },
        {
            13, new[]
            {
                4, 3, 3, 3, 3, 2, 2, 2, 2,
            }
        },
        {
            14, new[]
            {
                4, 4, 3, 3, 3, 3, 2, 2, 2,
            }
        },
        {
            15, new[]
            {
                4, 4, 4, 3, 3, 3, 3, 2, 2,
            }
        },
        {
            16, new[]
            {
                4, 4, 4, 4, 3, 3, 3, 3, 2,
            }
        },
        {
            17, new[]
            {
                5, 4, 4, 4, 4, 3, 3, 3, 3,
            }
        },
    };

    public static int GetAbilityModifier(int score)
    {
        return (score - 10) / 2;
    }
    public static int GetBonusSpells(int level, int abilityScore)
    {
        int mod = GetAbilityModifier(abilityScore);
        return BonusSpellsByAbilityMod[mod][level - 1];
    }
}
