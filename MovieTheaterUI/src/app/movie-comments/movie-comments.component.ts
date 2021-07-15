import { Component, OnInit } from '@angular/core';
import { freeApiService } from '../services/freeapi.service';
import { MovieComments } from '../classes/moviecomments';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-movie-comments',
  templateUrl: './movie-comments.component.html',
  styleUrls: ['./movie-comments.component.css']
})
export class MovieCommentsComponent implements OnInit {

  // constructor(private _freeApiService: freeApiService) { }
  constructor(@Inject(freeApiService) private _freeApiService: freeApiService) { }

  lstmoviecomments:MovieComments[] | undefined;

  ngOnInit(): void {
    this._freeApiService.getmoviecomments()
    .subscribe
    (
      data=>
      {
        console.log(data);
        this.lstmoviecomments = data;
      }
    );
  }

}
