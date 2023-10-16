import { Component } from '@angular/core';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap'; // Assuming you are using NgbModal
import axios from 'axios';
import { ProductModalComponent } from '../product-modal/product-modal.component';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
  
})
export class ProductListComponent {
  products: any; // Data from your table row

  ngOnInit(){
      axios
      .get('http://localhost:8000/api/Product')
      .then((response) => {
        this.products = response.data;
      })
      .catch((error) => {
        console.error(error);
      });
    
  
  }







  // editProduct(product: any) {
  //   axios
  //   .post('http://localhost:8000/api/Product/EditProduct', product)
  //   .then((response) => {
  //     console.log(response);
  //   })
  //   .catch((error) => {
  //     console.error(error);
  //   });
  // }
  
  deleteProduct(productId: string) {
    axios
      .delete(`http://localhost:8000/api/Product/${productId}`)
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.error(error);
      });
  }

  addProduct() {
    alert(`add product`);
  }
}


