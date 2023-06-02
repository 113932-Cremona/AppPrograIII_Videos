using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Models
{

        public class Usuario
        {
            public int Id { get; set; }
            public string email { get; set; }
            public string Password { get; set; }

            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public int Edad { get; set; }

            public string direccion { get; set; }



        }
    
}
