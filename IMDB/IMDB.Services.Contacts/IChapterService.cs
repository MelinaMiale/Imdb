using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IChapterService
    {
        public IEnumerable<ChapterDto> GetAllChapters(long serieId);
    }
}
