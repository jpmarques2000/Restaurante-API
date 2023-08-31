using RestauranteAPI.DTO;

namespace RestauranteAPI.Entity
{
    public class Refeicao : Entidade
    {
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Cardapio> Cardapios { get; set; }

        public Refeicao()
        {
            
        }
        public Refeicao(CadastrarRefeicaoDTO cadastrarRefeicaoDTO)
        {
            Nome = cadastrarRefeicaoDTO.Nome;
            Preco = cadastrarRefeicaoDTO.Preco;
            Descricao = cadastrarRefeicaoDTO.Descricao;
        }

        public Refeicao(AlterarRefeicaoDTO alterarRefeicaoDTO)
        {
            Nome = alterarRefeicaoDTO.Nome;
            Preco = alterarRefeicaoDTO.Preco;
            Descricao = alterarRefeicaoDTO.Descricao;
        }
    }
}
