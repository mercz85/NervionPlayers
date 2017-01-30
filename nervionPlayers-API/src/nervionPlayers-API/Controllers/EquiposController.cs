﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    //    [Route("api/[controller]")]
    public class EquiposController : Controller
    {
        // GET: NP
        public ActionResult Index()
        {
            return View();
        }
        #region GETs
        /// <summary>
        /// Ruta: /equipos
        /// Metodo que devuelve un IEnumerable de equipos
        /// </summary>
        /// <returns>IEnumerable de equipos</returns>
        [HttpGet]
        public IEnumerable<Equipo> GetEquipos()
        {
            return null;
        }

        //  /equipos/{id }

        /// <summary>
        /// Ruta: /equipos/id
        /// Metodo que devuelve un Equipo con la id especificada
        /// </summary>
        /// <returns>un Equipo</returns>
        [HttpGet("{id}")]
        public Equipo GetEquipo()
        {

            return null;
        }
        #endregion
        #region POST
        /// Metodo que crea un nuevo equipo
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo equipo
        /// </summary>
        /// <param name=""></param>
        [HttpPost]
        public void PostEquipos()
        {

        }
        #endregion
        #region PUT
        /// <summary>
        /// Metodo que realiza la actualizacion de un Equipo
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Equipo
        /// </summary>
        /// <param name="idEquipo">Es el ID del Partido que el usuario desea actualizar</param>
        //[HttpPut("{idEquipo}")]
        public void PutEquipos(int idEquipo)
        {

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Metodo que borra un Equipo 
        /// Descomentar linea de encima del metodo
        /// Falta meter la funcionalidad del metodo
        /// </summary>
        /// <param name="idEquipo">El Id del Equipo que el usuario desea borrar</param>
        //[HttpDelete("{idEquipo}")]
        public void DeleteEquipos(int idEquipo)
        {


        }
        #endregion
        #region METODOS PARA LA TABLA ALUMNOSEQUIPOS
        /// <summary>
        /// Ruta: /equipos/{idEquipo}/alumno
        /// Metodo que devuelve un grupo de alumnos pertenecientes a un equipo concreto con la idEquipo
        /// </summary>
        /// <returns>IEnumerable<Alumnnos></returns>
        [HttpGet("{idEquipo}")]
        public IEnumerable<Alumnnos> GetAlumnosEquipo()
        {

            //if (alumnoEquipo != null)
            //{
            //    return new ObjectResult(alumnoEquipo);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }


        //Hace referencia a la tabla AlumnosGrupos

        /// <summary>
        /// Ruta: /alumnos/{idAlumno}/equipo
        /// Metodo que devuelve un grupo de equipos a los que pertenece un alumno
        /// se pasa el idAlumno
        /// </summary>
        /// <returns>IEnumerable<Equipos></returns>
        [HttpGet("{idAlumno}")]
        public IEnumerable<Equipos> GetEquiposAlumno()
        {

            return null;
        }
        #endregion
    }
}
