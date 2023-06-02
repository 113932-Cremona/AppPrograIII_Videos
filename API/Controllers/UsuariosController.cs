
using Microsoft.AspNetCore.Mvc;
using Clases.Resultados;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Clases.Models;
using API.context;
using Microsoft.EntityFrameworkCore;
using Clases.Comandos;
using Clases.Resultados.Usuarios;

namespace API.Controllers
{
    [ApiController]
    
    public class UsuariosController : ControllerBase //acá viene solo Controller. Agregale el Base
    {
        
        private readonly ContextBD contex;

        public UsuariosController(ContextBD contex)
        {
            this.contex = contex;
        }

        [HttpGet]
        [Route("/API/Usuario/ObtenerUsuarios")]
        public async Task<UsuarioResultado> ObtenerUsuarios() {

            UsuarioResultado resultado = new UsuarioResultado();

            resultado.ListaUsuarios = await contex.Usuario.ToListAsync(); //atencion a el metodo que impacta a la base, es Async, tambien esta previamente especificado un await. todo dentro de un método async
            resultado.StatusCode = 200;
            return resultado;
        }

        [HttpPost]
        [Route("/API/Usuario/Login")]
        public async Task<LoginResultado> login(LoginComando comando)
        {
            var resultado = new LoginResultado();
            var usuario = await contex.Usuario.FirstOrDefaultAsync(c => c.email.Equals(comando.Email) && c.Password.Equals(comando.Password));
            if (usuario == null)
            {
                resultado.setError("Usuario o contraseña incorrecta");
                return resultado;
            }
            resultado.LoginResult = true;
            resultado.Ok = true;
            resultado.StatusCode = 200;
            return resultado;

        }
    }
}
