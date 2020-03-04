using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Web.ViewModels
{
    public class SerieDetailViewModel
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

        public string Nationality
        {
            get;
            set;
        }

        public string Poster
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate
        {
            get;
            set;
        }
    }
}
