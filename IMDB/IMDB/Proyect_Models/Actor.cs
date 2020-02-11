using System;
using System.Collections.Generic;

namespace Proyect_Models
{

	public class Actor
	{

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

		public List<Rol> RolsPlayed
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

		public int ProfileFoto
        {
			get;
			set;
        }

		public Actor() { 
			
		
		}

	
	}

}


