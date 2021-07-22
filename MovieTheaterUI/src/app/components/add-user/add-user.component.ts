import { HttpClientModule} from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/interfaces/user';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  newUser : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  };
  @Output() userevent = new EventEmitter<User>();


  constructor() { }

  ngOnInit(): void {
  }

  AddNewUser() : void {
    this.userevent.emit(this.newUser);
  }


}
