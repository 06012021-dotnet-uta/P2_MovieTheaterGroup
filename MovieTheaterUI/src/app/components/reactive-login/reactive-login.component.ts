import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from 'src/app/services/authentication.service';
import {Router} from '@angular/router';import { FormControl, FormGroup, Validators } from '@angular/forms';
import {  Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-reactive-login',
  templateUrl: './reactive-login.component.html',
  styleUrls: ['./reactive-login.component.css']
})
export class ReactiveLoginComponent implements OnInit {

    loginForm = new FormGroup({

            //FormControls represent the Properties of the form.
            username: new FormControl('', [Validators.maxLength(20), Validators.minLength(3)]),
            passwrd: new FormControl('', [Validators.maxLength(20), Validators.minLength(3)]),


    });
    error: boolean = true;

    constructor(private authenticationService: AuthenticationService, public router: Router) {
    }

    ngOnInit() {
      this.loginForm = new FormGroup({
        username: new FormControl(null, Validators.required),
        password: new FormControl(null, [Validators.required, Validators.minLength(4)]),
      });
    }

    onSubmit() {
      this.authenticationService.login(this.loginForm.value.username, this.loginForm.value.password)
      // .pipe(first())
        .subscribe(
          data => {
            this.router.navigate(['home', 'employeeList']);
          },
          error => {
            this.error = error;
            // this.loading = false;
          });
    }


  }
