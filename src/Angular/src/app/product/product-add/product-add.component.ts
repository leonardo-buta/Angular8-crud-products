import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from "../../service/product.service";

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  addForm: FormGroup;

  constructor(private fb: FormBuilder, private ps: ProductService) {
    this.createForm();
  }

  createForm() {
    this.addForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  addProduct() {
    this.ps.addProduct(this.addForm.value);
  }
}
