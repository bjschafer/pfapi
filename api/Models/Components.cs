namespace api.Models;

/// <summary>
/// The component(s) that a spell may require to be cast
/// </summary>
[Flags]
public enum Components
{
    DivineFocus,
    Focus,
    Material,
    Somatic,
    Verbal,
}
