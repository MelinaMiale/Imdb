using ContosoUniversity.Services.Contracts.Exceptions;
using IMDB.EntityModels;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using IMDB.Services.Mapping;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services
{
    public class ChapterServices : IChapterService
    {
        private ISession session;
        private IEntityMapper<Serie, SerieDto> serieMapper;
        private IEntityMapper<Chapter, ChapterDto> chapterMapper;

        public ChapterServices(ISession session, IEntityMapper<Serie, SerieDto> serieMapper, IEntityMapper<Chapter, ChapterDto> chapterMapper)
        {
            this.session = session;
            this.serieMapper = serieMapper;
            this.chapterMapper = chapterMapper;
        }

        public IEnumerable<ChapterDto> GetAllChapters(long serieId)
        {
            //capitulos de la serie
            var allChapters = this.session.Query<Chapter>().Where(capt => capt.Serie.Id == serieId);

            //paso a dto esos capitulos
            var allChaptersDto = new List<ChapterDto>();
            foreach (var chapter in allChapters)
            {
                allChaptersDto.Add(this.chapterMapper.ToDto(chapter, new ChapterDto()));
            }

            return allChaptersDto;
        }

        public long SaveChapter(ChapterDto newChapterDto)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //paso de dto a entity
                var newchapter = this.chapterMapper.ToModel(newChapterDto, new Chapter());

                //guardo en db
                this.session.Save(newchapter);
                this.session.Transaction.Commit();

                //devuelvo el id del nuevo character
                return newchapter.Id;
            }
        }

        public bool RemoveCharacter(long chapterId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //obtengo el personaje a borrar
                var chapterToDelete = this.session.Get<Chapter>(chapterId);

                if (chapterToDelete == null)
                {
                    throw new EntityNotFoundException(string.Format("movie with id: {0} was not found", chapterId));
                }

                this.session.Delete(chapterToDelete);
                this.session.Transaction.Commit();

                return true;
            }
        }
    }
}
