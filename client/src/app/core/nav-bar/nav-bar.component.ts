import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/shared/models/user';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  currentUser$: Observable<IUser>;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.currentUser$ = this.userService.currentUser$;
  }

  logout() {
    this.userService.logout();
  }

}
