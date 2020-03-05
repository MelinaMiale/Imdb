using IMDB.EntityModels;
using System.Collections.Generic;

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
