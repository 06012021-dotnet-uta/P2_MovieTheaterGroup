import { freeApiService } from './services/freeapi.service';
import { Comments } from './classes/comments';
import { Posts } from './classes/posts';
import { MovieComments } from './classes/moviecomments';
import { Component, OnInit, Output, Input, EventEmitter, ViewEncapsulation, HostBinding } from '@angular/core';
import { UserService } from './services/user.service';
import { User } from './interfaces/user';
import { MessageService } from './message.service';
import { Observable, of , BehaviorSubject} from 'rxjs';
import { interval } from 'rxjs';
/*import { Dom } from '@angular/core';*/


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'MovieTheater';
    currentUser: User = {
        userId: 1,
        username: 'test',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
    };

    constructor(private userService: UserService, private messageService: MessageService) {
        const credentials = sessionStorage.getItem('thing')
        if (credentials) {
            this.OnsetCredentials(credentials)
        }
    }
    admin = false;
    login = false;
    checkLogin() : void {
        this.currentUser = this.userService.GetCurrentUser();

        if (this.currentUser.roleId === 1) {
            this.admin = true;
        }
        else {
            this.admin = false;
        }

        if (this.currentUser.roleId === 0) {
            this.login = false;
        }
        else {
            this.login = true;
        }
    }
    ngOnInit() {
        this.admin = false;
        this.login = false;
        interval(1000).subscribe(x => this.checkLogin())
    }

    logoutUser : User = {
        userId: 0,
        username: '',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
      };

      logoutUser1 : User = {
        userId: 0,
        username: '',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
      };
      @Input() userevent = new EventEmitter<User>();

      LogoutUser() : void {
        this.logoutUser1 = this.userService.GetCurrentUser();
        this.messageService.add(`before logout current user:  ${this.logoutUser1.username}`);
        // this.userevent.emit(this.logoutUser);
        this.messageService.add(`atfter logout current user:  ${this.logoutUser.username}`);
        this.userService.AuthorizedUser(this.logoutUser);
        this.messageService.add("BYE BYE");
        this.logoutUser = this.userService.GetCurrentUser();
        this.messageService.add(`After logout current user:  ${this.logoutUser.username}`);
    }

    OnsetCredentials(credentials: string) {
        sessionStorage.setItem('thing', credentials);
        }
}
