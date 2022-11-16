using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;//libreria cor
using System.Text.Json;
using WebEjemplo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/<ValuesController>/5
        [HttpGet]
        public string Get()
        {
            User u = new User("","",0);
            u.conectar();
            String mensaje = u.listUser();
            return mensaje;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public String Post([FromBody] JsonElement datosI)
        {
            String cedula = datosI.GetProperty("ced").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            int edad = datosI.GetProperty("ed").GetInt32();

            //Creo objeto
            User u = new User(cedula, nombre, edad);
            u.conectar();
            String mensaje = u.ingresarUser();
            return mensaje;

            //return "Post Funcionando";
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public String Put([FromBody] JsonElement datosI)
        {
            String cedula = datosI.GetProperty("ced").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            int edad = int.Parse(datosI.GetProperty("eda").ToString());
            User u = new User(cedula, nombre, edad);
            u.conectar();
            String mensaje = u.updateUser();
            return mensaje;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public String Delete([FromBody] JsonElement datosI)
        {
            String cedula = datosI.GetProperty("ced").ToString();
            User u = new User(cedula,"",0);
            u.conectar();
            String mensaje = u.deleteUser();
            return mensaje ;
        }
    }
}
