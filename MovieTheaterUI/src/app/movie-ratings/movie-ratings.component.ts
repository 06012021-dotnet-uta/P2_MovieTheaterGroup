import { Component, OnInit } from '@angular/core';
import { freeApiService } from '../services/freeapi.service';
import { MovieRatings } from '../classes/movieratings';
import { Inject } from '@angular/core';


@Component({
  selector: 'app-movie-ratings',
  templateUrl: './movie-ratings.component.html',
  styleUrls: ['./movie-ratings.component.css']
})
export class MovieRatingsComponent implements OnInit {

  constructor(@Inject(freeApiService) private _freeApiService: freeApiService) { }

  lstmovieratings:MovieRatings[] | undefined;


  ngOnInit(): void {
    this._freeApiService.getmovieratings()
    .subscribe
    (
      data=>
      {
        console.log(data);
        this.lstmovieratings = data;
      }
    );
  }

}
