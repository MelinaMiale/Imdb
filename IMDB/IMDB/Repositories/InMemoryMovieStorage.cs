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


           CastMovie2.Add(rol1);
           CastMovie2.Add(rol2);
           CastMovie2.Add(rol3);
           CastMovie2.Add(rol4);
           CastMovie1.Add(rol5);
           CastMovie1.Add(rol6);
           CastMovie1.Add(rol7);
           CastMovie1.Add(rol8);

           //peliculas
           Movie movie2 = new Movie(2, "Escape Plan", CastMovie1);
           Movie movie1 = new Movie(1, "BridgetJones Diary", CastMovie2);

           return new List<Movie> { movie1, movie2 };
       }

    }


}
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       

        
