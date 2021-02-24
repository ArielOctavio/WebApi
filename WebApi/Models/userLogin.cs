using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class userLogin
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

    }


    //Clase para retornar
    [NotMapped]
    public class userReturn
    {
        public userReturn(string nombre,string apellido,string token)
        {
            Nombre = nombre;
            Apellido = apellido;
            Token = token;
        }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Token { get; set; }

    }




}
