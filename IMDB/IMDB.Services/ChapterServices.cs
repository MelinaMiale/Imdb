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
    }
}
