using RestauranteAPI.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Entity
{
    public class Cardapio : Entidade
    {
        [Required]
        [Column(TypeName = "varchar(80)")]
        public string? NomeCardapio { get; set; }
        public ICollection<Refeicao> Refeicao { get; set; }

        public Cardapio()
        {
            
        }

        public Cardapio(CadastrarCardapioDTO cadastrarCardapioDTO)
        {
            NomeCardapio = cadastrarCardapioDTO.NomeCardapio;
        }

        public Cardapio(AlterarCardapioDTO cardapioDTO)
        {
            NomeCardapio = cardapioDTO.NomeCardapio;
        }
    }
}
