using System;

namespace IMDB.Web.ViewModels
{
    public class SerieViewModel
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Nationality
        {
            get;
            set;
        }

        public string Poster
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }
    }
}
