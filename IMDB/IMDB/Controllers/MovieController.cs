using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        InMemoryMovieStorage db;

        public MovieController()
        {
            db = new InMemoryMovieStorage();
        }

        public ViewResult Index()
        {
            var model = db.GetAll();// creo un modelo donde voy a ingresar todas las peliculas, var en este caso toma la forma de List<Proyect_Model.Movies>
            return View(model); //debo enviar el modelo por parametro para que la vista obtenga la informacion
        }

        /*
        public ActionResult Create()
        {
            return View();
        }
        */


    }

}
