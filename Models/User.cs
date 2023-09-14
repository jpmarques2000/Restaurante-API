using RestauranteAPI.DTO.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class User : Entity
    {
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string NomeUsuario { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public ICollection<Order>? Pedidos { get; set; }
    }
}
