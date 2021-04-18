import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/errors/not-found/not-found.component';
import { ServerErrorComponent } from './core/errors/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { UserLoginComponent } from './user/login/login.component';
import { UserSignUpComponent } from './user/sign-up/sign-up.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'not-found', component: NotFoundComponent },

  { path: 'login', component: UserLoginComponent },
  { path: 'sign-up', component: UserSignUpComponent },
  {
    path: 'user', loadChildren: () => import('./user/user.module').then(mod => mod.UserModule),
  },
  {
    path: 'game', loadChildren: () => import('./game/game.module').then(mod => mod.GameModule),
  },

  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }