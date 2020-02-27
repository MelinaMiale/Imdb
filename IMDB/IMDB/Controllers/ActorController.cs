﻿using IMDB.Web.EntityModel;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Web.Controllers
{
    public class ActorController : Controller
    {
        private IStorage db;

        public ActorController(IStorage repository)
        {
            db = repository;
        }

        //metodo que copia la informacion de un objeto de tipo Actor a un objeto de tipo ActorViewModel, y devuelve este ultimo
        private ActorViewModel MapActortoActorViewModel(Actor actor, ActorViewModel actorViewModel)
        {
            actorViewModel.Id = actor.Id;
            actorViewModel.FirstName = actor.FirstName;
            actorViewModel.LastName = actor.LastName;

            return actorViewModel;
        }

        private ActorDetailViewModel MapActorDetail_toActorDetailViewModel(Actor actor, ActorDetailViewModel actorDetailVM)
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

        private Actor MapActorDetailVM_toActorDetail(Actor actor, ActorDetailViewModel actorDetailVM)
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

        private ActorCharacterInMovieViewModel MapActorEntityToActorCharacterInMovieViewModel(Actor actor, ActorCharacterInMovieViewModel actorCharacterInMovieViewModel)
        {
            actorCharacterInMovieViewModel.Id = actor.Id;
            actorCharacterInMovieViewModel.Characters = actor.Characters;
            actorCharacterInMovieViewModel.ProfileFoto = actor.ProfileFoto;

            return actorCharacterInMovieViewModel;
        }

        private Character MapCharacterViewModelToCharacterEntity(Character characterEntity, CharacterPlayedByActorViewModel characterViewModel)
        {
            characterEntity.Id = characterViewModel.Id;
            characterEntity.IdMovie = Convert.ToInt32(characterViewModel.MovieId);
            //  characterEntity.Actor = characterViewModel.;
            characterEntity.Name = characterViewModel.Name;
            // characterViewModel.AvailableMovies = db.GetAllMovies();

            return characterEntity;
        }

        // listar todos los actores
        public ActionResult Index()
        {
            //obtengo lita de actores guardadas en storage
            var actorsInStorage = db.GetAllActors();

            //crear una lista en base al modelo MovieViewModel
            var actorViewModelList = new List<ActorViewModel>();

            //paso cada actor de la lista de actores a actor view model y lo agrego a la lista de ese tipo
            foreach (var actor in actorsInStorage)
            {
                actorViewModelList.Add(MapActortoActorViewModel(actor, new ActorViewModel()));
            }

            return View(actorViewModelList);
        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {
            //obtener pelicula de la base de datos
            var actorById = db.GetActorbyId(id);

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
            var newActor = new Actor();
            MapActorDetailVM_toActorDetail(newActor, newActorVM);

            db.SaveActor(newActor);

            return RedirectToAction(nameof(ActorController.Index), "Home");
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            var actor = db.GetActorbyId(id);
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
            var actor = db.GetActorbyId(editedActor.Id);

            //paso actor de tipo VM a uno de tipo entity
            actor = MapActorDetailVM_toActorDetail(actor, editedActor);

            if (ModelState.IsValid)
            {
                db.UpdateActor(actor);
            }

            return View(MapActorDetail_toActorDetailViewModel(actor, editedActor));
        }

        // GET: Actor/Delete/5
        [Route("Actor/Delete/{actorId}")]
        public ActionResult Delete(int actorId)
        {
            //obtengo actor que quiero borrar
            var actorTodelete = db.GetActorbyId(actorId);
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
        public ActionResult DeletePost(int actorId)
        {
            var actorToDelete = db.GetActorbyId(actorId);

            //if (ModelState.IsValid)
            {
                db.DeleteActor(actorToDelete);
            }

            return RedirectToAction(nameof(ActorController.Index), "Home");
        }

        [Route("Actor/Characters/{actorId}")]
        [ActionName("Characters")]
        public ActionResult Characters(int actorId)
        {
            var actor = db.GetActorbyId(actorId);

            actor.Id = actorId;
            // creo entidad viewmodel
            var actorCharacterInMovieViewModel = new ActorCharacterInMovieViewModel();

            //paso el actor a esa viewmodel
            actorCharacterInMovieViewModel = MapActorEntityToActorCharacterInMovieViewModel(actor, actorCharacterInMovieViewModel);
            //paso view model a la vista

            return View(actorCharacterInMovieViewModel);
        }

        [HttpGet]
        public ActionResult CreateCharacter(int id)
        {
            var characterViewModel = new CharacterPlayedByActorViewModel();
            characterViewModel.AvailableMovies = db.GetAllMovies();

            characterViewModel.IdActor = id;

            return View(characterViewModel);
        }

        [HttpPost]
        // [ActionName("CreateCharacter")]
        public ActionResult CreateCharacter(CharacterPlayedByActorViewModel newCharacter)
        {
            var actorId = newCharacter.IdActor;
            var characterEntity = new Character();
            characterEntity = MapCharacterViewModelToCharacterEntity(characterEntity, newCharacter);
            db.SaveRol(characterEntity, characterEntity.IdMovie, actorId);

            return RedirectToAction("Characters", new { id = actorId });
        }
    }
}
