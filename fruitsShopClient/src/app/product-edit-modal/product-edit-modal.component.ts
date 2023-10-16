import { Component } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-product-edit-modal',
  templateUrl: './product-edit-modal.component.html',
  styleUrls: ['./product-edit-modal.component.scss']
})
export class ProductEditModalComponent {
  product: any;
  onSubmit(productEdit: any) {
    axios
    .post('http://localhost:8000/api/Product/EditProduct', productEdit)
    .then((response) => {
      console.log(response);
    })
    .catch((error) => {
      console.error(error);
    });
  }

  ngOnInit(){
    
  }

}
