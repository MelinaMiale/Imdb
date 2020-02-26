using IMDB.Web.EntityModel;
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

        public List<Character> Characters
        {
            get;
            set;
        }

        public string ProfileFoto
        {
            get;
            set;
        }

        public int ActorId
        {
            get;
            set;
        }
    }
}
