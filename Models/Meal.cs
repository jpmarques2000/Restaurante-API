using RestauranteAPI.DTO.Meal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class Meal : Entity
    {
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string? Nome { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Preco { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string? Descricao { get; set; }
        public ICollection<Order>? Pedido { get; set; }
        public ICollection<Menu>? Cardapio { get; set; }

        public Meal()
        {

        }
        public Meal(AddNewMealDTO cadastrarRefeicaoDTO)
        {
            Nome = cadastrarRefeicaoDTO.Nome;
            Preco = cadastrarRefeicaoDTO.Preco;
            Descricao = cadastrarRefeicaoDTO.Descricao;
        }

        public Meal(UpdateMealDTO alterarRefeicaoDTO)
        {
            Nome = alterarRefeicaoDTO.Nome;
            Preco = alterarRefeicaoDTO.Preco;
            Descricao = alterarRefeicaoDTO.Descricao;
        }
    }
}
