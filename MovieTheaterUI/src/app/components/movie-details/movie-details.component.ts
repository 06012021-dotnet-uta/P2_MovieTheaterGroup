import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
// import { Theater } from '../../interfaces/theater';
// import { TheaterService } from '../../services/theater.service';
import { MovieServiceService } from 'src/app/services/movie.service.service';
import { Movie } from 'src/app/interfaces/movie';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie: Movie = {
    movieId: "aa",
    movieName: "This is movie name",
    movieImage: "xx"
  }
  // id: number = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
  id: string = this.route.snapshot.paramMap.get('id')!;
  // id: string = 'tt0075029'

  constructor(    
    private route: ActivatedRoute,
    private movieService: MovieServiceService,
    private location: Location) { }


    
  ngOnInit(): void { 
    
    this.getMovie();
  }

  getMovie(): void {
    console.log(this.id);
    this.movieService.getMovie(this.id)
    .subscribe(
      // data=>
      // {
      //   console.log(data);
      //   this.movie = data;
      //   console.log(this.movie);
      // }
      movie => this.movie = movie
      
      // this.movie.movieName => movie.movieName;
      // this.movie?.movieName = movieName 

    )
    console.log(this.movie);
    console.log(this.movie.movieName);
  }

}
