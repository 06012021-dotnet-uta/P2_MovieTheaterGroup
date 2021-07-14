import { Component, OnInit, NgModule } from '@angular/core';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  // roles : Role[] = [];
  users? : User[];
  selectedUser? : User;

  constructor( private userService: UserService,
               private messageService : MessageService) { }

  onSelect( user : User) : void {
    this.selectedUser = user;
    this.messageService.add( `UserCommponent : Selected user id = ${user.userId}`);
  }

  // getRoles() : void {
  //   this.roleService.getRoles().subscribe(roles => this.roles = roles);
  // }

  ngOnInit(): void {
    // this.getRoles();
    this.userService.getUsers().subscribe(
      x => this.users = x
    );
  }
}
