import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-game-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.scss']
})
export class UserGameSessionComponent implements OnInit {
  tab: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  setTab(tab: number) {
    this.tab = tab;
    console.log('dddd')
  }

}
