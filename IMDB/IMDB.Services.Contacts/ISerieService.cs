using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface ISerieService
    {
        public IEnumerable<SerieDto> GetAllSeries();
    }
}
