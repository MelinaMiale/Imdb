using System;

namespace IMDB.Web.EntityModel
{
    public class Chapter
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

        public float duration
        {
            get;
            set;
        }

        public Chapter()
        {
        }
    }
}
