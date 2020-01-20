import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/service/product.service';
import Product from 'src/app/models/Product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {
  products: Product[];
  page: number = 1;
  pageSize: number;
  collectionSize: number;
  name: string = '';

  constructor(private ps: ProductService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.ps.getProducts(this.page, this.name)
      .subscribe((data: any) => {
        this.products = data.result;
        this.collectionSize = data.collectionSize;
        this.pageSize = data.pageSize;
      });
  }
}