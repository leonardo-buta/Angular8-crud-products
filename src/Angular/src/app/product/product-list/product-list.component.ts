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
  constructor(private ps: ProductService) { }

  ngOnInit() {
    this.ps.getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
}
