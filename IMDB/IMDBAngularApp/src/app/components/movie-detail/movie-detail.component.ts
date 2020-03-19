import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/classes/movie';
import { MovieService } from 'src/app/services/movie.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {
  movieById: Movie;

  constructor(
    private movieService: MovieService,
    private route: ActivatedRoute,
    ) { }

  ngOnInit(): void { this.getMovieById(); }

  getMovieById(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    this.movieService.getMovieById(id).subscribe(movie => this.movieById = movie);
  }

}
