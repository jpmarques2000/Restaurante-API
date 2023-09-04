namespace RestauranteAPI.DTO.Meal
{
    public class GetMealDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        
    }
}
