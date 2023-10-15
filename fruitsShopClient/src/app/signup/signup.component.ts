import { Component, OnInit } from '@angular/core';
import axios from 'axios'; // Import Axios
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {

  onSubmit(registerForm:any) {
    if (registerForm.valid) {
      const formData = registerForm.value;

      axios
        .post('http://localhost:8000/api/Auth/register', formData)
        .then((response) => {
          console.log(response);
          
        })
        .catch((error) => {
          console.error(error);
        });
    }
  }
}
