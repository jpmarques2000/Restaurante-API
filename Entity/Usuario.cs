using RestauranteAPI.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Entity
{
    public class Usuario : Entidade
    {
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(80)")]
        [Required]
        public string NomeUsuario { get; set; }
        [Column(TypeName = "varchar(40)")]
        [Required]
        public string Senha { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(CadastrarUsuarioDTO cadastrarUsuarioDto)
        {
            Nome = cadastrarUsuarioDto.Nome;
            NomeUsuario = cadastrarUsuarioDto.NomeUsuario;
            Senha = cadastrarUsuarioDto.Senha;
        }
    }
}
