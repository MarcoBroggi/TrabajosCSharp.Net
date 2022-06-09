using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaApi2.Controllers
{
    public class PersonaController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(Models.Request.PersonaRequest model)
        {
            //El IHttpActionResult es una interfaz que devuelve un json, pero se puede hacer con cualquier tipo de retorno.
            using (Models.PruebaEntities db = new Models.PruebaEntities())
            {
                var persona = new Models.Persona();
                persona.nombre = model.Nombre;
                persona.edad = model.Edad;
                db.Persona.Add(persona);
                try
                {
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    return Ok("fallo");
                }
               
            }
            return Ok("exito");
        }
    }
}
