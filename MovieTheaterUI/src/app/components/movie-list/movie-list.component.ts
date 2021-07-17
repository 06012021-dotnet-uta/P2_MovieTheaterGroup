import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/interfaces/movie';
import { MovieServiceService } from 'src/app/services/movie.service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  movies?: Movie[];
  selectedMovie?: Movie;

  constructor(private movieService: MovieServiceService) { }

  onSelect(movie: Movie): void {
    this.selectedMovie = movie;
  }

  ngOnInit(): void {
    this.movieService.getMovies()
    .subscribe
    (
      data=>
      {
        console.log(data);
        this.movies = data;
      }
    );
  }

}
