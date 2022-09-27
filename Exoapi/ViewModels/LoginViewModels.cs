using System.ComponentModel.DataAnnotations;

namespace Exoapi.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "Informe o email do usuário.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string senha { get; set; }
    }
}
