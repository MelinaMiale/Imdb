using IMDB.EntityModels;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

//using Repository;
using System;
using System.Linq;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private ISession session;

        public MovieController(ISession session)
        {
            this.session = session;
            //       db = repository;
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
            MovieDetailsViewModel.Id = Convert.ToInt32(movie.Id);
            MovieDetailsViewModel.Name = movie.Name;
            MovieDetailsViewModel.Poster = movie.Poster;
            MovieDetailsViewModel.Nationality = movie.Nationality;
            MovieDetailsViewModel.ReleaseDate = movie.ReleaseDate;

            return MovieDetailsViewModel;
        }

        private Movie MapMovieDetailsViewModelToMovieModel(Movie movieModel, MovieDetailsViewModel movieDetailsViewModel)
        {
            movieModel.Id = movieDetailsViewModel.Id;
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
            // characterEntity.IdActor = Convert.ToInt32(characterViewModel.IdActor);
            //   characterEntity.AvailableActors = db.GetAllActors();

            return characterEntity;
        }

        public ViewResult Index()
        {
            var movies = this.session.Query<Movie>().ToList();

            var movieViewModel = movies.Select(m => new MovieViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return View(movieViewModel);
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
        public ActionResult CreatePost(MovieDetailsViewModel newMovieViewModel)
        {
            if (newMovieViewModel == null)
            {
                throw new ArgumentNullException(nameof(newMovieViewModel));
            }

            using (var transaction = this.session.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    var newEntityMovie = MapMovieDetailsViewModelToMovieModel(new Movie(), newMovieViewModel); ;

                    this.session.Save(newEntityMovie);

                    this.session.Transaction.Commit();

                    this.TempData["Message"] = "Movie saved succsessfully!";
                }
            }

            return RedirectToAction(nameof(MovieController.Index), "Home");
        }

        public ActionResult Details(long Id)
        {
            // traer pelicula >> metodo para buscar por id
            var movieById = this.session.Get<Movie>(Id);// la sesion espera un long y recibe un entero

            if (movieById == null)
            {
                return this.NotFound();
            }

            //genero pelicula de tipo MovieDetailsView y le asigno la pelicula que obtuve x id
            var MovieDetailsViewModelByID = MapMovieDetailstoMovieDetailsViewModel(movieById, new MovieDetailsViewModel());

            //enviarlos a la vista
            return View(MovieDetailsViewModelByID);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(long Id)
        {
            //obtengo pelicula que quiero borrar
            var movieToDelete = this.session.Get<Movie>(Id);

            if (movieToDelete == null)
            {
                return this.NotFound();
            }

            //paso la pelicula a borrar al modeloVista
            return View(MapMovieDetailstoMovieDetailsViewModel(movieToDelete, new MovieDetailsViewModel()));
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(long Id)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var movieToDelete = this.session.Get<Movie>(Id);

                if (movieToDelete == null)
                {
                    return this.NotFound();
                }

                if (ModelState.IsValid)
                {
                    this.session.Delete(movieToDelete);

                    transaction.Commit();
                    this.TempData["Message"] = "Course deleted successfully!";
                }
            }

            //regresar a la pagina index de movies
            return RedirectToAction(nameof(MovieController.Index), "Movie");
        }

        // GET: Movie/Edit/{id}
        public ActionResult Edit(long Id)
        {
            var movie = this.session.Get<Movie>(Id);
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
            using (var transaction = this.session.BeginTransaction())
            {
                //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula editada
                var editedMovieEntity = this.session.Get<Movie>(editedMovie.Id);

                if (editedMovie == null)
                {
                    throw new ArgumentNullException(nameof(editedMovie));
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //paso esa pelicula de tipo ViewModel a una pelicula de tipo MovieEntity
                        editedMovieEntity = MapMovieDetailsViewModelToMovieModel(editedMovieEntity, editedMovie);

                        transaction.Commit();
                        return this.RedirectToAction();
                    }
                    catch (Exception ex)
                    {
                        this.ModelState.AddModelError("", "Error updating movie: " + ex.Message);
                    }
                }
            }

            return View(editedMovie);
        }

        /*
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
        }*/
    }
}
