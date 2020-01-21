import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/service/product.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import Product from 'src/app/models/Product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {
  searchForm: FormGroup;
  products: Product[];
  page: number = 1;
  pageSize: number;
  collectionSize: number;
  previousSearch: string = '';

  constructor(private fb: FormBuilder, private ps: ProductService) {
    this.createForm();
  }

  createForm() {
    this.searchForm = this.fb.group({ name });
  }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    let name = this.searchForm.controls.name.value;

    // Check if search input is different than previous and changes back to page 1
    if (this.previousSearch !== name) {
      this.page = 1;
    }

    this.previousSearch = name;

    this.ps.getProducts(this.page, name)
      .subscribe((data: any) => {
        this.products = data.result;
        this.collectionSize = data.collectionSize;
        this.pageSize = data.pageSize;
      });
  }
}