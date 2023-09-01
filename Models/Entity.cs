using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
