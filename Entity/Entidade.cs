using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Entity
{
    public class Entidade
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
