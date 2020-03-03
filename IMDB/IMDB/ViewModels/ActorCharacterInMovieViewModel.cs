using IMDB.EntityModels;
using System.Collections.Generic;

namespace IMDB.Web.Controllers
{
    public class ActorCharacterInMovieViewModel
    {
        public long Id
        {
            get;
            set;
        }

        public IList<Character> Characters
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
    }
}
