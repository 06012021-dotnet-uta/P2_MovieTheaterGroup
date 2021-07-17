import { Component, OnInit } from '@angular/core';
// import { freeApiService } from '../services/freeapi.service';

// import { Movie } from '../classes/moviecomments';
import { Movie } from 'src/app/interfaces/movie';
import { Inject } from '@angular/core';


@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
