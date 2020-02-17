using Proyect_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public class MovieViewDetails
    {
		public long ID
		{
			get;
			set;
		}

		[Required]
		public string Name
		{
			get;
			set;
		}

		public Nationality Nationality
		{
			get;
			set;
		}

		public DateTime ReleaseDate
		{
			get;
			set;
		}

		public List<Rol> Characters
		{
			get;
			set;
		}

		public string FlyerUrl
		{
			get;
			set;
		}






		public MovieViewDetails() { }

		public MovieViewDetails(Movie movie) { }

		

	}
}
