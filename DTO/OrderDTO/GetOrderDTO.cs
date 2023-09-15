using RestauranteAPI.DTO.Meal;

namespace RestauranteAPI.DTO.OrderDTO
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Models.User? Usuario { get; set; }
        public ICollection<GetMealDTO>? Refeicao { get; set; }
    }
}
