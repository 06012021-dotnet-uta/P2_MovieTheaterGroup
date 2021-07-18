import { Component} from '@angular/core';
import { TheaterListComponent } from '../theater-list/theater-list.component';

@Component({
  selector: 'app-admin-theater',
  templateUrl: './admin-theater.component.html',
  styleUrls: ['./admin-theater.component.css']
})
export class AdminTheaterComponent extends TheaterListComponent{
}
