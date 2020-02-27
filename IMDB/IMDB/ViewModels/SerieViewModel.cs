using IMDB.Web.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Nationality Nationality
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
