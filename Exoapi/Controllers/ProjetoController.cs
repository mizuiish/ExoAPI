using Exoapi.Models;
using Exoapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _ProjetoRepository;

        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _ProjetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ProjetoRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_ProjetoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Projeto L)
        {
            try
            {
                _ProjetoRepository.Cadastrar(L);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _ProjetoRepository.Deletar(id);
                return Ok("O projeto foi deletado com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Projeto L)
        {
            try
            {
                _ProjetoRepository.Alterar(id, L);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
