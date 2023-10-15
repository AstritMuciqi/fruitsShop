import { Component } from '@angular/core';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap'; // Assuming you are using NgbModal
import { ProductModalComponent } from '../product-modal/product-modal.component';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
  
})
export class ProductListComponent {
  rowData: any; // Data from your table row

  constructor(private modalService: NgbModal) {}


  products = [
    { name: 'Product 1', price: 19.99, category: 'Category A', date: '01.01.2023' },
    { name: 'Product 2', price: 29.99, category: 'Category B', date: '02.01.2023' },
    { name: 'Product 3', price: 39.99, category: 'Category A', date: '03.01.2023' },
  ];

  openModal(product:any) {
    const modalRef = this.modalService.open(ProductModalComponent);
    modalRef.componentInstance.rowData = product;
  }



  editProduct(product: any) {
    alert(`Edit product: ${product.name}`);
  }
  
  deleteProduct(product: any) {
    alert(`Delete product: ${product.name}`);
  }

  addProduct() {
    alert(`add product`);
  }
}


