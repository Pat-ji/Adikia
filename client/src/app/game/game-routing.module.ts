import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameDetailsComponent } from './details/details.component';
import { GameOverviewComponent } from './overview/overview.component';

const routes: Routes = [
    {
        path: 'overview', component: GameOverviewComponent,
    },
    {
        path: 'details/:id', component: GameDetailsComponent
    }
]

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})
export class GameRoutingModule { }