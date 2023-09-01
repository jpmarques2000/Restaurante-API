using RestauranteAPI.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.DTO.Meal
{
    public class GetMealDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
        public ICollection<Cardapio>? Cardapio { get; set; }
    }
}
