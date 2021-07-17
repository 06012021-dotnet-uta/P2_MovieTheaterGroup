import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserComponent } from './components/user/user.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { TheaterListComponent } from './components/theater-list/theater-list.component';
import { TheaterDetailsComponent } from './components/theater-details/theater-details.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AdminContainerComponent } from './components/admin-container/admincontainer.component';
import { LogoutComponent } from './components/logout/logout.component';
// import { MoviesComponent } from './components/movie-list/movie-list.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
const routes: Routes = [

  { path: 'users',     component : UserComponent},
  { path: 'users/:id', component : UserDetailsComponent},
  { path: 'register', component : RegisterComponent},
  // { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login' , component: LoginComponent},
  { path: 'logout' , component: LogoutComponent},
  { path: 'theaters', component: TheaterListComponent },
  { path: 'theater/:id', component: TheaterDetailsComponent },
  { path: 'admincontainer', component : AdminContainerComponent},
  { path: 'movies', component : MovieListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
