import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLoginComponent } from './login/login.component';
import { UserSignUpComponent } from './sign-up/sign-up.component';
import { UserDetailsComponent } from './details/details.component';
import { UserGamesComponent } from './games/games.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { UserGameSessionComponent } from './session/session.component';

const routes: Routes = [
  { path: 'login', component: UserLoginComponent },
  {
    path: 'details',
    canActivate: [AuthGuard], component: UserDetailsComponent
  },
  {
    path: 'games',
    canActivate: [AuthGuard], component: UserGamesComponent
  },
  {
      path: 'session/:id',
      canActivate: [AuthGuard], component: UserGameSessionComponent
  },
  { path: 'signup', component: UserSignUpComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class UserRoutingModule { }