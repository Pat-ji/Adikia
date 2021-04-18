import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { GameOverviewComponent } from './overview/overview.component';
import { GameRoutingModule } from './game-routing.module';
import { GameDetailsComponent } from './details/details.component';

@NgModule({
  declarations: [
    GameOverviewComponent,
    GameDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    GameRoutingModule
  ]
})
export class GameModule { }