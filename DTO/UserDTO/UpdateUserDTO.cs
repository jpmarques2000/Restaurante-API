namespace RestauranteAPI.DTO.UserDTO
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Senha { get; set; }
    }
}
