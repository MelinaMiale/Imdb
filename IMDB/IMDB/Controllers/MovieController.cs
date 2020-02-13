using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Models;
using Microsoft.AspNetCore.Mvc;
using Proyect_Models;
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

        //metodo que copia la informacion de un objeto de tipo Movie a un objeto de tipo MovieViewModel, y devuelve este ultimo
        private MovieViewModel MapMovietoMovieViewModel (Movie movie, MovieViewModel movieViewModel)
        {
            movieViewModel.Id = movie.ID_movie;
            movieViewModel.Name = movie.Name;

            return movieViewModel;
        }

        private MovieViewDetails MapMovietoMovieViewModel(Movie movie, MovieViewDetails movieViewDetails)
        {
            movieViewDetails.ID = movie.ID_movie;
            movieViewDetails.Name = movie.Name;
            movieViewDetails.FlyerUrl = movie.FlyerUrl;
            movieViewDetails.Nationality = movie.Nationality;
            movieViewDetails.ReleaseDate = movie.ReleaseDate;
            movieViewDetails.Cast = movie.Cast;

            return movieViewDetails;
        }


        public ActionResult Index()
        {
            //obtengo lita de peliculas guardadas en storage
            var movies = db.GetAll();

            //crear una lista en base al modelo MovieViewModel
            var movieViewModel = new List<MovieViewModel>();

            //implemento metodo para cada pelicula en la lista: movies, y las agrego a la lista: movieViewModel
            foreach(var movie in movies)
            {
                movieViewModel.Add(MapMovietoMovieViewModel(movie, new MovieViewModel()));
            }
            /*
             * otra forma de hacerlo es usando LinQ (similar al stream en Java)
             
                      var movieViewModels = movies.Select(m => new MovieViewModel {
                           Id = m.ID_movie,
                           FlyerUrl = m.FlyerUrl,
                           Name = m.Name
                      }).ToList(); 
             */
            return View(movieViewModel);// envio la lista de tipo MovieViewModel que contiene las peliculas con ese modelo 
        }

        public ActionResult Details(long Id)
        {
            // traer pelicula >> metodo para buscar por id
            var movieById = db.GetById(Id);

            //genero pelicula de tipo MovieDetailsView y le asigno la pelicula que obtuve x id
            MovieViewDetails movieViewDetailsByID = new MovieViewDetails();
            movieViewDetailsByID = MapMovietoMovieViewModel(movieById, movieViewDetailsByID);

            //enviarlos a la vista
            return View(movieViewDetailsByID);
        }

        public ActionResult Edit()
        {
            // traer pelicula a editar con metodo para buscar por id
            //mostrar los detalles con campos editables>> necesito crear EditMovieDetailsView
            //guardar los cambios
                       
            return View();
        }


        

    }

}
