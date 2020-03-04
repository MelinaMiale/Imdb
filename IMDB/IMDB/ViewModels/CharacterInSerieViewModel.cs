using IMDB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.ViewModels
{
    public class CharacterInSerieViewModel
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

        public Actor Actor
        {
            get;
            set;
        }

        public Serie Serie
        {
            get;
            set;
        }

        public IList<Actor> AvailableActors
        {
            get;
            set;
        }
    }
}
