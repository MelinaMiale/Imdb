using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IChapterService
    {
        public IEnumerable<ChapterDto> GetAllChapters(long serieId);

        public long SaveChapter(ChapterDto newChapter);

        public bool RemoveCharacter(long chapterId);

        public ChapterDto GetById(long chapterId);

        public ChapterDto UpdateChapter(ChapterDto updatedChapter);
    }
}
