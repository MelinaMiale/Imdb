import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/classes/movie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  movies: Movie[];

  constructor(private movieService : MovieService) { }

  ngOnInit(): void { this.movieService.getMovies().subscribe((movies: Movie[]) => (this.movies = movies)) }


}
