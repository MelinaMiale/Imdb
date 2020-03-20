import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Movie } from '../classes/movie';
import { MOVIES } from '../mock-movies';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class MovieService {

  private moviesUrl= '/api/Movie/index';

  constructor(private http: HttpClient) {
   }

  getMovies(): Observable<Movie[]>{
    return this.http.get<Movie[]>(this.moviesUrl);
  }

  getMovieById(id: number): Observable<Movie>{
    return of(MOVIES.find(movie => movie.id === id));
  }

}
