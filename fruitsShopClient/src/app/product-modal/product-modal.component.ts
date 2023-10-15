// product-modal.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-product-modal',
  templateUrl: './product-modal.component.html',
})
export class ProductModalComponent implements OnInit {
  

  productForm: FormGroup | any;

  constructor(){}

  ngOnInit() {
    this.productForm = new FormGroup({
      productName: new FormGroup('user'),
    });
    // Initialize the modal fields with the data from the rowData input.
    // console.log(this.rowData);

    // if (this.rowData) {
    //       console.log(this.rowData.name);

    //   this.productName = this.rowData.name;
    //   this.category = this.rowData.category;
    //   this.price = this.rowData.price;
    //   this.date = this.rowData.date;
    // }
  }


  addProduct() {
    // Implement the logic to add the product to your data source.
    // You can use services and observables to update your product list.
  }
}