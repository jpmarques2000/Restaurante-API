namespace RestauranteAPI.DTO.Meal
{
    public class UpdateMealDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
    }
}
