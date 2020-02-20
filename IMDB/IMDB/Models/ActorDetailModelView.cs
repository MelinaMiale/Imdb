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
		public string Name
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
		public Nationality Nationality
		{
			get;
			set;
		}
		public int Age
		{
			get;
			set;
		}
		public List<Role> RolsPlayed
		{
			get;
			set;
		}

	}
}
