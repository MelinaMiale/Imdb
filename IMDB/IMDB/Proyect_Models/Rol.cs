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

		public string Character
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

		public Rol(){}

	}

}
