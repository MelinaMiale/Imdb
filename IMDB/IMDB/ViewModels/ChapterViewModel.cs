using IMDB.EntityModels;
using System;

namespace IMDB.Web.ViewModels
{
    public class ChapterViewModel
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

        public Serie Serie
        {
            get;
            set;
        }
    }
}
