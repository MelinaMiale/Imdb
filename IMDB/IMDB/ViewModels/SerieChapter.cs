using IMDB.EntityModels;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class SerieChapter
    {
        public long Id
        {
            get;
            set;
        }

        public IList<Chapter> Chapters
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
