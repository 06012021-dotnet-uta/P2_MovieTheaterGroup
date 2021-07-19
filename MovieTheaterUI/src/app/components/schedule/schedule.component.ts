import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from '../../interfaces/schedule';
import { ScheduleService } from '../../services/schedule.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Theater } from '../../interfaces/theater';
import { Movie } from '../../interfaces/movie';
import { MovieServiceService } from '../../services/movie.service.service';
import { TheaterService } from '../../services/theater.service';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
    styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

    @Input() theaterId!: number;
    @Input() movieId!: string;
    schedules?: Schedule[] = [];
    theater!: Theater;
    movie!: Movie;

    constructor(private scheduleService: ScheduleService,
        private movieService: MovieServiceService,
        private theaterService: TheaterService,
        private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.getSchedules();
        this.getMovie();
        this.getTheater();
    }

    getSchedules(): void {
        this.scheduleService.getSchedule(this.movieId, this.theaterId).subscribe(
            schedules => this.schedules = schedules
        );
    }

    getMovie(): void {
        this.movieService.getMovie(this.movieId).subscribe(
            movie => this.movie = movie
        );
    }

    getTheater(): void {
        this.theaterService.getTheater(this.theaterId).subscribe(
            theater => this.theater = theater
        );
    }
}
