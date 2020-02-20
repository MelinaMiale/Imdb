using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyect_Models;
using Repository;

namespace IMDB.Web.Controllers
{
    public class ActorController : Controller
    {

        IStorage db;

        public ActorController (IStorage repository)
        {
            db = repository;
        }

        //metodo que copia la informacion de un objeto de tipo Actor a un objeto de tipo ActorViewModel, y devuelve este ultimo
        private ActorViewModel MapActortoActorViewModel(Actor actor, ActorViewModel actorViewModel)
        {
            actorViewModel.ID_Actor = actor.ID_Actor;
            actorViewModel.Name = actor.Name;
            actorViewModel.LastName = actor.LastName;

            return actorViewModel;
        }

        private ActorDetailModelView MapActorDetail_toActorDetailViewModel(Actor actor, ActorDetailModelView actorDetailVM)
        {
            actorDetailVM.Age = actor.Age;
            actorDetailVM.ID_Actor = actor.ID_Actor;
            actorDetailVM.Name = actor.Name;
            actorDetailVM.LastName = actor.LastName;
            actorDetailVM.Nationality = actor.Nationality;
            actorDetailVM.ProfileFoto = actor.ProfileFoto;
            actorDetailVM.RolsPlayed = actor.RolsPlayed;

            return actorDetailVM;
        }

        private Actor MapActorDetailVM_toActorDetail(Actor actor, ActorDetailModelView actorDetailVM)
        {
            actor.Age = actorDetailVM.Age;
            actor.ID_Actor = actorDetailVM.ID_Actor;
            actor.Name = actorDetailVM.Name;
            actor.LastName = actorDetailVM.LastName;
            actor.Nationality = actorDetailVM.Nationality;
            actor.ProfileFoto = actorDetailVM.ProfileFoto;
            actor.RolsPlayed = actorDetailVM.RolsPlayed;

            return actor;
        }


        // listar todos los actores
        public ActionResult Index()
        {
            //obtengo lita de actores guardadas en storage
            var actorsInStorage = db.GetAllActors();

            //crear una lista en base al modelo MovieViewModel
            var actorViewModelList = new List<ActorViewModel>();

            //paso cada actor de la lista de actores a actor view model y lo agrego a la lista de ese tipo 
            foreach(var actor in actorsInStorage)
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

            //pasar esa pelicula a modelo de vista (crear actorDetailModelView)(crear metodo MapActorDetail_toActorDetailViewModel)
            var actorByIdDetailsMV = MapActorDetail_toActorDetailViewModel(actorById, new ActorDetailModelView());

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
        public ActionResult Create(ActorDetailModelView newActorVM)
        {
            var newActor = new Actor();
            MapActorDetailVM_toActorDetail(newActor, newActorVM);

            db.SaveActor(newActor);

            return RedirectToAction(nameof(ActorController.Index), "Home");
        }


        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            return View(MapActorDetail_toActorDetailViewModel(actorTodelete, new ActorDetailModelView()));
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
    }
}