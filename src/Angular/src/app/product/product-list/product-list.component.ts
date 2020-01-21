import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/service/product.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Product from 'src/app/models/Product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {
  editForm: FormGroup;
  searchForm: FormGroup;
  products: Product[];
  page: number = 1;
  pageSize: number;
  collectionSize: number;
  previousSearch: string = '';

  constructor(private fb: FormBuilder, private modalService: NgbModal, private ps: ProductService) {
    this.createEditForm();
    this.createSearchForm();
  }

  ngOnInit() {
    this.loadProducts();
  }

  createEditForm() {
    this.editForm = this.fb.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  createSearchForm() {
    this.searchForm = this.fb.group({ name });
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

  openModal(targetModal: any, product: Product) {
    this.modalService.open(targetModal, { size: 'lg', backdrop: 'static' });
    this.editForm.patchValue({
      id: product.id,
      name: product.name,
      description: product.description,
      price: product.price.toFixed(2)
    })
  }

  onSubmit() {
    this.modalService.dismissAll();
    this.ps.editProduct(this.editForm.value);
  }
}
