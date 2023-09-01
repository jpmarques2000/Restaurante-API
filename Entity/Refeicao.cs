using RestauranteAPI.DTO.Meal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Entity
{
    public class Refeicao : Entidade
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string Nome { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Preco { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descricao { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Cardapio> Cardapio { get; set; }

        public Refeicao()
        {
            
        }
        public Refeicao(CadastrarRefeicaoDTO cadastrarRefeicaoDTO)
        {
            Nome = cadastrarRefeicaoDTO.Nome;
            Preco = cadastrarRefeicaoDTO.Preco;
            Descricao = cadastrarRefeicaoDTO.Descricao;
        }

        public Refeicao(UpdateMealDTO alterarRefeicaoDTO)
        {
            Nome = alterarRefeicaoDTO.Nome;
            Preco = alterarRefeicaoDTO.Preco;
            Descricao = alterarRefeicaoDTO.Descricao;
        }
    }
}
