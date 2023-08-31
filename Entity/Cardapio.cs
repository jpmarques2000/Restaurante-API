using RestauranteAPI.DTO;

namespace RestauranteAPI.Entity
{
    public class Cardapio : Entidade
    {
        public string? Nome { get; set; }
        public int RefeicaoId { get; set; }
        public ICollection<Refeicao> Refeicao { get; set; }

        public Cardapio()
        {
            
        }

        public Cardapio(CadastrarCardapioDTO cadastrarCardapioDTO)
        {
            Nome = cadastrarCardapioDTO.Nome;
            RefeicaoId = cadastrarCardapioDTO.RefeicaoId;
        }
    }
}
