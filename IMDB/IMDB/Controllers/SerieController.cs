using IMDB.EntityModels;
using IMDB.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Linq;

namespace IMDB.Web.Controllers
{
    public class SerieController : Controller
    {
        private ISession session;

        public SerieController(ISession session)
        {
            this.session = session;
        }

        public Serie MapSerieDetailsViewModelToSerieModel(Serie serie, SerieDetailViewModel serieDetailViewModel)
        {
            serie.Id = serieDetailViewModel.Id;
            serie.Name = serieDetailViewModel.Name;
            serie.Nationality = serieDetailViewModel.Nationality;
            serie.Poster = serieDetailViewModel.Poster;
            serie.ReleaseDate = serieDetailViewModel.ReleaseDate;

            return serie;
        }

        public SerieDetailViewModel MapSerieDetailsToSerieDetailsViewModel(Serie serie, SerieDetailViewModel serieViewModel)
        {
            serieViewModel.Id = serie.Id;
            serieViewModel.Name = serie.Name;
            serieViewModel.Nationality = serie.Nationality;
            serieViewModel.Poster = serie.Poster;
            serieViewModel.ReleaseDate = serie.ReleaseDate;

            return serieViewModel;
        }

        public SerieCharacters MapSerieCharactertoSerieCharacterInSerieViewModel(Serie serie, SerieCharacters serieCharactersViewModel)
        {
            serieCharactersViewModel.Id = serie.Id;
            serieCharactersViewModel.Name = serie.Name;
            serieCharactersViewModel.Characters = serie.Characters;

            return serieCharactersViewModel;
        }

        //metodo que uso para trabajar un personaje en particular
        private Character MapCharacterModelViewToCharacterEntity(Character characterEntity, CharacterInSerieViewModel characterInSerieViewModel)
        {
            characterEntity.Id = characterInSerieViewModel.Id;
            characterEntity.Serie = characterInSerieViewModel.Serie;
            characterEntity.Actor = characterInSerieViewModel.Actor;
            characterEntity.Name = characterInSerieViewModel.Name;

            return characterEntity;
        }

        private ChapterViewModel MapChaptertoChapterViewModel(Chapter chapter, ChapterViewModel chapterViewModel)
        {
            chapterViewModel.Id = chapter.Id;
            chapterViewModel.Name = chapter.Name;
            chapterViewModel.ReleaseDate = chapter.ReleaseDate;
            chapterViewModel.Serie = chapter.Serie;
            chapterViewModel.Duration = chapter.Duration;

            return chapterViewModel;
        }

        private SerieChapter MapSerieChaptertoSerieChapterInSerieViewModel(Serie serie, SerieChapter serieChapter)
        {
            serieChapter.Id = serie.Id;
            serieChapter.Name = serie.Name;
            serieChapter.Chapters = serie.Chapters;

            return serieChapter;
        }

        public Chapter MapChapterViewModelToChapterEntity(Chapter chapter, ChapterViewModel chapterViewModel)
        {
            chapter.Id = chapterViewModel.Id;
            chapter.Name = chapterViewModel.Name;
            chapter.ReleaseDate = chapterViewModel.ReleaseDate;
            chapter.Serie = chapterViewModel.Serie;
            chapter.Duration = chapterViewModel.Duration;

            return chapter;
        }

        public ActionResult Index()

        {
            //obtengo lita de series guardadas en storage
            var seriesInStorage = this.session.Query<Serie>().ToList();

            var serieViewModelList = seriesInStorage.Select(m => new SerieViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return View(serieViewModelList);
        }

        // GET: Serie/Create
        public ViewResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(SerieDetailViewModel newSerieViewModel)
        {
            if (newSerieViewModel == null)
            {
                throw new ArgumentNullException(nameof(newSerieViewModel));
            }

            using (var transaction = this.session.BeginTransaction())
            {
                if (ModelState.IsValid)
                {
                    var newEntitySerie = MapSerieDetailsViewModelToSerieModel(new Serie(), newSerieViewModel);

                    this.session.Save(newEntitySerie);

                    this.session.Transaction.Commit();

                    this.TempData["Message"] = "Movie saved succsessfully!";
                }
            }

            return RedirectToAction(nameof(SerieController.Index), "Home");
        }

        // GET: Serie/Details/5
        public ActionResult Details(long Id)
        {
            var serieById = this.session.Get<Serie>(Id);

            if (serieById == null)
            {
                return this.NotFound();
            }

            var serieDetailViewModel = MapSerieDetailsToSerieDetailsViewModel(serieById, new SerieDetailViewModel());

            return View(serieDetailViewModel);
        }

        // GET: Serie/Delete/5
        public ActionResult Delete(long Id)
        {
            var serieToDelete = this.session.Get<Serie>(Id);

            if (serieToDelete == null)
            {
                return this.NotFound();
            }

            return View(MapSerieDetailsToSerieDetailsViewModel(serieToDelete, new SerieDetailViewModel()));
        }

        // POST: Serie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(long Id)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var serieToDelete = this.session.Get<Serie>(Id);

                if (serieToDelete == null)
                {
                    return this.NotFound();
                }

                if (ModelState.IsValid)
                {
                    this.session.Delete(serieToDelete);

                    transaction.Commit();
                }
            }

