import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';
import { LoggedUser } from 'src/app/interfaces/loggedUser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  currentUser : LoggedUser = {username: 'mmm', passwd: ''};
  authorizedUser? : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  }
  users? : User[];
  @Output() userevent = new EventEmitter<LoggedUser>();

  constructor( private userService: UserService,
    private messageService : MessageService) { }

    ngOnInit(): void {
      this.userService.getUsers().subscribe(
        x => {this.users = x; },
        y => console.log(`there was an error ${y}`),//the second arg callback func handles an error response
        () => console.log('This is the complete block callback function')// the 3rd callback called "complete" arg always runs (just like a finally lock)
      );
    };

    LoggedCorrectUser() : void {
      // this.messageService.add(`before login ${this.currentUser.username}`);
      this.userevent.emit(this.currentUser);
      // this.messageService.add(`after login ${this.currentUser.username}`);
      this.authorizedUser = this.users?.find( user => user.username == this.currentUser.username
        && user.passwd == this.currentUser.passwd);
      // this.messageService.add(`authorizedUser username:  ${this.authorizedUser?.username}`);

      if(this.authorizedUser?.username != this.currentUser.username){
        this.messageService.add("wrong username or password");
      }else {
        this.messageService.add(` Hi ${this.authorizedUser?.username} Welcome to The Theater Movie app`);

      }
    }



}
