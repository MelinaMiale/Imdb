using IMDB.EntityModels;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private IStorage db;

        public MovieController(IStorage repository)
        {
            db = repository;
        }

        //metodo que copia la informacion de un objeto de tipo Movie a un objeto de tipo MovieViewModel, y devuelve este ultimo
        private MovieViewModel MapMovietoMovieViewModel(Movie movie, MovieViewModel movieViewModel)
        {
            movieViewModel.Id = movie.Id;
            movieViewModel.Name = movie.Name;

            return movieViewModel;
        }

        private MovieDetailsViewModel MapMovieDetailstoMovieDetailsViewModel(Movie movie, MovieDetailsViewModel MovieDetailsViewModel)
        {
            MovieDetailsViewModel.ID = movie.Id;
            MovieDetailsViewModel.Name = movie.Name;
            MovieDetailsViewModel.Poster = movie.Poster;
            MovieDetailsViewModel.Nationality = movie.Nationality;
            MovieDetailsViewModel.ReleaseDate = movie.ReleaseDate;
            MovieDetailsViewModel.actorsInStorage = db.GetAllActors();

            return MovieDetailsViewModel;
        }

        private Movie MapMovieDetailsViewModelToMovieModel(Movie movieModel, MovieDetailsViewModel movieDetailsViewModel)
        {
            movieModel.Id = movieDetailsViewModel.ID;
            movieModel.Name = movieDetailsViewModel.Name;
            movieModel.Poster = movieDetailsViewModel.Poster;
            movieModel.Nationality = movieDetailsViewModel.Nationality;
            movieModel.ReleaseDate = movieDetailsViewModel.ReleaseDate;

            return movieModel;
        }

        //metodo que uso para ver el listado de personajes de una pelicula
        private MovieCharacterViewModel MapMovieCharactertoMovieCharacterViewModel(Movie movieEntity, MovieCharacterViewModel movieViewModel)
        {
            movieViewModel.Name = movieEntity.Name;
            movieViewModel.Characters = movieEntity.Characters;
            movieViewModel.MovieId = Convert.ToInt32(movieEntity.Id);
            return movieViewModel;
        }

        //metodo que uso para trabajar un personaje en particular
        private Character MapCharacterModelViewToCharacterEntity(Character characterEntity, CharacterViewModel characterViewModel)
        {
            characterEntity.Id = characterViewModel.Id;
            //characterEntity.Movie = characterViewModel.Movie;
            characterEntity.Actor = characterViewModel.Actor;
            characterEntity.Name = characterViewModel.Name;
            characterEntity.IdActor = Convert.ToInt32(characterViewModel.IdActor);
            //   characterEntity.AvailableActors = db.GetAllActors();

            return characterEntity;
        }

        public ActionResult Index()
        {
            //obtengo lita de peliculas guardadas en storage
            var movies = db.GetAllMovies();

            //crear una lista en base al modelo MovieViewModel
            var movieViewModel = new List<MovieViewModel>();

            //implemento metodo para cada pelicula en la lista: movies, y las agrego a la lista: movieViewModel
            foreach (var movie in movies)
            {
                movieViewModel.Add(MapMovietoMovieViewModel(movie, new MovieViewModel()));
            }
            /*
             * otra forma de hacerlo es usando LinQ (similar al stream en Java)

                      var movieViewModels = movies.Select(m => new MovieViewModel {
                           Id = m.Id,
                           Poster = m.Poster,
                           Name = m.Name
                      }).ToList();
             */
            return View(movieViewModel);// envio la lista de tipo MovieViewModel que contiene las peliculas con ese modelo
        }

        public ActionResult Details(int Id)
        {
            // traer pelicula >> metodo para buscar por id
            var movieById = db.GetMovieById(Id);

            //genero pelicula de tipo MovieDetailsView y le asigno la pelicula que obtuve x id
            var MovieDetailsViewModelByID = new MovieDetailsViewModel();
            MovieDetailsViewModelByID = MapMovieDetailstoMovieDetailsViewModel(movieById, MovieDetailsViewModelByID);

            //enviarlos a la vista
            return View(MovieDetailsViewModelByID);
        }

        // GET: Movie/Edit/{id}
        public ActionResult Edit(long Id)
        {
            var movie = db.GetMovieById(Id);
            if (movie == null)
            {
                return this.NotFound();
            }

            return View(MapMovieDetailstoMovieDetailsViewModel(movie, new MovieDetailsViewModel()));
        }

        // POST: Movie/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(MovieDetailsViewModel editedMovie)
        {
            //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula editada
            var editedMovieModel = db.GetMovieById(editedMovie.ID);

            //paso esa pelicula de tipo MovieDetailsViewModel a una pelicula de tipo MovieModel
            editedMovieModel = MapMovieDetailsViewModelToMovieModel(editedMovieModel, editedMovie);

            if (ModelState.IsValid)
            {
                db.UpdateMovie(editedMovieModel);
            }

            return View(MapMovieDetailstoMovieDetailsViewModel(editedMovieModel, new MovieDetailsViewModel()));
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
        public ActionResult CreatePost(MovieDetailsViewModel newMovie)
        {
            var newModelMovie = new Movie();
            MapMovieDetailsViewModelToMovieModel(newModelMovie, newMovie);
            db.SaveMovie(newModelMovie);

            return View();
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(long id)
        {
            //obtengo pelicula que quiero borrar
            var movie = db.GetMovieById(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            //paso la pelicula a borrar al modeloVista
            return View(MapMovieDetailstoMovieDetailsViewModel(movie, new MovieDetailsViewModel()));
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula que quiero borrar
            var movieToDelete = db.GetMovieById(id);

            if (ModelState.IsValid)
            {
                db.Delete(movieToDelete);
            }

            //regresar a la pagina index de movies
            return RedirectToAction(nameof(MovieController.Index), "Home");
        }

        //accion que lista personajes de una pelicula
        [Route("Movie/Characters/{movieId}")]
        [ActionName("Characters")]
        public ActionResult Characters(int movieId)
        {
            //obtengo pelicula
            var movie = db.GetMovieById(movieId);
            // creo pelicula de tipo viewmodel
            var movieViewModel = new MovieCharacterViewModel();
            //copio entidad a viewmodel
            movieViewModel = MapMovieCharactertoMovieCharacterViewModel(movie, movieViewModel);

            return View(movieViewModel);
        }

        //delete rol
        public ActionResult DeleteRol(int movieId, int rolId)
        {
            var rolToDelete = db.GetRolById(rolId);

            if (ModelState.IsValid)
            {
                db.DeleteRol(rolToDelete, movieId);
            }

            return RedirectToAction("Details", new { id = movieId });
        }

        // [Route("Movie/Characters/CreateCharacter")]

        [HttpGet]
        public ActionResult CreateCharacter(int idMovie)
        {
            var NewModel = new CharacterViewModel();

            NewModel.AvailableActors = db.GetAllActors();
            NewModel.IdMovie = idMovie;

            return View(NewModel);
        }

        //post: crear rol
        [HttpPost]
        //[ActionName("CreateCharacter")]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateCharacter(CharacterViewModel newcharacter)
        {
            var movieid = newcharacter.IdMovie;
            var character = new Character();
            character = MapCharacterModelViewToCharacterEntity(character, newcharacter);

            db.SaveRol(character, movieid, character.IdActor);

            return RedirectToAction("Characters", new { id = movieid });
        }
    }
}
