import { freeApiService } from './services/freeapi.service';
import { Comments } from './classes/comments';
import { Posts } from './classes/posts';
import { MovieComments } from './classes/moviecomments';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from './services/user.service';
import { User } from './interfaces/user';
import { MessageService } from './message.service';


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'MovieTheater';
    currentUser: User = {
        userId: 0,
        username: '',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
    };

    constructor(private userService: UserService, private messageService: MessageService) { }
    admin = false;
    login = false;
    //   currentUser?:User;
    ngOnInit() {
        this.currentUser = this.userService.GetCurrentUser();
        // alert(`current user id : ${this.currentUser.userId}`)
        if (this.currentUser.userId === 1) {
            this.admin = true;
        }
        else
        {
            this.admin = false;
        }

        if (this.currentUser.userId === 0) {
            this.login = false;
        }
        else {
            this.login = true;
        }
    }
}
