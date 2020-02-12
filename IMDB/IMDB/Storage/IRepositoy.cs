using Proyect_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        //lista todos las peliculas
        public List<Movie> GetAll();

        public Movie GetById(long Id);

        //public IEnumerable<Movie> AllMovies { get; }
        /*

//busca y obtiene el objeto segun su id
public Movie GetByID(long id) { }

//metodo para contar objetos
public int Count() { }

public void Edit() { }

public void DeleteById() { }
*/

    }


}
