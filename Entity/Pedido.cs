using RestauranteAPI.DTO;

namespace RestauranteAPI.Entity
{
    public class Pedido : Entidade
    {
        public string NomeProduto { get; set; }
        public int UsuarioId { get; set; }
        public int RefeicaoId { get; set; }
        public Usuario Usuario { get; set; }
        public Refeicao Refeicao { get; set; }
        public decimal PrecoTotal { get; set; }

        public Pedido()
        {
            
        }

        public Pedido(CadastrarPedidoDTO cadastrarPedidoDTO)
        {
            NomeProduto = cadastrarPedidoDTO.NomeProduto;
            UsuarioId = cadastrarPedidoDTO.UsuarioId;
            PrecoTotal = cadastrarPedidoDTO.PrecoTotal;
        }
    }
}
