import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule} from '@angular/common/http';
import { freeApiService } from './services/freeapi.service';
import { RoleComponent } from './components/role/role.component';
import { MovieCommentsComponent } from './movie-comments/movie-comments.component';
import { MovieRatingsComponent } from './movie-ratings/movie-ratings.component';
import { UserComponent } from './components/user/user.component';
import { MessagesComponent } from './components/messages/messages.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';
import { TheaterListComponent } from './components/theater-list/theater-list.component';
import { TheaterMovieComponent } from './components/theater-movie/theater-movie.component';
import { TheaterDetailsComponent } from './components/theater-details/theater-details.component';
import { TheaterMoviePreviewComponent } from './components/theater-movie-preview/theater-movie-preview.component';
import { AdminContainerComponent } from './components/admin-container/admincontainer.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';

@NgModule({
  declarations: [
    AppComponent,
    RoleComponent,
    MovieCommentsComponent,
    MovieRatingsComponent,
    UserComponent,
    UserDetailsComponent,
    MessagesComponent,
    AddUserComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    TheaterListComponent,
    TheaterMovieComponent,
    TheaterDetailsComponent,
    TheaterMoviePreviewComponent,
    RoleComponent,
    AdminContainerComponent,
    MovieListComponent
  ],
  imports: [

    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  // providers: [freeApiService],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
