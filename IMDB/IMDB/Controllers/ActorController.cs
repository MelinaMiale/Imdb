using IMDB.EntityModels;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Linq;

namespace IMDB.Web.Controllers
{
    public class ActorController : Controller
    {
        private ISession session;

        public ActorController(ISession session)
        {
            this.session = session;
        }

        //metodo que copia la informacion de un objeto de tipo Actor a un objeto de tipo ActorViewModel, y devuelve este ultimo
        public ActorViewModel MapActortoActorViewModel(Actor actor, ActorViewModel actorViewModel)
        {
            actorViewModel.Id = actor.Id;
            actorViewModel.FirstName = actor.FirstName;
            actorViewModel.LastName = actor.LastName;

            return actorViewModel;
        }

        public ActorDetailViewModel MapActorDetail_toActorDetailViewModel(Actor actor, ActorDetailViewModel actorDetailVM)
        {
            actorDetailVM.Age = actor.Age;
            actorDetailVM.Id = actor.Id;
            actorDetailVM.FirstName = actor.FirstName;
            actorDetailVM.LastName = actor.LastName;
            actorDetailVM.Nationality = actor.Nationality;
            actorDetailVM.ProfileFoto = actor.ProfileFoto;
            //  actorDetailVM.Characters = actor.Characters;

            return actorDetailVM;
        }

        public Actor MapActorDetailViewModelToActorDetail(Actor actor, ActorDetailViewModel actorDetailVM)
        {
            actor.Age = actorDetailVM.Age;
            actor.Id = actorDetailVM.Id;
            actor.FirstName = actorDetailVM.FirstName;
            actor.LastName = actorDetailVM.LastName;
            actor.Nationality = actorDetailVM.Nationality;
            actor.ProfileFoto = actorDetailVM.ProfileFoto;
            // actor.Characters = actorDetailVM.Characters;

            return actor;
        }

        public ActorCharacterInMovieViewModel MapActorEntityToActorCharacterInMovieViewModel(Actor actor, ActorCharacterInMovieViewModel actorCharacterInMovieViewModel)
        {
            actorCharacterInMovieViewModel.Id = actor.Id;
            actorCharacterInMovieViewModel.Characters = actor.Characters;
            actorCharacterInMovieViewModel.FirstName = actor.FirstName;
            actorCharacterInMovieViewModel.LastName = actor.LastName;

            return actorCharacterInMovieViewModel;
        }

        private Character MapCharacterViewModelToCharacterEntity(Character characterEntity, CharacterPlayedByActorViewModel characterViewModel)
        {
            characterEntity.Id = characterViewModel.Id;
            characterEntity.Movie = characterViewModel.Movie;
            characterEntity.Actor = characterViewModel.Actor;
            characterEntity.Name = characterViewModel.Name;

            return characterEntity;
        }

        public SerieCharacters MapSerieCharactertoSerieCharacterInSerieViewModel(Serie serie, SerieCharacters serieCharactersViewModel)
        {
            serieCharactersViewModel.Id = serie.Id;
            serieCharactersViewModel.Name = serie.Name;
            serieCharactersViewModel.Characters = serie.Characters;

            return serieCharactersViewModel;
        }

        // listar todos los actores
        public ViewResult Index()
        {
            var actorsInStorage = this.session.Query<Actor>().ToList();

            var actors = actorsInStorage.Select(a => new ActorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName
            }).ToList();

            return View(actors);
        }

        // GET: Actor/Details/5
        public ActionResult Details(long Id)
        {
            //obtener pelicula de la base de datos
            var actorById = this.session.Get<Actor>(Id);

            if (actorById == null)
            {
                return this.NotFound();
            }

            //pasar esa pelicula a modelo de vista (crear ActorDetailViewModel)(crear metodo MapActorDetail_toActorDetailViewModel)
            var actorByIdDetailsMV = MapActorDetail_toActorDetailViewModel(actorById, new ActorDetailViewModel());

            return View(actorByIdDetailsMV);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActorDetailViewModel newActorVM)
        {
            if (newActorVM == null)
            {
                return this.NotFound();
            }

            using (var transaction = this.session.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    var newActor = MapActorDetailViewModelToActorDetail(new Actor(), newActorVM);

                    this.session.Save(newActor);
                    this.session.Transaction.Commit();
                }
            }

