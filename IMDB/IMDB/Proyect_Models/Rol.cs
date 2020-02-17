using System;

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

		public long ID_Actor
		{
			get;
			set;
		}

		public long ID_Pelicula
		{
			get;
			set;
		}

		public Rol(long Id, string character, long idPelicula){
			this.ID_Rol = Id;
			this.CharacterName = character;
			this.ID_Pelicula = idPelicula;
		}

	}

}
