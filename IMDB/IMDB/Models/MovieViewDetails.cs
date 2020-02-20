using Proyect_Models;
using Repository;
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
		
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ReleaseDate
		{
			get;
			set;
		}

		public List<Role> Characters
		{
			get;
			set;
		}

		public string FlyerUrl
		{
			get;
			set;
		}

		public String CharacterName
		{
			get;
			set;
		}

		public List<Actor> actorsInStorage
		{
			get;
			set;
		}

		public String ActorID
		{
			get;
			set;
		}

		public MovieViewDetails() { }
		public MovieViewDetails(List<Actor> allActors) {
			actorsInStorage = new List<Actor>();
		}

		
	}
}
