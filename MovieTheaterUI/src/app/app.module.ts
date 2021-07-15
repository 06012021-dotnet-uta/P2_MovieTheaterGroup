import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule} from '@angular/common/http'
import { freeApiService } from './services/freeapi.service';
import { RoleComponent } from './role/role.component';
import { MovieCommentsComponent } from './movie-comments/movie-comments.component';
import { MovieRatingsComponent } from './movie-ratings/movie-ratings.component';

@NgModule({
  declarations: [
    AppComponent,
    RoleComponent,
    MovieCommentsComponent,
    MovieRatingsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [freeApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
