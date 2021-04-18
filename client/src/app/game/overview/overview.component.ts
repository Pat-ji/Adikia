import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { mapTo } from 'rxjs/operators';
import { IGame } from 'src/app/shared/models/game';
import { IPagination } from 'src/app/shared/models/pagination';
import { PaginationParams } from 'src/app/shared/models/pagination-params';
import { GameService } from '../../shared/services/game.service';

@Component({
  selector: 'app-game-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class GameOverviewComponent implements OnInit {
  games: IGame[];

  totalCount: number;
  pagination: PaginationParams;

  gameSubscription$: Subscription;

  constructor(private gameService: GameService) {
    this.pagination = new PaginationParams();
    this.totalCount = 0;
  }

  ngOnInit(): void {
    this.getGames();
  }

  getGames() {
    this.gameSubscription$ = this.gameService
      .getGames(this.pagination)
      .subscribe({
        next: (response: IPagination<IGame>) => {
          this.games = response.data;
          this.pagination.pageNumber = response.pageIndex;
          this.pagination.pageSize = response.pageSize;
          this.totalCount = response.count;

          this.gameSubscription$.unsubscribe();
        },
      });
  }

  onPageChanged(event: number) {
    this.pagination.pageNumber = event;
    
    this.getGames();
  }

}
