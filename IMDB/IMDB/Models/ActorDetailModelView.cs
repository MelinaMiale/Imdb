using Proyect_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.Models
{
    public class ActorDetailModelView
    {
		public int ProfileFoto
		{
			get;
			set;
		}
		public long ID_Actor
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
		[Required]
		public string LastName
		{
			get;
			set;
		}
		[Required]
		public Nationality Nationality
		{
			get;
			set;
		}
		[Required]
		public int Age
		{
			get;
			set;
		}

		public List<Rol> RolsPlayed
		{
			get;
			set;
		}

	}
}
