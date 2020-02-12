using Proyect_Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    //aqui implemento mi interfaz reposity
    public class InMemoryMovieStorage : IRepository

    {
       public InMemoryMovieStorage(){}

           public List<Movie> GetAll()
           {
               
               //Lista de roles
               Rol rol5 = new Rol(5, "Emil Rottmayer");
               Rol rol6 = new Rol(6, "Ray Breslin");
               Rol rol7 = new Rol(7, "Hobbes");
               Rol rol8 = new Rol(8, "Dr. Kyrie");
               List<Rol> CastMovie1 = new List<Rol>();

               Rol rol1 = new Rol(1, "BridgetJones");
               Rol rol2 = new Rol(2, "Mark Darcy");
               Rol rol3 = new Rol(3, "Daniel Cleaver");
               Rol rol4 = new Rol(4, "Bridget's Mum");
               List<Rol> CastMovie2 = new List<Rol>();

               CastMovie1.Add(rol1);
               CastMovie1.Add(rol2);
               CastMovie1.Add(rol3);
               CastMovie1.Add(rol4);
               CastMovie2.Add(rol5);
               CastMovie2.Add(rol6);
               CastMovie2.Add(rol7);
               CastMovie2.Add(rol8);
              

               //peliculas
               Movie movie1 = new Movie(1, "BridgetJones Diary");
               DateTime Movie1ReleaseDate = new DateTime(2001, 4, 4);
               movie1.ReleaseDate = Movie1ReleaseDate;
               movie1.Flyer = "http://www.impawards.com/2001/posters/bridget_joness_diary_ver1.jpg";
               movie1.Nationality = Nationality.american;
               movie1.Cast = CastMovie1;

               Movie movie2 = new Movie(2, "Escape Plan");
               DateTime Movie2ReleaseDate = new DateTime(2013, 10, 31);
               movie2.ReleaseDate = Movie2ReleaseDate;
               movie2.Flyer = "https://images-na.ssl-images-amazon.com/images/I/71DKbhlrU1L._AC_SL1008_.jpg";
               movie2.Nationality = Nationality.american;
               movie2.Cast = CastMovie2;

            return new List<Movie> { movie1, movie2 };
           }

        public Movie GetById(long Id)
        {
            throw new NotImplementedException();
        }

        

    }


}
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       

        
