import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserComponent } from './components/user/user.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { TheaterListComponent } from './components/theater-list/theater-list.component';
import { TheaterDetailsComponent } from './components/theater-details/theater-details.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AdminMovieComponent } from './components/admin-movie/admin-movie.component';
import { AdminTheaterComponent } from './components/admin-theater/admin-theater.component';
import { AdminScheduleComponent } from './components/admin-schedule/admin-schedule.component';
import { LogoutComponent } from './components/logout/logout.component';
// import { MoviesComponent } from './components/movie-list/movie-list.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
const routes: Routes = [

    { path: 'users',     component : UserComponent},
    { path: 'users/:id', component : UserDetailsComponent},
    { path: 'register', component : RegisterComponent},
    // { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login' , component: LoginComponent},
    { path: 'logout' , component: LogoutComponent},
    { path: 'theaters', component: TheaterListComponent },
    { path: 'theater/:id', component: TheaterDetailsComponent },
    { path: 'adminmovie', component: AdminMovieComponent },
    { path: 'admintheater', component: AdminTheaterComponent },
    { path: 'adminschedule', component: AdminScheduleComponent },
    { path: 'movies', component: MovieListComponent },
    { path: 'moviedetails/:id', component: MovieDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
