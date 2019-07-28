using System.ComponentModel.DataAnnotations;

namespace CMSC495Backend.Models
{
    public class Deck
    {
        public int DeckId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string DeckList { get; set; }
    }
}