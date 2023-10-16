import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import axios from 'axios';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  // loginForm: FormGroup;

  // constructor(private fb: FormBuilder) {
  //   this.loginForm = this.fb.group({
  //     username: ['', [Validators.required]],
  //     password: ['', [Validators.required]]
  //   });
  // }

  onSubmit(loginForm: any) {
    if (loginForm.valid) {
      const formData = loginForm.value;

      axios
        .post('http://localhost:8000/api/Auth/login', formData)
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.error(error);
        });
    }
  }
}
