using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Services.Contracts.Exceptions;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
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
    }
}
