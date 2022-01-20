namespace api.Models;

/// <summary>
/// A spell has zero or more descriptors that may lead to special effects.
/// </summary>
[Flags]
public enum Descriptors
{
    Acid,
    Air,
    Chaotic,
    Cold,
    Curse,
    Darkness,
    Death,
    Disease,
    Draconic,
    Earth,
    Electricity,
    Emotion,
    Evil,
    Fear,
    Fire,
    Force,
    Good,
    LanguageDependent,
    Lawful,
    Light,
    Meditative,
    MindAffecting,
    Pain,
    Poison,
    Ruse,
    Shadow,
    Sonic,
    Water,
}
