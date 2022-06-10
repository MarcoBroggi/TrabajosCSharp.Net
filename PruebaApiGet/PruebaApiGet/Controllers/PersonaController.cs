using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaApiGet.Controllers
{
    public class PersonaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModels.PersonaViewModel> listaPersonas = new List<ViewModels.PersonaViewModel>();
            using (Models.PruebaEntities db = new Models.PruebaEntities())
            {
                listaPersonas = (from d in db.Persona
                                 select new ViewModels.PersonaViewModel
                                 {
                                     Id = d.id,
                                     Nombre = d.nombre,
                                     Edad = (int)d.edad
                                 }).ToList();
            }

            return Ok(listaPersonas);
        }
    }
}
