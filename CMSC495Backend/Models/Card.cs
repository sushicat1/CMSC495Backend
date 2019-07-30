using System.ComponentModel.DataAnnotations;

namespace CMSC495Backend.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string AffiliationCode { get; set; }
        public string Code { get; set; }
        public int Cost { get; set; }
        public int Deck_Limit { get; set; }
        public string Faction_Code { get; set; }
        public string Flavor { get; set; }
        public bool Has_Die { get; set; }
        public bool Has_Errata { get; set; }
        public string Illustrator { get; set; }
        public bool Is_Unique { get; set; }
        public string Name { get; set; }
        public string Points { get; set; }
        public int Position { get; set; }
        public int Rarity_Code { get; set; }
        public int Reprint_Of { get; set; }
        public int Set_Code { get; set; }
        public int Sides { get; set; }
        public int Subtitle { get; set; }
        public int Subtypes { get; set; }
        public int text_ { get; set; }
        public int Ttscardid { get; set; }
        public int type_code { get; set; }

    }
}