import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-user-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class UserSignUpComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[];

  constructor(private fb: FormBuilder, private userService: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null,
        [Validators.required, Validators
          .pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
      ],
      password: [null, Validators.required]
    });
  }

  onSubmit() {
    this.userService.register(this.registerForm.value).subscribe({
      next: () => {
        this.toastr.success('The account has been registered!');
        this.router.navigateByUrl('/');
      }, error: (error) => {
        this.errors = [error.error.message] || [error.statusText];
      }
    })
  }
}
