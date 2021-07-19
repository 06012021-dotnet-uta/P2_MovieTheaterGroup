import { Component, OnInit} from '@angular/core';
import { Theater } from 'src/app/interfaces/theater';
import { TheaterService } from 'src/app/services/theater.service';

@Component({
  selector: 'app-admin-theater',
  templateUrl: './admin-theater.component.html',
  styleUrls: ['./admin-theater.component.css']
})
export class AdminTheaterComponent implements OnInit{

    theaters?: Theater[];

    theaterName = '';
    theaterLocation = '';

constructor(private theaterService: TheaterService) {
}

    onSubmit(): void {
        const newTheater: Theater = {
            theaterLoc: this.theaterName,
            theaterName: this.theaterName,
            theaterId: 0
        }
        this.theaterService.addTheater(newTheater).subscribe()
    }

    ngOnInit(): void {
        this.theaterService.getTheaters().subscribe(
            theaters => this.theaters = theaters

        );
    }
}
