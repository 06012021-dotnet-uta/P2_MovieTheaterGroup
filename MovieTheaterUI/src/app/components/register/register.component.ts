import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  showCreateduser? : User;
  createdUser : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  };
  newUser : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  };
  @Output() userevent = new EventEmitter<User>();


  constructor(private userService: UserService,
    private messageService : MessageService) { }

  ngOnInit(): void {
  }

  AddNewUser() : void {
    this.userevent.emit(this.newUser);
    this.RegisterNewUser(this.newUser);
  }

  RegisterNewUser(user: User): void {
    //call the service function to add the user to the Db.
    this.userService.AddUser(this.newUser).subscribe(
      x => {
        this.createdUser = x,
        this.createdUser = x
      } ,
      y => console.log('there was a problem adding the player')
    );
  }


}
