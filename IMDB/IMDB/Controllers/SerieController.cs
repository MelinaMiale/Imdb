/*using IMDB.EntityModels;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace IMDB.Web.Controllers
{
    public class SerieController : Controller
    {
        private IStorage db;

        public SerieController(IStorage repository)
        {
            db = repository;
        }

        public ActionResult Index()
        {
            //obtengo lita de series guardadas en storage

            var seriesInStorage = db.GetAllSeries();

            //crear una lista en base al modelo MovieViewModel
            var serieViewModelList = new List<SerieViewModel>();

            //paso cada actor de la lista de actores a actor view model y lo agrego a la lista de ese tipo
            foreach (var serie in seriesInStorage)
            {
                serieViewModelList.Add(MapSerietoSerieViewModel(serie, new SerieViewModel()));
            }

            return View(serieViewModelList);
        }

        public SerieViewModel MapSerietoSerieViewModel(Serie serie, SerieViewModel serieViewModel)
        {
            serieViewModel.Id = serie.Id;
            serieViewModel.Name = serie.Name;
            serieViewModel.Nationality = serie.Nationality;
            serieViewModel.Poster = serie.Poster;
            serieViewModel.ReleaseDate = serie.ReleaseDate;

            return serieViewModel;
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Serie/Edit/5
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

        // GET: Serie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Serie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
*/
