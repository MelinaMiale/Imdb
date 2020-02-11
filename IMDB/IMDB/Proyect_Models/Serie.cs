using System;
using System.Collections.Generic;

namespace Proyect_Models
{
	public class Serie
	{
		public long ID_Serie
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

		public List<Rol> Characters
        {
			get;
			set;
        }

		//poster caps
		public List<Chapter> Chapters
        {
			get;
			set;
        }

		public int Fyler
        {
			get;
			set;
        }

		public DateTime LaunchDate
        {
			get;
			set;
        }
		
		
		public Serie(){}
	}

}
