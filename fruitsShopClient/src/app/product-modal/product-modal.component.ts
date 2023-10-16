// product-modal.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import axios from 'axios';

@Component({
  selector: 'app-product-modal',
  templateUrl: './product-modal.component.html',
})
export class ProductModalComponent {
  
  onSubmit(product:any) {
    if (product.valid) {
      const formData = product.value;

      axios
        .post('http://localhost:8000/api/Product/AddProduct', formData)
        .then((response) => {
          console.log(response);
          
        })
        .catch((error) => {
          console.error(error);
        });
    }


  }
}