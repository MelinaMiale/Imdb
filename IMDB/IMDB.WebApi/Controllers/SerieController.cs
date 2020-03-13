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
        [HttpDelete]
        [Route("{serieId}/Delete")]
        public ActionResult DeleteSerie(long serieId)
        {
            if (serieId <= 0)
            {
                return BadRequest("Serie id is not valid");
            }
            try
            {
                var serieWasRemoved = this.serieService.DeleteSerie(serieId);
                if (serieWasRemoved)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
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

        //modificacion serie
        [HttpPut]
        [Route("{serieId}/Edit")]
        public ActionResult<long> UpdateSerie(SerieDto editedSerie)
        {
            if (editedSerie == null)
            {
                return BadRequest("Invalid serie");
            }
            try
            {
                var updatedSerieId = serieService.UpdateSerie(editedSerie);
                return Ok(updatedSerieId);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (BadRequestException bex)
            {
                return BadRequest(bex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //listado personajes
        [HttpGet]
        [Route("{serieId}/Characters")]
        public ActionResult<IEnumerable<CharacterDTO>> GetCharacters(long serieId)
        {
            if (serieId <= 0)
            {
                return BadRequest("Movie Id is invalid");
            }
            try
            {
                var allcharacters = characterService.GetSerieCharacters(serieId);
                return Ok(allcharacters);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //alta rol
        [HttpPost]
        [Route("{serieId}/CreateCharacter")]
        public ActionResult<long> SaveCharacter(CharacterDTO newCharacter)
        {
            if (newCharacter == null)
            {
                return BadRequest("The character is not valid");
            }

            try
            {
                var newCharacterId = this.characterService.SaveCharacter(newCharacter);
                return Ok(newCharacter);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //baja rol
        [HttpDelete]
        [Route("{serieId}/Characters/{characterId}/Delete")]
        public ActionResult DeleteCharacter(long characterId)
        {
            if (characterId <= 0)
            {
                return BadRequest("Id is invalid");
            }

            try
            {
                var characterWasDeleted = this.characterService.RemoveCharacter(characterId);
                if (characterWasDeleted)
                {
                    return Ok(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
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

        //rol by id
        [HttpGet]
        [Route("{serieId}/Characters/{characterId}")]
        public ActionResult<CharacterDTO> GetCharacterById(long characterId)
        {
            //verifico q el id exista
            if (characterId < 0)
            {
                return BadRequest("Character Id is invalid");
            }
            try //obtengo personaje
            {
                var characterById = characterService.GetCharacterById(characterId);
                return Ok(characterById);
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

        //modificacion rol
        [HttpPut]
        [Route("{serieId}/Characters/{characterId}/Edit")]
        public ActionResult<long> UpdateCharacter(CharacterDTO updatedCharacter)
        {
            if (updatedCharacter == null)
            {
                return BadRequest("Character Id is invalid");
            }

            try
            {
                var editedCharacterId = characterService.UpdateCharacter(updatedCharacter);
                return Ok(editedCharacterId);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (BadRequestException bex)
            {
                return BadRequest(bex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //listado capitulos
        //capitulo by id
        //alta capitulos
        //baja capitulos
        //modificacion capitulos
    }
}
