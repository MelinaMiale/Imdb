using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface ISerieService
    {
        public IEnumerable<SerieDto> GetAllSeries();

        public SerieDto GetById(long serieId);

        public long SaveSerie(SerieDto newSerieDto);

        public bool DeleteSerie(long serieId);
    }
}
