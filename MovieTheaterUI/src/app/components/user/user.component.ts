import { Component, OnInit, NgModule, EventEmitter, Output } from '@angular/core';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users : User[] = [];
  selectedUser? : User;
  showAddUser: boolean = false;

  deleteUser : number = 0;
  @Output() userevent = new EventEmitter<number>();

  constructor( private userService: UserService,
               private messageService : MessageService) { }

  onSelect( user : User) : void {
    this.selectedUser = user
    // this.selectedUser = this.users?.find(x => x == user);
    this.messageService.add( `UserCommponent : Selected user id = ${user.userId}`);
  }

  AddUserParent(event: User): void {
    //call the service function to add the user to the Db.
    this.userService.AddUser(event).subscribe(
      x => this.users.push(x),
      y => console.log('there was a problem adding the player')
    );
  }

  delete(user: User): void {
      this.messageService.add( `delete user Id :  ${user.userId}`);
      this.users = this.users.filter(x => x !== user);
      this.userService.DeleteUser(user.userId).subscribe(
    //   x => this.users.filter(x => x !== user),
    //   y => console.log('there was a problem removing the user')
    );

  }


  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      x => {this.users = x; },
      y => console.log(`there was an error ${y}`),//the second arg callback func handles an error response
      () => console.log('This is the complete block callback function')// the 3rd callback called "complete" arg always runs (just like a finally lock)
    );
  };
}