            return RedirectToAction(nameof(SerieController.Index), "Serie");
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(long Id)
        {
            var serie = this.session.Get<Serie>(Id);
            if (serie == null)
            {
                return this.NotFound();
            }

            return View(MapSerieDetailsToSerieDetailsViewModel(serie, new SerieDetailViewModel()));
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(SerieDetailViewModel editedSerie)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //tomo la pelicula que tengo en db, la q tiene el mismo id que viene de la pelicula editada
                var serieEntity = this.session.Get<Serie>(editedSerie.Id);

                if (editedSerie == null)
                {
                    throw new ArgumentNullException(nameof(editedSerie));
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //paso esa pelicula de tipo ViewModel a una pelicula de tipo MovieEntity
                        serieEntity = MapSerieDetailsViewModelToSerieModel(serieEntity, editedSerie);

                        transaction.Commit();
                        return this.RedirectToAction();
                    }
                    catch (Exception ex)
                    {
                        this.ModelState.AddModelError("", "Error updating movie: " + ex.Message);
                    }
                }
            }

            return View(editedSerie);
        }

        //accion que lista personajes de una pelicula
        [Route("Serie/Characters/{Id}")]
        [ActionName("Characters")]
        public ActionResult Characters(long Id)
        {
            //obtengo serie
            var serie = this.session.Get<Serie>(Id);

            // creo serie de tipo viewmodel
            var serieViewModel = new SerieCharacters();

            //copio entidad a viewmodel
            serieViewModel = MapSerieCharactertoSerieCharacterInSerieViewModel(serie, serieViewModel);

            return View(serieViewModel);
        }

        // [Route("Serie/Characters/CreateCharacter")]
        [HttpGet]
        public ActionResult CreateCharacter(long idSerie)
        {
            var newCharacter = new CharacterInSerieViewModel();

            newCharacter.AvailableActors = this.session.Query<Actor>().ToList();
            newCharacter.Serie = this.session.Get<Serie>(idSerie);

            return View(newCharacter);
        }

        [HttpPost]
        public ActionResult CreateCharacter(CharacterInSerieViewModel newcharacter)
        {
            if (newcharacter == null)
            {
                throw new ArgumentNullException(nameof(newcharacter));
            }

            using (var transaction = this.session.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var newRoleEntity = new Character();
                        newRoleEntity = MapCharacterModelViewToCharacterEntity(newRoleEntity, newcharacter);
                        this.session.Save(newRoleEntity);
                        this.session.Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "Error updating role: " + ex.Message);
                }
            }

            return RedirectToAction("Characters", new { id = newcharacter.Serie.Id });
        }

        public ActionResult DeleteRol(int serieId, long rolId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var rolToDelete = this.session.Get<Character>(rolId);

                if (rolToDelete == null)
                {
                    return this.NotFound();
                }

                if (ModelState.IsValid)
                {
                    this.session.Delete(rolToDelete);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Characters", new { id = serieId });
        }

        //accion que lista caputulos de una pelicula
        [Route("Serie/Chapters/{Id}")]
        [ActionName("Chapters")]
        public ActionResult Chapters(long Id)
        {
            //obtengo serie
            var serie = this.session.Get<Serie>(Id);

            // creo serie de tipo viewmodel
            var serieViewModel = new SerieChapter();

            //copio entidad a viewmodel
            serieViewModel = MapSerieChaptertoSerieChapterInSerieViewModel(serie, serieViewModel);

            return View(serieViewModel);
        }

        [HttpGet]
        public ActionResult DeleteChapter(long chapterId)
        {
            var chapterToDelete = this.session.Get<Chapter>(chapterId);

            if (chapterToDelete == null)
            {
                return this.NotFound();
            }

            return View(MapChaptertoChapterViewModel(chapterToDelete, new ChapterViewModel()));
        }

        [HttpPost]
        [ActionName("DeleteChapterPost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChapterPost(long chapterId, long serieId)
        {
            var chapter = this.session.Get<Chapter>(chapterId);

            using (var transaction = this.session.BeginTransaction())
            {
                if (chapter == null)
                {
                    return this.NotFound();
                }

                if (ModelState.IsValid)
                {
                    this.session.Delete(chapter);
                    transaction.Commit();
                }
            }

            return RedirectToAction("Chapters", new { id = serieId });
        }

        [HttpGet]
        public ActionResult CreateChapter(long serieId)
        {
            var newChapter = new ChapterViewModel();

            newChapter.Serie = this.session.Get<Serie>(serieId);

            return View(newChapter);
        }

        [HttpPost]
        [ActionName("CreateChapterPost")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateChapter(ChapterViewModel newChapterViewModel, long serieId)
        {
            if (newChapterViewModel == null)
            {
                throw new ArgumentNullException(nameof(newChapterViewModel));
            }

            using (var transaction = this.session.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var newChapterEntity = MapChapterViewModelToChapterEntity(new Chapter(), newChapterViewModel);

                        this.session.Save(newChapterEntity);

                        this.session.Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "Error updating role: " + ex.Message);
                }
            }

            return RedirectToAction("Chapters", new { id = serieId });
        }
    }
}
