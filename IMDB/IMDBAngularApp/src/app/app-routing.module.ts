import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MoviesComponent } from './components/movies/movies.component';
import { MovieDetailComponent } from './components/movies/movie-detail/movie-detail.component';
import { CreateMovieComponent } from './components/movies/create-movie/create-movie.component';


const routes: Routes = [
  { path: 'movies', component: MoviesComponent},
  { path: 'detail/:id', component: MovieDetailComponent },
  { path: 'create', component: CreateMovieComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
