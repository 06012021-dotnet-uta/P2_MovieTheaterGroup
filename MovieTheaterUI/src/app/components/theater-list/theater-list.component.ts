import { Component, OnInit } from '@angular/core';
import { Theater } from 'src/app/interfaces/theater';
import { TheaterService } from 'src/app/services/theater.service';
import { Movie } from 'src/app/interfaces/movie';
import { Router } from '@angular/router';

@Component({
    selector: 'app-theater',
    templateUrl: './theater-list.component.html',
    styleUrls: ['./theater-list.component.css']
})
export class TheaterListComponent implements OnInit {

    theaters?: Theater[];
    selectedTheater?: Theater;

    constructor(private theaterService: TheaterService) { }

    onSelect(theater: Theater): void {
        this.selectedTheater = theater;
    }

    ngOnInit(): void {
        this.theaterService.getTheaters().subscribe(
            theaters => this.theaters = theaters
        );
    }
}
