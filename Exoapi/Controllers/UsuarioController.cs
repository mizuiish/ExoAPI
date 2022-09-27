using Exoapi.Interfaces;
using Exoapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsarioRepository;
        public UsuarioController(IUsuarioRepository IUsarioRepository)
        {
            _IUsarioRepository = IUsarioRepository; 
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IUsarioRepository.Listar());
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
                Usuario usuarioBuscado = _IUsarioRepository.BuscarPorId(id);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _IUsarioRepository.CadastrarUsuarios(novoUsuario);
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
                _IUsarioRepository.DeletarUsuario(id);
                return Ok("Usuario foi removido com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario U)
        {
            try
            {
                _IUsarioRepository.Atualizar(id, U);
                return Ok("Atualizado com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        
    }
}
