using IMDB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.ViewModels
{
    public class SerieCharacters
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

        public IList<Character> Characters
        {
            get;
            set;
        }
    }
}
