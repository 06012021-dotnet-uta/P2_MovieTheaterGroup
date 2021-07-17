import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Theater } from '../../interfaces/theater';
import { TheaterService } from '../../services/theater.service';
import { Movie } from '../../interfaces/movie';

@Component({
  selector: 'app-theater-details',
  templateUrl: './theater-details.component.html',
  styleUrls: ['./theater-details.component.css']
})
export class TheaterDetailsComponent implements OnInit {

  theater!: Theater;
  movies?: Movie[];
  id: number = parseInt(this.route.snapshot.paramMap.get('id')!, 10);

  constructor(
    private route: ActivatedRoute,
    private theaterService: TheaterService,
    private location: Location) { }

  ngOnInit(): void {
    this.getMovies();
    this.getTheater();
  }

  getMovies(): void {
    this.theaterService.getTheaterMovies(this.id).subscribe(
      movies => this.movies = movies
    );
  }

  getTheater(): void {
    this.theaterService.getTheater(this.id).subscribe(
      theater => this.theater = theater
    );
  }

  goBack(): void {
    this.location.back();
  }

}
