using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Infome o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Infome a senha")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 10 caracteres")]
        public string Senha { get; set; }
    }
}
