
import { Component, OnInit , Input} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/interfaces/user';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

user : User | undefined;

constructor(
  private route : ActivatedRoute,
  private userService : UserService,
  private location : Location,
) { }
  ngOnInit(): void {
    this.getUser();
  }

  getUser(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.userService.getUser(id)
        .subscribe(user => this.user = user);
  }

  goBack() : void {
    this.location.back();
  }

}
