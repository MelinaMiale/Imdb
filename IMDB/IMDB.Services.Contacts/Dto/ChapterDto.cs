using System;

namespace IMDB.Services.Contacts.Dto
{
    public class ChapterDto
    {
        public long Id
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public float Duration
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public SerieDto Serie
        {
            get;
            set;
        }
    }
}
