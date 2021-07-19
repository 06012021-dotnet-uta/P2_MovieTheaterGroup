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
    movieId: string = this.route.snapshot.paramMap.get('id')!;

    constructor(
        private route: ActivatedRoute,
        private movieService: MovieServiceService,
        private location: Location) { }

    ngOnInit(): void {
        this.getMovie();
    }

    getMovie(): void {
        this.movieService.getMovie(this.movieId)
            .subscribe(
                movie => console.log(movie)
                //movie => this.movie = movie
            );
    }
}
