import { Component, OnInit, NgModule } from '@angular/core';
import { TheaterListComponent } from 'src/app/components/theater-list/theater-list.component.js';

@Component({
  selector: 'app-admintheater',
  templateUrl: './admin-theater.component.html',
  styleUrls: ['./admin-theater.component.css']
})
export class AdminTheaterComponent {
    constructor(private theaterListComponent: TheaterListComponent) { }
}
