import { freeApiService } from './services/freeapi.service';
import { Comments } from './classes/comments';
import { Posts } from './classes/posts';
import { MovieComments } from './classes/moviecomments';
import { Component, OnInit, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { UserService } from './services/user.service';
import { User } from './interfaces/user';
import { MessageService } from './message.service';
import { Observable, of , BehaviorSubject} from 'rxjs';
import { interval } from 'rxjs';


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
    checkLogin() : void {
        this.currentUser = this.userService.GetCurrentUser();

        // setTimeout(() => {this.currentUser = this.userService.GetCurrentUser();}, 1000);
            // alert(`current user updated ${this.currentUser.userId}`)
        // .subscribe((val) => { console.log('called'); });

        if (this.currentUser.roleId === 1) {
            this.admin = true;
        }
        // else{ this.admin = false;}

        if (this.currentUser.roleId === 2) {
            this.login = true;
        }
    }
    //   currentUser?:User;
    ngOnInit() {
        this.admin = false;
        this.login = false;
        interval(1000).subscribe(x => this.checkLogin())
        // setTimeout(() => { this.currentUser = this.userService.GetCurrentUser();
        //                    this.messageService.add(` current user ${this.currentUser.username}`);
        //                 }, 1000);

    }

}
