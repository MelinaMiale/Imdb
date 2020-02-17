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
        IStorage db;
        public MovieController(IStorage repository)
        {
            db = repository;            
        }

        //metodo que copia la informacion de un objeto de tipo Movie a un objeto de tipo MovieViewModel, y devuelve este ultimo
        private MovieViewModel MapMovietoMovieViewModel (Movie movie, MovieViewModel movieViewModel)
        {
            movieViewModel.Id = movie.ID_movie;
            movieViewModel.Name = movie.Name;

            return movieViewModel;
        }

        private MovieViewDetails MapMovietoMovieViewModel_Details(Movie movie, MovieViewDetails movieViewDetails)
        {
            movieViewDetails.ID = movie.ID_movie;
            movieViewDetails.Name = movie.Name;
            movieViewDetails.FlyerUrl = movie.FlyerUrl;
            movieViewDetails.Nationality = movie.Nationality;
            movieViewDetails.ReleaseDate = movie.ReleaseDate;
            movieViewDetails.Characters = movie.Characters;
            
            return movieViewDetails;
        }

        private Movie MapMovieDetailsModel_to_MovieModel (Movie movieModel, MovieViewDetails movieViewDetails)
        {
            movieModel.ID_movie = movieViewDetails.ID;
            movieModel.Name = movieViewDetails.Name;
            movieModel.FlyerUrl = movieViewDetails.FlyerUrl;
            movieModel.Nationality = movieViewDetails.Nationality;
            movieModel.Characters = movieViewDetails.Characters;
            movieModel.ReleaseDate = movieViewDetails.ReleaseDate;

            return movieModel;
        }


        public ActionResult Index()
        {
            //obtengo lita de peliculas guardadas en storage
            var movies = db.GetAllMovies();

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
            var movieById = db.GetMovieById(Id);

            //genero pelicula de tipo MovieDetailsView y le asigno la pelicula que obtuve x id
            var movieViewDetailsByID = new MovieViewDetails();
            movieViewDetailsByID = MapMovietoMovieViewModel_Details(movieById, movieViewDetailsByID);
            
            //enviarlos a la vista
            return View(movieViewDetailsByID);
        }

        // GET: Movie/Edit/{id}
        public ActionResult Edit(long Id)
        {
            var movie = db.GetMovieById(Id);
            if (movie == null)
            {
                return this.NotFound();
            }
            
            return View(MapMovietoMovieViewModel_Details(movie, new MovieViewDetails()));
        }


        // POST: Movie/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(MovieViewDetails editedMovie)
        {
            //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula editada
            var editedMovieModel = db.GetMovieById(editedMovie.ID);

            //paso esa pelicula de tipo MovieViewDetails a una pelicula de tipo MovieModel
            editedMovieModel = MapMovieDetailsModel_to_MovieModel(editedMovieModel, editedMovie);

            if (ModelState.IsValid)
            {
                db.UpdateMovie(editedMovieModel);
            }

            return View(MapMovietoMovieViewModel_Details(editedMovieModel, new MovieViewDetails()));
        }


        // GET: Movie/Create
        public ActionResult Create()
        {                                             
           return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(MovieViewDetails newMovie)
        {
            var newModelMovie = new Movie();
            MapMovieDetailsModel_to_MovieModel(newModelMovie, newMovie);

            db.SaveMovie(newModelMovie);  

            return View();
        }


        // GET: Student/Delete/5
        public ActionResult Delete(long id)
        {
            //obtengo pelicula que quiero borrar
            var movie = db.GetMovieById(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            //paso la pelicula a borrar al modeloVista
            return View(MapMovietoMovieViewModel_Details(movie, new MovieViewDetails()));
        }


        // POST: Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula que quiero borrar
            var movieToDelete = db.GetMovieById(id);

            //if (ModelState.IsValid)
            {
                db.Delete(movieToDelete);
            }

            //regresar a la pagina index de movies
            return RedirectToAction(nameof(MovieController.Index), "Home");

        }

    }

}
