import { Component, OnInit, NgModule } from '@angular/core';
import { MessageService } from 'src/app/message.service';
import { HttpClientModule} from '@angular/common/http';

@Component({
  selector: 'app-admincontainer',
  templateUrl: './admincontainer.component.html',
  styleUrls: ['./admincontainer.component.css']
})
export class AdminContainerComponent implements OnInit{
  constructor() { }

  ngOnInit(): void {
  }
  };