            return RedirectToAction(nameof(ActorController.Index), "Home");
        }

        // GET: Actor/Delete/5
        [Route("Actor/Delete/{actorId}")]
        public ActionResult Delete(long actorId)
        {
            //obtengo actor que quiero borrar
            var actorTodelete = this.session.Get<Actor>(actorId);

            if (actorTodelete == null)
            {
                return this.NotFound();
            }

            //paso el actor a borrar al modeloVista
            return View(MapActorDetail_toActorDetailViewModel(actorTodelete, new ActorDetailViewModel()));
        }

        // POST: Actor/Delete/5
        [HttpPost]
        [Route("Actor/Delete/{actorId}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(long actorId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var actorToDelete = this.session.Get<Actor>(actorId);

                if (actorToDelete == null)
                {
                    return this.NotFound();
                }

                if (ModelState.IsValid)
                {
                    this.session.Delete(actorToDelete);
                    transaction.Commit();
                }
            }
            return RedirectToAction(nameof(ActorController.Index), "Home");
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(long id)
        {
            var actor = this.session.Get<Actor>(id);
            if (actor == null)
            {
                return this.NotFound();
            }

            return View(MapActorDetail_toActorDetailViewModel(actor, new ActorDetailViewModel()));
        }

        // POST: Actor/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(ActorDetailViewModel editedActor)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var actor = this.session.Get<Actor>(editedActor.Id);

                if (editedActor == null)
                {
                    throw new ArgumentNullException(nameof(editedActor));
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        actor = MapActorDetailViewModelToActorDetail(actor, editedActor);
                        transaction.Commit();
                        //   return RedirectToAction(Nameof(ActorController.Index), "Actor");
                    }
                    catch (Exception ex)
                    {
                        this.ModelState.AddModelError("", "Error updating movie: " + ex.Message);
                    }
                }
            }
            return RedirectToAction(nameof(ActorController.Index), "Actor");
        }

        [Route("Actor/Characters/{actorId}")]
        [ActionName("Characters")]
        public ActionResult Characters(long actorId)
        {
            var actor = this.session.Get<Actor>(actorId);

            // creo entidad viewmodel
            var actorCharacterInMovieViewModel = new ActorCharacterInMovieViewModel();

            //paso el actor a esa viewmodel
            actorCharacterInMovieViewModel = MapActorEntityToActorCharacterInMovieViewModel(actor, actorCharacterInMovieViewModel);
            //paso view model a la vista

            return View(actorCharacterInMovieViewModel);
        }

        [HttpGet]
        public ActionResult CreateCharacter(long id)
        {
            var characterViewModel = new CharacterPlayedByActorViewModel();

            characterViewModel.AvailableMovies = this.session.Query<Movie>().ToList();

            characterViewModel.Actor = this.session.Get<Actor>(id);

            return View(characterViewModel);
        }

        [HttpPost]
        // [ActionName("CreateCharacter")]
        public ActionResult CreateCharacter(CharacterPlayedByActorViewModel newCharacter)
        {
            if (newCharacter == null)
            {
                throw new ArgumentNullException(nameof(newCharacter));
            }

            using (var transaction = this.session.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var newRoleEntity = new Character();
                        newRoleEntity = MapCharacterViewModelToCharacterEntity(newRoleEntity, newCharacter);
                        this.session.Save(newRoleEntity);
                        this.session.Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "Error updating movie: " + ex.Message);
                }
            }

            return RedirectToAction("Characters", new { id = newCharacter.Actor.Id });
        }
    }
}
