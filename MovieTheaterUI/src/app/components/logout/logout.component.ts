import { LoggedUser } from './../../interfaces/loggedUser';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  logoutUser : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  };
  @Output() userevent = new EventEmitter<User>();


  constructor( private userService: UserService,
               private messageService : MessageService) { }

  ngOnInit(): void {
  }
  LogoutUser() : void {

    this.logoutUser = this.userService.GetCurrentUser();
    this.messageService.add(`before logout current user:  ${this.logoutUser.username}`);
    //this.userevent.emit(this.logoutUser);
    this.userService.AuthorizedUser(this.logoutUser);
    this.messageService.add("BYE BYE");
    this.logoutUser = this.userService.GetCurrentUser();
    this.messageService.add(`After logout current user:  ${this.logoutUser.username}`);


  }

}
