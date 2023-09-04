using RestauranteAPI.DTO.Meal;

namespace RestauranteAPI.DTO.MenuDTO
{
    public class GetMenuDTO
    {
        public int Id { get; set; }
        public string? NomeCardapio { get; set; }
        public ICollection<GetMealDTO>? Refeicoes { get; set; }
    }
}
