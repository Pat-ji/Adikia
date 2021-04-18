import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class UserLoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/';
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators
        .pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', Validators.required),
    })
  }

  onSubmit() {
    this.userService.login(this.loginForm.value).subscribe(() => {
      this.toastr.success('Logged in successfully.');
      this.router.navigateByUrl(this.returnUrl);
    }, error => {
      this.toastr.error('Failed to login.');
    })
  }

}
