﻿using System;
using System.Collections.Generic;

namespace Proyect_Models
{ 
	public class Movie
	{
		public long ID_movie
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

		public Movie(long Id, string Name){
			this.ID_movie = Id;
			this.Name = Name;
			//this.Cast = Casting;
		}

		public Movie() { }

	}

}
