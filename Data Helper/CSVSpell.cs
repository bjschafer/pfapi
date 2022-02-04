using CsvHelper.Configuration.Attributes;

namespace Data_Helper;

public class CsvSpell
{
    public string  Name                 { get; set; } // Acid Arrow
    public string  School               { get; set; } // conjuration
    public string? Subschool            { get; set; } // creation
    public string? Descriptor           { get; set; } // acid
    public string  SpellLevel           { get; set; } // sorcerer/wizard 2, magus 2, bloodrager 2
    public string  CastingTime          { get; set; } // 1 standard action
    public string  Components           { get; set; } // V, S, M (rhubarb leaf and an adder's stomach), F (a dart)
    public bool    CostlyComponents     { get; set; } // 0
    public string  Range                { get; set; } // long (400 ft. + 40 ft./level)
    public string  Area                 { get; set; } // 30 ft cone
    public string  Effect               { get; set; } // one arrow of acid
    public string  Targets              { get; set; } // 1 + 1 per level
    public string  Duration             { get; set; } // 1 round + 1 round per three levels
    public bool    Dismissible          { get; set; } // 0
    public bool    Shapeable            { get; set; } // 0
    public string  SavingThrow          { get; set; } // none
    public string  SpellResistance      { get; set; } // yes (harmless)
    public string  Description          { get; set; } // An arrow of acid...
    public string  DescriptionFormatted { get; set; } // <p>An arrow of acid...
    public string  Source               { get; set; } // PFRPG Core
    public string  FullText             { get; set; } // <link rel="stylesheet"href="PF.CSS"><div class...
    public bool    Verbal               { get; set; } // 1
    public bool    Somatic              { get; set; } // 1
    public bool    Material             { get; set; } // 1
    public bool    Focus                { get; set; } // 1
    public bool    DivineFocus          { get; set; } // 0
    public int?    Sor                  { get; set; } // 2
    public int?    Wiz                  { get; set; } // 2
    public int?    Cleric               { get; set; } // NULL
    public int?    Druid                { get; set; } // NULL
    public int?    Ranger               { get; set; } // NULL
    public int?    Bard                 { get; set; } // NULL
    public int?    Paladin              { get; set; } // NULL
    public int?    Alchemist            { get; set; } // NULL
    public int?    Summoner             { get; set; } // NULL
    public int?    Witch                { get; set; } // NULL
    public int?    Inquisitor           { get; set; } // NULL
    public int?    Oracle               { get; set; } // NULL
    public int?    Antipaladin          { get; set; } // NULL
    public int?    Magus                { get; set; } // NULL
    public int?    Adept                { get; set; } // NULL
    public string? Deity                { get; set; } // NULL
    [Name("SLA_Level")]
    public int?    SLALevel             { get; set; } // 2
    public string? Domain               { get; set; } // Fire (2), Scalykind (3)
    public string  ShortDescription     { get; set; } // Ranged touch attack
    public bool    Acid                 { get; set; } // 0
    public bool    Air                  { get; set; } // 0
    public bool    Chaotic              { get; set; } // 0
    public bool    Cold                 { get; set; } // 0
    public bool    Curse                { get; set; } // 0
    public bool    Darkness             { get; set; } // 0
    public bool    Death                { get; set; } // 0
    public bool    Disease              { get; set; } // 0
    public bool    Earth                { get; set; } // 0
    public bool    Electricity          { get; set; } // 0
    public bool    Emotion              { get; set; } // 0
    public bool    Evil                 { get; set; } // 0
    public bool    Fear                 { get; set; } // 0
    public bool    Fire                 { get; set; } // 0
    public bool    Force                { get; set; } // 0
    public bool    Good                 { get; set; } // 0
    public bool    Language_dependent   { get; set; } // 0
    public bool    Lawful               { get; set; } // 0
    public bool    Light                { get; set; } // 0
    public bool    Mind_affecting       { get; set; } // 0
    public bool    Pain                 { get; set; } // 0
    public bool    Poison               { get; set; } // 0
    public bool    Shadow               { get; set; } // 0
    public bool    Sonic                { get; set; } // 0
    public bool    Water                { get; set; } // 0
    public string? Linktext             { get; set; } // https://...
    public int     Id                   { get; set; } // 42
    public int?    MaterialCosts        { get; set; } // 1500
    public string  Bloodline            { get; set; } // Undead (9)
    public string  Patron               { get; set; } // Plague (8)
    public string  MythicText           { get; set; } // Add your tier...
    public string  Augmented            { get; set; } // Augmented (6th) spend...
    public bool    Mythic               { get; set; } // 0
    public int?    Bloodrager           { get; set; } // 2
    public int?    Shaman               { get; set; } // 2
    public int?    Psychic              { get; set; } // 2
    public int?    Medium               { get; set; } // 2
    public int?    Mesmerist            { get; set; } // 2
    public int?    Occultist            { get; set; } // 2
    public int?    Spiritualist         { get; set; } // 2
    public int?    Skald                { get; set; } // 2
    public int?    Investigator         { get; set; } // 2
    public int?    Hunter               { get; set; } // 2
    public string  HauntStatistics      { get; set; } // ???
    public bool    Ruse                 { get; set; } // 0
    public bool    Draconic             { get; set; } // 0
    public bool    Meditative           { get; set; } // 0
    public int?    SummonerUnchained    { get; set; } // 2


    // 	haunt_statistics	ruse	draconic	meditative	summoner_unchained
    //1,1,1,1,0,2,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,2,NULL,,2,,Ranged touch attack; 2d4 damage for 1 round + 1 round/three levels.,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,Acid Arrow,NULL,,,,,0,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,,0,0,0,NULL
}
