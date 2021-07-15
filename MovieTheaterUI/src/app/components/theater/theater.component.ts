import { Component, OnInit } from '@angular/core';
import { Theater } from 'src/app/interfaces/theater';
import { TheaterService } from 'src/app/services/theater.service';

@Component({
  selector: 'app-theater',
  templateUrl: './theater.component.html',
  styleUrls: ['./theater.component.css']
})
export class TheaterComponent implements OnInit {

  theaters?: Theater[];
  selectedTheater?: Theater;

  constructor(private theaterService: TheaterService) { }

  ngOnInit(): void {
    this.theaterService.getTheaters().subscribe(
      x => this.theaters = x
    );
  }
}
