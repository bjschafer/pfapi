using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

// ReSharper disable InconsistentNaming

namespace api.Models.Database;

[Index(nameof(Name), IsUnique = true)]
public class Monster
{
    public int    Id   { get; set; }
    public string Name { get; set; }

    [Range(0.125, 99)]
    public decimal CR { get;                  set; }
    public int            XP           { get; set; }
    public string?        Race         { get; set; }
    public Class?         Class        { get; set; }
    public SourceMaterial Source       { get; set; }
    public string?        Alignment    { get; set; }
    public string?        CreatureSize { get; set; }
    public string?        CreatureType { get; set; }
    public string?        Subtype      { get; set; }
    public string?        Init         { get; set; }
    public string?        Senses       { get; set; }
    public string?        Aura         { get; set; }

    public int AC           { get; set; }
    public int TouchAC      { get; set; }
    public int FlatFootedAC { get; set; }

    public string?        ACMods                { get; set; }
    public int            HP                    { get; set; }
    public string?        HD                    { get; set; }
    public string?        HPMods                { get; set; }
    public string?        Saves                 { get; set; }
    public string?        Fortitude             { get; set; }
    public string?        Reflex                { get; set; }
    public string?        Will                  { get; set; }
    public string?        SaveMods              { get; set; }
    public string?        DefensiveAbilities    { get; set; }
    public string?        DR                    { get; set; }
    public string?        Immune                { get; set; }
    public string?        Resist                { get; set; }
    public string?        SR                    { get; set; }
    public string?        Weaknesses            { get; set; }
    public string?        Speed                 { get; set; }
    public string?        SpeedMod              { get; set; }
    public string?        Melee                 { get; set; }
    public string?        Ranged                { get; set; }
    public string?        Space                 { get; set; }
    public string?        Reach                 { get; set; }
    public string?        SpecialAttacks        { get; set; }
    public string?        SpellLikeAbilities    { get; set; }
    public string?        SpellsKnown           { get; set; }
    public string?        SpellsPrepared        { get; set; }
    public string?        SpellDomains          { get; set; }
    public string?        AbilityScores         { get; set; }
    public string?        AbilityScoreMods      { get; set; }
    public int            BaseAtk               { get; set; }
    public string?        CMB                   { get; set; }
    public string?        CMD                   { get; set; }
    public string?        Feats                 { get; set; }
    public string?        Skills                { get; set; }
    public string?        RacialMods            { get; set; }
    public string?        Languages             { get; set; }
    public string?        SQ                    { get; set; }
    public string?        Environment           { get; set; }
    public string?        Organization          { get; set; }
    public string?        Treasure              { get; set; }
    public string?        DescriptionVisual     { get; set; }
    public string?        CreatureGroup         { get; set; }
    public bool           IsTemplate            { get; set; }
    public string?        SpecialAbilities      { get; set; }
    public string?        Description           { get; set; }
    public string?        Gender                { get; set; }
    public string?        Bloodline             { get; set; }
    public string?        ProhibitedSchools     { get; set; }
    public string?        BeforeCombat          { get; set; }
    public string?        DuringCombat          { get; set; }
    public string?        Morale                { get; set; }
    public string?        Gear                  { get; set; }
    public string?        OtherGear             { get; set; }
    public string?        Vulnerability         { get; set; }
    public string?        CreatureNote          { get; set; }
    public bool           IsCharacter           { get; set; }
    public bool           IsCompanion           { get; set; }
    public bool           Fly                   { get; set; }
    public bool           Climb                 { get; set; }
    public bool           Burrow                { get; set; }
    public bool           Swim                  { get; set; }
    public bool           Land                  { get; set; }
    public string?        TemplatesApplied      { get; set; }
    public string?        OffenseNote           { get; set; }
    public string?        BaseStatistics        { get; set; }
    public string?        ExtractsPrepared      { get; set; }
    public string?        AgeCategory           { get; set; }
    public bool           DontUseRacialHD       { get; set; }
    public string?        VariantParent         { get; set; }
    public string?        Mystery               { get; set; }
    public string?        ClassArchetypes       { get; set; }
    public string?        Patron                { get; set; }
    public string?        CompanionFamiliarLink { get; set; }
    public string?        FocusedSchool         { get; set; }
    public string?        Traits                { get; set; }
    public string?        AlternateNameForm     { get; set; }
    public string?        StatisticsNote        { get; set; }
    public string?        LinkText              { get; set; }
    public bool           UniqueMonster         { get; set; }
    public int            MR                    { get; set; }
    public bool           IsMythic                { get; set; }
    public bool           MT                    { get; set; }
}
