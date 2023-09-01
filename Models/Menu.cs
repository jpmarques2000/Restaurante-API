using RestauranteAPI.DTO.Menu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class Menu : Entity
    {
        [Required]
        [Column(TypeName = "varchar(80)")]
        public string? NomeCardapio { get; set; }
        public ICollection<Meal>? Refeicao { get; set; }

        public Menu()
        {

        }

        public Menu(AddNewMenuDTO menuDTO)
        {
            NomeCardapio = menuDTO.NomeCardapio;
        }

        public Menu(UpdateMenuDTO menuDTO)
        {
            NomeCardapio = menuDTO.NomeCardapio;
        }
    }
}
