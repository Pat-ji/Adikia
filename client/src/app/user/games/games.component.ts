import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IGame } from 'src/app/shared/models/game';
import { IPagination } from 'src/app/shared/models/pagination';
import { PaginationParams } from 'src/app/shared/models/pagination-params';
import { ISession } from 'src/app/shared/models/session';
import { GameService } from 'src/app/shared/services/game.service';
import { SessionService } from 'src/app/shared/services/session.service';

@Component({
  selector: 'app-user-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class UserGamesComponent implements OnInit {  
  games: IGame[];
  sessions: ISession[];

  totalGameCount: number;
  totalSessionCount: number;

  gamePagination: PaginationParams;
  sessionPagination: PaginationParams;

  constructor(private gameService: GameService, private sessionService: SessionService) {
    this.totalGameCount = 0;
    this.totalSessionCount = 0;

    this.gamePagination = new PaginationParams();
    this.sessionPagination = new PaginationParams();
  }

  ngOnInit(): void {
    this.getGames();
    this.getSessions();
  }

  getGames() {
    const gamesSubscription$ = this.gameService
      .getUserGames(this.gamePagination)
      .subscribe({
        next: (response: IPagination<IGame>) => {
          this.games = response.data;
          this.gamePagination.pageNumber = response.pageIndex;
          this.gamePagination.pageSize = response.pageSize;
          this.totalGameCount = response.count;

          gamesSubscription$.unsubscribe();
        },
      });
  }

  getSessions() {
    const sessionsSubscription$ = this.sessionService
      .getSessions(this.sessionPagination)
      .subscribe({
        next: (response: IPagination<ISession>) => {
          this.sessions = response.data;
          this.sessionPagination.pageNumber = response.pageIndex;
          this.sessionPagination.pageSize = response.pageSize;
          this.totalSessionCount = response.count;

          sessionsSubscription$.unsubscribe();
        },
      });
  }

  onGamePageChanged(event: number) {
    this.gamePagination.pageNumber = event;

    this.getGames();
  }

  onSessionPageChanged(event: number) {
    this.sessionPagination.pageNumber = event;

    this.getSessions();
  }

  onNewSessionClick(gameId: number) {
    const sessionsSubscription$ = this.sessionService
      .createSession(gameId)
      .subscribe({
        next: (response: ISession) => {
          sessionsSubscription$.unsubscribe();
        },
      });
  }

}
