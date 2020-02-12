using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public class MovieViewModel
    {
        //id, name, flyerUrl
        public long Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public string FlyerUrl
        {
            get;
            set;
        }

    }
}
