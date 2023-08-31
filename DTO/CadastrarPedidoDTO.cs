namespace RestauranteAPI.DTO
{
    public class CadastrarPedidoDTO
    {
        public string NomeProduto { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
