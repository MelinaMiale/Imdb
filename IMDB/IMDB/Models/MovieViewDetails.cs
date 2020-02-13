using Proyect_Models;
using System;
using System.Collections.Generic;
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

		public List<Rol> Cast
		{
			get;
			set;
		}

		public DateTime ReleaseDate
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
