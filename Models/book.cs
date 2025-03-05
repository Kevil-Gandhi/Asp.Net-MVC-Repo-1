using System.ComponentModel.DataAnnotations;

namespace P_01.Models
{
    public class book
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
    }
}
