using ContosoUniversity.Services.Contracts.Exceptions;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IMDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService movieService;
        private ICharacterService characterService;

        public MovieController(IMovieService movieService, ICharacterService characterService)
        {
            this.movieService = movieService;
            this.characterService = characterService;
        }

        //obtener listado de peliculas
        [HttpGet]
        [Route("Index")]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            try
            {
                var allMovies = movieService.GetAllMovies();
                return Ok(allMovies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{movieId}/Details/")]
        public ActionResult<MovieDto> GetById(long movieId)
        {
            if (movieId <= 0)
            {
                return BadRequest("Movie Id is invalid");
            }
            try
            {
                var movieById = movieService.GetMovieById(movieId);
                return Ok(movieId);
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

        [HttpPost]
        [Route("Create")]
        public ActionResult<long> CreateMovie(MovieDto newMovieDto)
        {
            if (newMovieDto == null)
            {
                return BadRequest("Invalid movie");
            }

            try
            {
                var savedMovieId = movieService.SaveMovie(newMovieDto);
                var createdResourse = string.Format("{0}{1}", Request.GetDisplayUrl(), savedMovieId);

                return Created(new Uri(createdResourse), savedMovieId);//created: status ok 201!
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("{movieId}/Update")]
        public ActionResult<long> Update(MovieDto movieToEdit)
        {
            if (movieToEdit == null)
            {
                return BadRequest("invalid movie");
            }

            try
            {
                var updatedMovieId = movieService.UpdateMovie(movieToEdit);
                return Ok(updatedMovieId);
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

        [HttpDelete]
        [Route("Delete/{movieId}")]
        public ActionResult Delete(long movieId)
        {
            if (movieId <= 0)
            {
                return BadRequest("Movie id is invalid");
            }
            try
            {
                var movieWasRemoved = movieService.RemoveMovie(movieId);
                if (movieWasRemoved)
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

        [HttpGet]
        [Route("{movieId}/Characters")]
        public ActionResult<IEnumerable<CharacterDTO>> GetCharacters(long movieId)
        {
            if (movieId <= 0)
            {
                return BadRequest("Movie Id is invalid");
            }
            try
            {
                var allcharacters = characterService.GetCharacters(movieId);
                return Ok(allcharacters);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{movieId}/Characters/{characterId}")]
        public ActionResult<CharacterDTO> GetCharacterById(long characterId)
        {
            //verifico q el id exista
            if (characterId <= 0)
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

        //el update no funciona correctamente, en lugar de actualizar un personaje existente crea uno nuevo
        [HttpPut]
        [Route("{movieId}/Characters/{characterId}/Edit")]
        public ActionResult<CharacterDTO> UpdateCharacter(CharacterDTO updatedCharacter)
        {
            //valido id
            if (updatedCharacter == null)
            {
                return BadRequest("Character Id is invalid");
            }

            // obtengo personaje con info editada
            try
            {
                this.characterService.UpdateCharacter(updatedCharacter);
                return Ok(updatedCharacter);
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
            //devuelvo ese personaje ya editado
        }

        [HttpPost]
        [Route("{movieId}/Characters/Create")]
        public ActionResult<long> CreateCharacter(CharacterDTO newCharacterDto)
        {
            if (newCharacterDto == null)
            {
                throw new ArgumentNullException(nameof(newCharacterDto));
            }

            try
            {
                var savedCharacterId = characterService.SaveCharacter(newCharacterDto);
                var createdResourse = string.Format("{0}{1}", Request.GetDisplayUrl(), savedCharacterId);

                return Created(new Uri(createdResourse), savedCharacterId);//created: status ok 201!
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{movieId}/Characters/{characterId}/Delete")]
        public ActionResult<bool> DeleteCharacter(long characterId)
        {
            if (characterId <= 0)
            {
                return BadRequest("Movie id is invalid");
            }
            try
            {
                var characterWasRemoved = characterService.RemoveCharacter(characterId);
                if (characterWasRemoved)
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
    }
}
