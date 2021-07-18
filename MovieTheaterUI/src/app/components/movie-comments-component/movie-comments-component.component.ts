import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MovieServiceService } from 'src/app/services/movie.service.service';
import { MovieComments } from 'src/app/interfaces/movieComments';

@Component({
  selector: 'app-movie-comments-component',
  templateUrl: './movie-comments-component.component.html',
  styleUrls: ['./movie-comments-component.component.css']
})
export class MovieCommentsComponentComponent implements OnInit {

// movieComments: MovieComments = {
//     commentId: 3,
//     movieId: "",
//     userId: 0,
//     content: "",
//     dateMade: "2021-07-15T13:38:59.297",
//     username: ""
//   }

  lstMovieComments?: MovieComments[];
  id: string = this.route.snapshot.paramMap.get('id')!;

  constructor(    
    private route: ActivatedRoute,
    private movieService: MovieServiceService,
    private location: Location) { }

  ngOnInit(): void {
    this.getMovieComments();
    console.log(this.lstMovieComments);
  }

  getMovieComments(): void {
    console.log(this.id);
    
    this.movieService.getMovieComments(this.id)
    .subscribe(
      // data=>
      // {
      //   console.log(data);
      //   // this.lstMovieComments = data;
      //   // this.lstMovieComments = data;
      //   // console.log(this.movie);
      // }
      // lstMovieComments => console.log(lstMovieComments),
      lstMovieComments => this.lstMovieComments = lstMovieComments
      // console.log(this.lstMovieComments);

      
      // this.movie.movieName => movie.movieName;
      // this.movie?.movieName = movieName 

    );
    // console.log(this.movie);
    // console.log(this.movie.movieName);
  }

}
