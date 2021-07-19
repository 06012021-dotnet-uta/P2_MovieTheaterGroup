import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MovieServiceService } from 'src/app/services/movie.service.service';
// import { MovieComments } from 'src/app/interfaces/movieComments';
import { MovieRatings } from 'src/app/interfaces/movieRatings';

@Component({
    selector: 'app-movie-ratings-component',
    templateUrl: './movie-ratings-component.component.html',
    styleUrls: ['./movie-ratings-component.component.css']
})
export class MovieRatingsComponentComponent implements OnInit {

    lstMovieRatings?: MovieRatings[];
    @Input() movieId!: string;

    constructor(
        private route: ActivatedRoute,
        private movieService: MovieServiceService,
        private location: Location) { }

    ngOnInit(): void {
        this.getMovieRatings();
    }
    getMovieRatings(): void {
        this.movieService.getMovieRatings(this.movieId)
            .subscribe(
                lstMovieRatings => this.lstMovieRatings = lstMovieRatings
            );
    }
    getRatingsAverage(): string {
        var sum: number = 0;
        var listLength: number = 0;
        if (this.lstMovieRatings != null) {
            listLength = this.lstMovieRatings?.length;
            this.lstMovieRatings?.forEach(rating => {
                sum = sum + parseInt(rating.content, 10);
            });
        }
        return (sum / listLength).toFixed(1);
    }
}
