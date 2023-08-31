using RestauranteAPI.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Entity
{
    public class Pedido : Entidade
    {
        public int UsuarioId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal PrecoTotal { get; set; }
        public Usuario Usuario { get; set; }
        //public Refeicao? Refeicao { get; set; }
        public ICollection<Refeicao> Refeicao { get; set; }
        

        public Pedido()
        {
            
        }

        public Pedido(CadastrarPedidoDTO cadastrarPedidoDTO)
        {
            UsuarioId = cadastrarPedidoDTO.UsuarioId;
            PrecoTotal = cadastrarPedidoDTO.PrecoTotal;
        }
    }
}
