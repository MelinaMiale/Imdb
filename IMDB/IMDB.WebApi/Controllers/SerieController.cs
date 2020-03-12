using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private ISerieService serieService;
        private ICharacterService characterService;

        public SerieController(ISerieService serieService, ICharacterService characterService)
        {
            this.serieService = serieService;
            this.characterService = characterService;
        }

        //listar series
        [HttpGet]
        [Route("Index")]
        public ActionResult<IEnumerable<SerieDto>> GetSeries()
        {
            try
            {
                var allSeriesDto = serieService.GetAllSeries();
                return Ok(allSeriesDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //serie by id

        //alta serie
        //baja serie
        //modificacion serie

        //listado personajes
        //alta rol
        //baja rol
        //modificacion rol

        //listado capitulos
        //capitulo by id
        //alta capitulos
        //baja capitulos
        //modificacion capitulos
    }
}
