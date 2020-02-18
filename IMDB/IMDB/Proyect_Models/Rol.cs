using System;
using System.Collections.Generic;

namespace Proyect_Models
{

	public class Rol
	{
		public long ID_Rol
        {
			get;
			set;
        }

		public string CharacterName
        {
			get;
			set;
        }

		//public long ID_Actor
		//{
		//	get;
		//	set;
		//}

		//public long ID_Pelicula
		//{
		//	get;
		//	set;
		//}

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



		public Rol(long Id, string character, Movie movie){
			this.ID_Rol = Id;
			this.CharacterName = character;
			this.Movie = movie;
		}

		public Rol() { }

	}

}
