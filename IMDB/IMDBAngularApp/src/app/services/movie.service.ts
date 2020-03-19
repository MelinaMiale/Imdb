import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Movie } from '../classes/movie';
import { MOVIES } from '../mock-movies';

@Injectable({
  providedIn: 'root'
})

export class MovieService {

  constructor() { }

  getMovies(): Observable<Movie[]>{
    return of(MOVIES);
  }

}
