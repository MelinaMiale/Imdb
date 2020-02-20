using System;
using System.Collections.Generic;

namespace Proyect_Models
{

	public class Role
	{
		public long ID_Role
        {
			get;
			set;
        }

		public string CharacterName
        {
			get;
			set;
        }

		public Actor Actor
		{
			get;
			set;
		}

		public Movie Movie
		{
			get;
			set;
		}



		public Role(long Id, string character, Movie movie){
			this.ID_Role = Id;
			this.CharacterName = character;
			this.Movie = movie;
		}

		public Role() { }

	}

}
