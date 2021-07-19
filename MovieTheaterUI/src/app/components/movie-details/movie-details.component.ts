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

    movie!: Movie;
    movieId: string = this.route.snapshot.paramMap.get('movieId')!;
    theaterId?: number;
    description?: string;

    constructor(
        private route: ActivatedRoute,
        private movieService: MovieServiceService,
        private location: Location) { }

    ngOnInit(): void {
        this.getMovie();
        this.getDescription();
        if (this.route.snapshot.paramMap.get('theaterId')) {
            this.theaterId = parseInt(this.route.snapshot.paramMap.get('theaterId')!, 10);
        }
    }

    getMovie(): void {
        this.movieService.getMovie(this.movieId)
            .subscribe(
                movie => this.movie = movie
            );
    }

    getDescription(): void {
        this.movieService.getMovieDescription(this.movieId)
            .subscribe(
                movie => this.description = movie.summary
            );
    }
}
