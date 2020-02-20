using IMDB.Web.EntityModel;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
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

        private MovieDetailsViewModel MapMovietoMovieViewModel_Details(Movie movie, MovieDetailsViewModel MovieDetailsViewModel)
        {
            MovieDetailsViewModel.ID = movie.Id;
            MovieDetailsViewModel.Name = movie.Name;
            MovieDetailsViewModel.Poster = movie.Poster;
            MovieDetailsViewModel.Nationality = movie.Nationality;
            MovieDetailsViewModel.ReleaseDate = movie.ReleaseDate;
            MovieDetailsViewModel.Characters = movie.Characters;
            MovieDetailsViewModel.actorsInStorage = db.GetAllActors();

            return MovieDetailsViewModel;
        }

        private Movie MapMovieDetailsModelToMovieModel(Movie movieModel, MovieDetailsViewModel MovieDetailsViewModel)
        {
            movieModel.Id = MovieDetailsViewModel.ID;
            movieModel.Name = MovieDetailsViewModel.Name;
            movieModel.Poster = MovieDetailsViewModel.Poster;
            movieModel.Nationality = MovieDetailsViewModel.Nationality;
            movieModel.Characters = MovieDetailsViewModel.Characters;
            movieModel.ReleaseDate = MovieDetailsViewModel.ReleaseDate;
            movieModel.Characters = MovieDetailsViewModel.Characters;

            return movieModel;
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
            MovieDetailsViewModelByID = MapMovietoMovieViewModel_Details(movieById, MovieDetailsViewModelByID);

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

            return View(MapMovietoMovieViewModel_Details(movie, new MovieDetailsViewModel()));
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
            editedMovieModel = MapMovieDetailsModelToMovieModel(editedMovieModel, editedMovie);

            if (ModelState.IsValid)
            {
                db.UpdateMovie(editedMovieModel);
            }

            return View(MapMovietoMovieViewModel_Details(editedMovieModel, new MovieDetailsViewModel()));
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
            MapMovieDetailsModelToMovieModel(newModelMovie, newMovie);
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
            return View(MapMovietoMovieViewModel_Details(movie, new MovieDetailsViewModel()));
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

        //Post: crear rol
        [HttpPost]
        [ActionName("CreateRol")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRolPost(int movieId, string characterName, int actorId)
        {
            var newRol = new Character();
            newRol.Name = characterName;
            newRol.Movie = db.GetMovieById(movieId);
            newRol.Actor = db.GetActorbyId(actorId);

            db.SaveRol(newRol, movieId, actorId);

            return RedirectToAction("Details", new { id = movieId });
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

        [Route("Movie/{movieId}/Characters")]
        public ActionResult Characters(int movieId)
        {
            return null;
            // traer pelicula del storage
            // convertir a cual view model
            // - de la pelicula el nombre y id
            // - ademas por cada character nombre y el actor
            // invocar a la vista con ese model
        }

        public class MovieCharacterEditViewModel
        {
            public string Name
            {
                get;
                set;
            }

            public int ActorId
            {
                get;
                set;
            }

            public List<ActorViewModel> AvailableActor
            {
                get;
                set;
            }
        }

        [Route("Movie/{movieId}/Characters/{characterId}")]
        public ActionResult CharacterEdit(int movieId, int characterId)
        {
            // traer character del storage
            // convertir a cual view model de edicion
            var viewModel = new MovieCharacterEditViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("Movie/{movieId}/Characters/{characterId}")]
        [ActionName("CharacterEdit")]
        public ActionResult CharacterEditPost(int movieId, int characterId, MovieCharacterEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // traer character entity del storage
                // vuelco los datos del character view model en el entity
                // actualizar lo que haga falta en el storage

                return RedirectToAction("Characters", new { movieId = movieId });
            }

            return View(viewModel);
        }
    }
}
