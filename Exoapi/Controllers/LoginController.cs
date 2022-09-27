using Exoapi.Interfaces;
using Exoapi.Models;
using Exoapi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Exoapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public LoginController(IUsuarioRepository IUsarioRepository)
        {
            _IUsuarioRepository = IUsarioRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModels dadoslogin)
        {
            try
            {
                Usuario usuarioBuscado = _IUsuarioRepository.Login(dadoslogin.email, dadoslogin.senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "Email ou senha incorreta." });
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao"));

                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "exoapi.webapi",
                    audience: "exoapi.webapi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credencial
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
