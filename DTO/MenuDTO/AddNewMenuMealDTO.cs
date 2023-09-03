namespace RestauranteAPI.DTO.MenuDTO
{
    public class AddNewMenuMealDTO
    {
        public int Id { get; set; }

        public ICollection<Models.Meal>? Refeicao { get; set; }
    }
}
