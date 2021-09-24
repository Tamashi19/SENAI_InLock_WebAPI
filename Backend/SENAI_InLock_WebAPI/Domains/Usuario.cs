using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Domains
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

       
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 caracteres")]
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
