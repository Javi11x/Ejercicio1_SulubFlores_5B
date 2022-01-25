using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Peli.Infraestructure.Repositories;
using Peli.Domain.entities;

namespace Peli.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliController : ControllerBase
    {
        [HttpGet]
        [Route("films")]
        public IActionResult GetTodasPeliculas()
        {
            PeliRepository pelis = new PeliRepository();
            return Ok(pelis.GetTodasPeliculas());
        }

        [HttpGet]
        [Route("films/{id}")]
        public IActionResult ObtenerId(int id)
        {
            PeliRepository pelis = new PeliRepository();
            var peli = pelis.ObtenerId(id);
            if(peli == null)
            {
                return NotFound($"No existe ninguna Película con este id: {id}");
            }
            return Ok(peli);
        }

        [HttpGet]
        [Route("Director")]
        public IActionResult ObtenerDirector (string director)
        {
            PeliRepository peli = new PeliRepository();
            var pelis = peli.ObtenerDirector(director);
            if(pelis.Count() == 0)
            {
                return NotFound($"No existe ninguna película con el director: {director}");
            }
            return Ok(pelis);
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult CrearPelicula(Pelicula nuevaPeli)
        {
            PeliRepository pelis = new PeliRepository();
            pelis.CrearPelicula(nuevaPeli);
            return Ok("Película creada correctamente");
            

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult ActualizarPelicula(int id, Pelicula actualizarPelicula)
        {
            PeliRepository pelis = new PeliRepository();
            var validar = pelis.ObtenerId(id);
            if(validar == null)
            {
                return NotFound($"No existe ninguna película con el id: {id}");
            }
            pelis.ActualizarPelicula(id, actualizarPelicula);
            return Ok(pelis);
        }

        [HttpDelete]
        [Route("Detele")]
        public IActionResult BorrarPelicula(int id)
        {
            PeliRepository pelis = new PeliRepository();
            var validar = pelis.ObtenerId(id);
            if(validar == null)
            {
                return NotFound($"No existe ninguna película con el id: {id}");
            }
            pelis.BorrarPelicula(id);
            return Ok(pelis);
        }
    }
}