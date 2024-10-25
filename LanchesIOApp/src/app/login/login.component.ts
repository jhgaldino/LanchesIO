// src/app/login/login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LancheService } from '../services/lanche.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private lancheService: LancheService, private router: Router) {}

  onSubmit() {
    this.lancheService.login(this.username, this.password).subscribe(
      response => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/']);
      },
      error => {
        alert('Login failed');
      }
    );
  }
}
