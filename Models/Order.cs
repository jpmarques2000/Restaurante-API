using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class Order : Entity
    {
        public int UsuarioId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal PrecoTotal { get; set; }
        public User? Usuario { get; set; }
        //public Refeicao? Refeicao { get; set; }
        public ICollection<Meal>? Refeicao { get; set; }

        public Order()
        {
            
        }

        public Order(AddNewOrderDTO newOrder)
        {
            UsuarioId = newOrder.UsuarioId;
        }

    }
}
