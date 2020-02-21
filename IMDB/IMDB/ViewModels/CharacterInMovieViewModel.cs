using IMDB.Web.EntityModel;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class CharacterInMovieViewModel
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

        public List<Actor> AvailableActors
        {
            get;
            set;
        }

        public int IdMovie
        {
            get;
            set;
        }

        public string IdActor { get; set; }
    }
}
