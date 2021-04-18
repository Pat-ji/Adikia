import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/shared/models/user';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class UserDetailsComponent implements OnInit {
  currentUser$: Observable<IUser>;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.currentUser$ = this.userService.currentUser$;
  }

}
