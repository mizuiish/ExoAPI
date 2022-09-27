using Exoapi.Contexts;
using Exoapi.Interfaces;
using Exoapi.Models;

namespace Exoapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;
        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void CadastrarUsuarios(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges(); 
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }

            _context.Usuarios.Update(usuarioEncontrado);
            _context.SaveChanges();
        }
       public Usuario Login(string email, string senha)
        {
            
            return _context.Usuarios.First(u => u.Email == email && u.Senha == senha);
        }
    }
}
