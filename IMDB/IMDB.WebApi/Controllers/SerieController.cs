using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Services.Contracts.Exceptions;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebApi.Controllers
{
    //comentario de prueba

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
        [HttpGet]
        [Route("{serieId}/Details")]
        public ActionResult<SerieDto> GetSerieById(long serieId)
        {
            if (serieId <= 0)
            {
                return BadRequest("Id is not valid");
            }
            try
            {
                var serieById = serieService.GetById(serieId);
                return Ok(serieById);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //alta serie
        [HttpPost]
        [Route("Create")]
        public ActionResult<long> SaveSerie(SerieDto newSerie)
        {
            if (newSerie == null)
            {
                return BadRequest(StatusCodes.Status406NotAcceptable);
            }
            try
            {
                var serieId = this.serieService.SaveSerie(newSerie);
                return Ok(serieId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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
