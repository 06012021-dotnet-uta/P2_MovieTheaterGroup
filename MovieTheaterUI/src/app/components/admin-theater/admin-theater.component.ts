import { Component, OnInit} from '@angular/core';
import { interval } from 'rxjs';
import { Theater } from 'src/app/interfaces/theater';
import { TheaterService } from 'src/app/services/theater.service';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';

@Component({
    selector: 'app-admin-theater',
    templateUrl: './admin-theater.component.html',
    styleUrls: ['./admin-theater.component.css']
})
export class AdminTheaterComponent implements OnInit {

    theaters?: Theater[];
    theater?: Theater;
    theaterName = '';
    theaterLocation = '';

    constructor(private userService: UserService, private theaterService: TheaterService) {
    }

    onSubmit(): void {
        const newTheater: Theater = {
            theaterLoc: this.theaterName,
            theaterName: this.theaterName,
            theaterId: 0
        }
        this.theaterService.addTheater(newTheater).subscribe()
    }

    currentUser: User = {
        userId: 1,
        username: 'test',
        passwd: '',
        firstName: '',
        lastName: '',
        roleId: 0
    };


    ngOnInit(): void {
        this.theaterService.getTheaters().subscribe(
            theaters => this.theaters = theaters

        );
        interval(1000).subscribe(x => this.checkLogin())
    }

    //update(): void {
    //    this.theater = 
    //    this.theaterService.updateTheater(this.theater)
    //}

    admin = false;
    login!: boolean;
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
}
