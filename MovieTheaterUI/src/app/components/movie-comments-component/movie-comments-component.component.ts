import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, DatePipe } from '@angular/common';
import { MovieServiceService } from 'src/app/services/movie.service.service';
import { MovieComments, MovieCommentsMap } from 'src/app/interfaces/movieComments';
import { AppComponent } from '../../app.component';
import { MessageService } from '../../message.service';
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/user';
import { interval } from 'rxjs';
import { MovieCommentsService } from '../../services/movie-comments.service';

@Component({
    selector: 'app-movie-comments-component',
    templateUrl: './movie-comments-component.component.html',
    styleUrls: ['./movie-comments-component.component.css']
})
export class MovieCommentsComponentComponent implements OnInit {

    lstMovieComments?: MovieComments[];
    @Input() movieId!: string;
    currentUser: User = {
        userId: 0,
        username: 'test',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
    };

    constructor(
        private route: ActivatedRoute,
        private movieService: MovieServiceService,
        private location: Location,
        private userService: UserService,
        private commentService: MovieCommentsService,
        private datePipe: DatePipe) {
    }

    admin = false;
    login = false;
    checkLogin(): void {
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

    ngOnInit(): void {
        this.getMovieComments();
        interval(1000).subscribe(x => this.checkLogin());
    }

    content = '';

    onSubmit(): void {
        const newComment: MovieCommentsMap = {
            movieId: this.movieId,
            userId: this.currentUser.userId,
            content: this.content
        }
        console.log(newComment);
        this.commentService.addComment(newComment);
    }

    getMovieComments(): void {
        this.movieService.getMovieComments(this.movieId)
            .subscribe(
                lstMovieComments => this.lstMovieComments = lstMovieComments
            );
    }
}
