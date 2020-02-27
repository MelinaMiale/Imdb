using System;

namespace IMDB.Web.EntityModel
{
    public class Chapter
    {
        public virtual long Id
        {
            get;
            set;
        }

        public virtual DateTime ReleaseDate
        {
            get;
            set;
        }

        public virtual float Duration
        {
            get;
            set;
        }

        public Chapter()
        {
        }
    }
}
