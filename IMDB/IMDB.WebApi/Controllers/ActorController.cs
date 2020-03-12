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
    public class ActorController : ControllerBase
    {
        private IActorService actorService;
        private ICharacterService characterService;

        public ActorController(IActorService actorService, ICharacterService characterService)
        {
            this.actorService = actorService;
            this.characterService = characterService;
        }

        //listado de actores
        [HttpGet]
        [Route("Index")]
        public ActionResult<IEnumerable<ActorDto>> GetAllActors()
        {
            try
            {
                var allActors = actorService.GetAllActors();
                return Ok(allActors);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //detalle de un actor (getById)
        [HttpGet]
        [Route("{actorId}/Details")]
        public ActionResult<ActorDto> GetById(long actorId)
        {
            if (actorId <= 0)
            {
                return BadRequest("Actor id was not found");
            }
            try
            {
                var actorById = actorService.GetActorById(actorId);
                return Ok(actorId);
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

        //crear un actor
        [HttpPost]
        [Route("Create")]
        public ActionResult<long> SaveActor(ActorDto newActor)
        {
            if (newActor == null)
            {
                return BadRequest("Invalid actor");
            }

            try
            {
                var savedActorId = actorService.SaveActor(newActor);
                var createdResource = string.Format("{0}{1}", Request.GetDisplayUrl(), savedActorId);

                return Created(new Uri(createdResource), savedActorId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //editar actor
        [HttpPut]
        [Route("{actorId}/Edit")]
        public ActionResult<long> Update(ActorDto editedActorDto)
        {
            if (editedActorDto == null)
            {
                return BadRequest("Invalid actor");
            }
            try
            {
                var updatedActorId = actorService.UpdateActor(editedActorDto);
                return Ok(updatedActorId);
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

        //borrar un actor
        [HttpDelete]
        [Route("{actorId}/Delete")]
        public ActionResult<bool> Delete(long actorId)
        {
            if (actorId <= 0)
            {
                return BadRequest("Movie id is invalid");
            }

            try
            {
                var actorWasRemoved = actorService.RemoveActor(actorId);
                if (actorWasRemoved)
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

        //listo personajes
        [HttpGet]
        [Route("{actorId}/Characters")]
        public ActionResult<IEnumerable<CharacterDTO>> GetCharacters(long actorId)
        {
            //verifico id
            if (actorId <= 0)
            {
                return BadRequest("Id is not valid");
            }

            try
            {
                //obtengo lista de personajesDto
                var allCharacters = characterService.GetActorCharacters(actorId);

                //devuelvo la lista
                return Ok(allCharacters);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{actorId}/Characters/{characterId}")]
        public ActionResult<CharacterDTO> GetCharacterById(long characterId)
        {
            if (characterId <= 0)
            {
                return BadRequest("Character id not valid");
            }

            try
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

        [HttpPost]
        [Route("{actorId}/Characters/Create")]
        public ActionResult<long> CreateCharacter(CharacterDTO newCharacterDto)
        {
            //evaluo el personaje
            if (newCharacterDto == null)
            {
                throw new ArgumentNullException(nameof(newCharacterDto));
            }
            try
            {
                //llamo al servicio para guardar el personaje en bd
                //regreso ok con el id del nuevo personaje
                var savedCharacterId = characterService.SaveCharacter(newCharacterDto);
                var createdResource = string.Format("{0}{1}", Request.GetDisplayUrl(), savedCharacterId);

                return Ok(savedCharacterId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{actorId}/Characters/{characterId}/Delete")]
        public ActionResult<bool> DeleteCharacter(long characterId)
        {
            //valido role id
            if (characterId <= 0)
            {
                return BadRequest("Id not valid");
            }
            try
            {
                //utilizo servicio para borrar personaje
                //devuelvo ok si se borro con exito
                var characterWasDeleted = characterService.RemoveCharacter(characterId);
                if (characterWasDeleted)
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

        [HttpPut]
        [Route("{actorId}/Characters/{characterId}/Edit")]
        public ActionResult<long> UpdateCharacter(CharacterDTO updatedCharacter)
        {
            if (updatedCharacter == null)
            {
                return BadRequest("Character not valid");
            }
            // obtengo personaje con info editada
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
    }
}
