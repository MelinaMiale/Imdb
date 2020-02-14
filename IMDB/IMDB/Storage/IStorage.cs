﻿using Proyect_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStorage

    {
        //lista todos las peliculas
        public List<Movie> GetAll();

        public Movie GetById(long Id);

        public Movie Update(Movie updatedMovie);

        public void Save(Movie editedMovie);

        public void Delete(Movie deletedMovie);

       

    }


}
