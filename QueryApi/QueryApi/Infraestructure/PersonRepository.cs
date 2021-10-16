using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

// Universidad Tecnologica Metropolitana
// Aplicaciones Web Orientada a Servicios
// Carlos Manuel Mezquita Alvarado
// 4°B
// Practica 1
// Parcial 2
// Profesor: Ing. Joel Ivan Chuc Uc
//

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _Personas;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _Personas = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // Método para Retornar todos los valores de la lista Personas//

        public IEnumerable<Person> GetAllDatos ()
        {
            return _Personas;
        }

        // Método para retornar campos en especifico (Nombre,Apellido,Correo)//

        public IEnumerable<Object> GetCampos_N_A_C ()
        {
            var query = _Personas.Select(person => new {

                Nombre_Completo = $"{person.FirstName} {person.LastName}",
                Anio_Nacimiento = DateTime.Now.AddYears(person.Age * -1).Year,
                CorreoE = person.Email 
            });
            
            return query;
        }

        // Método para retornar campos por Género //

        public IEnumerable<Person> GetGenero (char genero)
        {
            var query = _Personas.Where(person => person.Gender == genero);
            return query;
        }

        // Método para retornar Rango de Edad //
        
        public IEnumerable<Person> GetRangoEdad (int edadMinima, int edadMaxima)
        {
            var query = _Personas.Where(person => person.Age > edadMinima && person.Age < edadMaxima);
            return query;
        }

        // Método para retornar Campos Trabajos //

        public IEnumerable<string> GetTrabajos()
        {
            var query = _Personas.Select(person => person.Job).Distinct();
            return query;
        } 

        // Método para obtener Contenido Especifico A_R//
        
        public IEnumerable<Person> GetContenido_A_R (string nombreAR)
        {
            var query = _Personas.Where(person => person.FirstName.Contains(nombreAR));
            return query;
        }

        //Método para obtener Rangos por edades 25_35_45 //

        public IEnumerable<Person> GetEdades_25_35_45 (int edad1, int edad2, int edad3)
        {
            var edades = new List<int>{edad1,edad2,edad3};
            var query = _Personas.Where(person => edades.Contains(person.Age));
            return query;
        }

        // Metodo para obtener Campos por orden //
        
        public IEnumerable<Person> GetMayores40 (int edad)//
        {
            var query = _Personas.Where(person => person.Age > edad).OrderBy(person => person.Age);
            return query;
        }

        //Método para obtener Campos por Rango de Edad y Género //

        public IEnumerable<Person> GetRangoEdadGenero (int edadMinima, int edadMaxima, char genero)
        {
            var query = _Personas.Where(person => person.Age > edadMinima && person.Age < edadMaxima &&  person.Gender ==  genero).OrderByDescending(person =>  person.Gender);
            return query;
        }

        // Método pata retornar Cantidad Generos // 
        
        public IEnumerable<Person> GetCantidadGenero (char genero)
        {
            var query = _Personas.Where(person => person.Gender == genero);
            return query;
        }

        // Método para verificar apellido existente//

        public bool GetApellido_Existente (string apellido)
        {
            var query = _Personas.Any(p => p.LastName == apellido);

            return query;
        }


        //Método para obtener Trabajo y Edad //

        public IEnumerable<Person> Get_Trabajo_Edad (string trabajo, int edad)
        {
            var query = _Personas.Where(person => person.Job == trabajo && person.Age == edad);
            return query;
        }

        // Método para retornar información del Trabajo // 3 Primeras //
        
        public IEnumerable<Person> GetPersonasTrabajo (string trabajo, int tomar)
        {
            var query = _Personas.Where(person => person.Job == trabajo).Take(tomar);
            return query;
        }

        // Método para retornar información del Trabajo// Omite 3 // agarra las que siguen //
        public IEnumerable<Person> GetNextPersonasTrabajo(string trabajo, int next)
        {

            var query = _Personas.Where(person => person.Job == trabajo).TakeLast(next);
            return query;
        }

        
        // Método para retornar información del Trabajo// Omita la info de las primeras // retorna las 3 siguientes //
        public IEnumerable<Person> GetSkipPersonasTrabajo(string trabajo, int skip, int tomar)
        {
            var query = _Personas.Where(person => person.Job == trabajo).Skip(skip).Take(tomar);
            return query;
        }
    }
}