import { Component, OnInit, NgModule } from '@angular/core';
import { freeApiService } from './services/freeapi.service';
import { Comments } from './classes/comments';
import { Posts } from './classes/posts';
import { MovieComments } from './classes/moviecomments';
import { LoggedUser } from './interfaces/loggedUser';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/interfaces/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private _userService: UserService) {
     }
    title = 'MovieTheater';
    test = true;
    placeholder = 'Placeholder';

    currentuser?: number = this._userService.authorizedUser?.roleId;
//    if(typeof currentuser ==="undefined")
//        {
//            alert('ok');
//        }





//   ngOnInit(): void {
//    this.currentuser? = this._userService.authorizedUser?.roleId;
//    }
//}







     //this._freeApiService.getcomments()
     //.subscribe
     //(
     //  data=>
     //  {
     //    this.lstcomments = data;
     //);
  // lstcomments:Comments[] | undefined;
  // lstmoviecomments:MovieComments[] | undefined;

  // lstposts:Posts[] | undefined;
  // objposts:MovieComments | undefined;
  //   this._freeApiService.getcommentsbyparameter()
  //   .subscribe
  //   (
  //     data=>
  //     {
  //       this.lstposts = data;
  //     }
  //   );

  //   var opost = new MovieComments();

  //   opost.commentId = 1000;
  //   opost.movieId = 'testbody';
  //   opost.userId = 5;
  //   opost.content = "Test content";
  //   opost.dateMade = "8/12/21";
  //   opost.username = "Hooman"


  //   console.log(opost);

  //   this._freeApiService.post(opost)
  //   .subscribe(
  //     data=>
  //     {
  //       this.objposts = data;
  //     }
  //   );

  //   console.log(this.objposts)

  //   this._freeApiService.getmoviecomments()
  //   .subscribe
  //   (
  //     data=>
  //     {
  //       console.log(data);
  //       this.lstmoviecomments = data;
  //     }
  //   );
  // }
