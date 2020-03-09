﻿using ContosoUniversity.Services.Contracts.Exceptions;
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

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
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
        [Route("CreateNew")]
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
    }
}
