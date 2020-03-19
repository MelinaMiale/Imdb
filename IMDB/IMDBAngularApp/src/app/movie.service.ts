import { Injectable } from '@angular/core';
import { MOVIES } from './mock-movies';
import { Observable, of } from 'rxjs';
import { Movie } from './movie';

@Injectable({
  providedIn: 'root'
})

export class MovieService {

  constructor() { }

  getMovies(): Observable<Movie[]>{
    return of(MOVIES);
  }

}
