using IMDB.Web.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.ViewModels
{
    public class CharacterViewModel
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

        public Movie Movie
        {
            get;
            set;
        }

        public CharacterViewModel()
        {
            AvailableActors = new List<Actor>();
        }
    }
}
