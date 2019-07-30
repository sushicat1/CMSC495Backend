using System.ComponentModel.DataAnnotations;

namespace CMSC495Backend.Models
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string DeckList { get; set; }
    }
}