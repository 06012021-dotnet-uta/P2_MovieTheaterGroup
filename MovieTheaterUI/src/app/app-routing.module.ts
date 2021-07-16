import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserComponent } from './components/user/user.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { TheaterListComponent } from './components/theater-list/theater-list.component';
import { TheaterDetailsComponent } from './components/theater-details/theater-details.component';

const routes: Routes = [
  { path: 'users', component : UserComponent},
  { path: 'users/:id', component: UserDetailsComponent },
  { path: 'theaters', component: TheaterListComponent },
  { path: 'theater/:id', component: TheaterDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
