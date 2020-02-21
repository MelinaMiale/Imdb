using IMDB.Web.EntityModel;
using System.Collections.Generic;

namespace IMDB.Web.Controllers
{
    public class ActorCharacterViewModel
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
    }
}
