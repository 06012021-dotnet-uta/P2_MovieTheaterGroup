import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MovieServiceService } from 'src/app/services/movie.service.service';
// import { MovieComments } from 'src/app/interfaces/movieComments';
import { MovieRatings } from 'src/app/classes/movieratings';

@Component({
  selector: 'app-movie-ratings-component',
  templateUrl: './movie-ratings-component.component.html',
  styleUrls: ['./movie-ratings-component.component.css']
})
export class MovieRatingsComponentComponent implements OnInit {

  lstMovieRatings?: MovieRatings[];
  id: string = this.route.snapshot.paramMap.get('id')!;


  constructor(    
    private route: ActivatedRoute,
    private movieService: MovieServiceService,
    private location: Location) { }

  ngOnInit(): void {
    this.getMovieRatings();
    console.log(this.lstMovieRatings);

  }
  getMovieRatings(): void {
    console.log(this.id);
    
    this.movieService.getMovieRatings(this.id)
    .subscribe(
      // data=>
      // {
      //   console.log(data);
      //   // this.lstMovieComments = data;
      //   // this.lstMovieComments = data;
      //   // console.log(this.movie);
      // }
      // lstMovieComments => console.log(lstMovieComments),
      lstMovieRatings => this.lstMovieRatings = lstMovieRatings
    );
  }

}
