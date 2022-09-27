using Exoapi.Contexts;
using Exoapi.Models;

namespace Exoapi.Repositories
{
    public class ProjetoRepository
    {
        private readonly SqlContext _context;
        public ProjetoRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto L)
        {
            _context.Projetos.Add(L);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto L = _context.Projetos.Find(id);
            _context.Projetos.Remove(L);
            _context.SaveChanges();
        }

        public void Alterar(int id, Projeto L)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                projetoBuscado.Titulo = L.Titulo;
                projetoBuscado.Requisitos = L.Requisitos;
                projetoBuscado.DataInicio = L.DataInicio;
                projetoBuscado.Andamento = L.Andamento;

                _context.Projetos.Update(projetoBuscado);
                _context.SaveChanges();
            }           
        }
    }
}
