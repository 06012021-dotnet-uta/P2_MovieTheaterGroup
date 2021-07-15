
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
  }
  @Output() userevent = new EventEmitter<User>();

  userForm = new FormGroup ({
    // { "username": "Jack",
    //   "passwd": "Jack",
    //   "firstName": "Jack",
    //   "lastName": "Jack",
    //   "roleId": 2}
    userId: new FormControl(0, [Validators.min(1)]),
    username: new FormControl('', [Validators.maxLength(20), Validators.minLength(3)]),
    passwd: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    roleId: new FormControl(0),
  });
  constructor() { }

  ngOnInit(): void {
  }

  AddNewUser() : void {
    this.userevent.emit(this.newUser);
  }
  UserReactiveFormSubmit(event: MouseEvent): void {
    console.log('The event was triggered')
  }

}
