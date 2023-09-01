using RestauranteAPI.DTO.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class User : Entity
    {
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string? Nome { get; set; }
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string? NomeUsuario { get; set; }
        [Column(TypeName = "varchar(40)")]
        [Required]
        public string? Senha { get; set; }
        public ICollection<Order> Pedidos { get; set; }

        public User()
        {

        }

        public User(AddNewUserDTO cadastrarUsuarioDto)
        {
            Nome = cadastrarUsuarioDto.Nome;
            NomeUsuario = cadastrarUsuarioDto.NomeUsuario;
            Senha = cadastrarUsuarioDto.Senha;
        }
    }
}
