import { Component, OnInit, NgModule } from '@angular/core';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
    selector: 'app-admin-movie',
    templateUrl: './admin-movie.component.html',
    styleUrls: ['./admin-movie.component.css']
})
export class AdminMovieComponent implements OnInit {

  users? : User[];
  selectedUser? : User;
  showAddUser: boolean = false;

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
      x => this.users?.push(x),
      y => console.log('there was a problem adding the player')
    );
  }

  DeleteUser(event: number): void {
    //call the service function to add the user to the Db.
    this.userService.DeleteUser(event).subscribe(
      x => this.users?.filter(user => user.userId !== event),
      y => console.log('there was a problem adding the player')
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
