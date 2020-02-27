using IMDB.Web.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.ViewModels
{
    public class MovieCharacterViewModel
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

        public int Actorid
        {
            get;
            set;
        }

        public List<Character> Characters
        {
            get;
            set;
        }

        public int MovieId
        {
            get;
            set;
        }
    }
}
