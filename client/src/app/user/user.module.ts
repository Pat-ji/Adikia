import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserLoginComponent } from './login/login.component';
import { UserSignUpComponent } from './sign-up/sign-up.component';
import { UserDetailsComponent } from './details/details.component';
import { UserGamesComponent } from './games/games.component';
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from '../shared/shared.module';
import { UserGameSessionComponent } from './session/session.component';
import { SessionInvestigationComponent } from './session/investigation/investigation.component';
import { SessionEvidenceComponent } from './session/evidence/evidence.component';
import { SessionHintsComponent } from './session/hints/hints.component';

@NgModule({
  declarations: [UserLoginComponent, UserSignUpComponent, UserDetailsComponent, UserGamesComponent, UserGameSessionComponent, SessionInvestigationComponent, SessionEvidenceComponent, SessionHintsComponent],
  imports: [
    CommonModule,
    SharedModule,
    UserRoutingModule,
  ]
})
export class UserModule { }