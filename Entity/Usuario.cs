using RestauranteAPI.DTO;

namespace RestauranteAPI.Entity
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
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
