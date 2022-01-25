namespace api.Models;

public class SpellDescriptor : ISeedable
{
    public int        Id         { get; set;}
    public Spell      Spell      { get; set; }
    public Descriptor Descriptor { get; set; }
    
}
