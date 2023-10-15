import { Component } from '@angular/core';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.scss']
})
export class NewUserComponent {

  submit(userForm:any){
    console.log('FORM SUBMMITED!', userForm);
  }
}
