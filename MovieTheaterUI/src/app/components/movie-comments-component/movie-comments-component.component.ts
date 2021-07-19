import { Component, Input, OnInit } from '@angular/core';
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

    lstMovieComments?: MovieComments[];
    @Input() movieId!: string;

    constructor(
        private route: ActivatedRoute,
        private movieService: MovieServiceService,
        private location: Location) { }

    ngOnInit(): void {
        this.getMovieComments();
    }

    getMovieComments(): void {
        this.movieService.getMovieComments(this.movieId)
            .subscribe(
                lstMovieComments => this.lstMovieComments = lstMovieComments
            );
    }
}
