import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { RouterModule } from '@angular/router';
import { PagingFooterComponent } from './components/paging-footer/paging-footer.component';
import { GameCardComponent } from './components/game-card/game-card.component';

@NgModule({
  declarations: [TextInputComponent, PagingFooterComponent, GameCardComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    PaginationModule,
    CarouselModule,
    ReactiveFormsModule,
    FormsModule,
    BsDropdownModule,
    TextInputComponent,
    PagingFooterComponent,
    GameCardComponent
  ]
})
export class SharedModule { }