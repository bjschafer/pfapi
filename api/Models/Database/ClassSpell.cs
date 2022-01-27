namespace api.Models.Database;

public class ClassSpell
{
    public int   ClassId { get; set; }
    public Class Class   { get; set; }
    
    public int   SpellId { get; set; }
    public Spell Spell   { get; set; }
    
    public int Level { get; set; }
}
