using Exoapi.Models;

namespace Exoapi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void CadastrarUsuarios(Usuario novoUsuario);
        void DeletarUsuario(int id);
        void Atualizar(int id, Usuario usuario);
        Usuario Login(string email, string senha);
    }
}
