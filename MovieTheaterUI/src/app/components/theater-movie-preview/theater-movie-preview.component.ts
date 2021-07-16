import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Movie } from '../../interfaces/movie';
import { TheaterService } from '../../services/theater.service';
import { UrlService } from '../../services/url.service';

@Component({
  selector: 'app-theater-movie-preview',
  templateUrl: './theater-movie-preview.component.html',
  styleUrls: ['./theater-movie-preview.component.css']
})
export class TheaterMoviePreviewComponent implements OnInit {

  @Input() theaterId!: number;
  movies?: Movie[];

  constructor(private http: HttpClient, private url: UrlService,
    private theaterService: TheaterService) { }

  ngOnInit(): void {
    this.theaterService.getTheaterMovies(this.theaterId).subscribe(
      movies => this.movies = movies
    );
  }

}
