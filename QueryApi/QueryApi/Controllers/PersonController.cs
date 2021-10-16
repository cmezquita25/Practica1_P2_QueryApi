using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;


// Universidad Tecnologica Metropolitana
// Aplicaciones Web Orientada a Servicios
// Carlos Manuel Mezquita Alvarado
// 4°B
// Practica 1
// Parcial 2
// Profesor: Ing. Joel Ivan Chuc Uc
//

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("Todos")]
        public IActionResult All ()
        {
            var repository = new PersonRepository();
            var personas = repository.GetAllDatos();
            return Ok(personas);
        } 

        [HttpGet]
        [Route("Campos")]
        public IActionResult Campos_Especificos ()
        {
            var repository = new PersonRepository();
            var personas = repository.GetCampos_N_A_C();
            return Ok(personas);
        } 

        [HttpGet]
        [Route("Generos")]
        public IActionResult BuscarGenero (char genero)
        {
            var repository = new PersonRepository();
            var personas = repository.GetGenero(genero);
            return Ok(personas);
        } 

        [HttpGet]
        [Route("RangoEdad")]
        public IActionResult RangoDeEdad (int edadMinimo, int edadMaximo)
        {
            var repository = new PersonRepository();
            var persons = repository.GetRangoEdad(edadMinimo, edadMaximo);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Trabajos")]
        public IActionResult Trabajos ()
        {
            var repository = new PersonRepository();
            var persons = repository.GetTrabajos();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Contenidos")]
        public IActionResult BuscarContenido (string nombreAR)
        {
            var repository = new PersonRepository();
            var persons = repository.GetContenido_A_R(nombreAR);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Edades")]
        public IActionResult Rango_Edades_234 (int edad1, int edad2, int edad3)
        {
            var repository = new PersonRepository();
            var persons = repository.GetEdades_25_35_45(edad1, edad2, edad3);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("OrdenPersonas40")]
        public IActionResult Orden40sPersonas (int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.GetMayores40(edad);
            return Ok(persons);
        }

        [HttpGet]
        [Route("RangoEdadGeneros")]
        public IActionResult Rango_Edad_Generos (int edadMinima, int edadMaxima, char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetRangoEdadGenero(edadMinima, edadMaxima, genero);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("ContarGeneros")]
        public IActionResult ContarGeneros (char genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetCantidadGenero(genero);
            return Ok(persons);
        }

                [HttpGet]
        [Route("BuscarApellido")]
        public IActionResult BuscarPorApellido (string apellido)
        {
            var repository = new PersonRepository();
            var persons = repository.GetApellido_Existente(apellido);
            return Ok(persons);
        }

        [HttpGet]
        [Route("BuscarTrabajosEdad")]
        public IActionResult BuscarTrabajoEdad (string trabajo, int edad)
        {
            var repository = new PersonRepository();
            var persons = repository.Get_Trabajo_Edad(trabajo, edad);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Personas3")]
        public IActionResult TomarPersonas3 (string trabajo, int tomar)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonasTrabajo(trabajo, tomar);
            return Ok(persons);
        }

        [HttpGet]
        [Route("PersonasNext")]
        public IActionResult TomarPersonasNext (string trabajo, int next)
        {
            var repository = new PersonRepository();
            var persons = repository.GetNextPersonasTrabajo(trabajo, next);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("SkipPersonas")]
        public IActionResult TomarPersonasSkips (string trabajo, int skip, int tomar)
        {
            var repository = new PersonRepository();
            var persons = repository.GetSkipPersonasTrabajo(trabajo, skip, tomar);
            return Ok(persons);
        }

    }

}
