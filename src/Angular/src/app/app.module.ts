import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SlimLoadingBarModule } from 'ng2-slim-loading-bar';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';

import { ProductAddComponent } from './product/product-add/product-add.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { ProductListComponent } from './product/product-list/product-list.component';

import { ProductService } from "./service/product.service";

import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faEdit, faTrashAlt, faSearch } from '@fortawesome/free-solid-svg-icons';

@NgModule({
  declarations: [
    AppComponent,
    ProductAddComponent,
    ProductEditComponent,
    ProductListComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    SlimLoadingBarModule,
    HttpClientModule,
    FontAwesomeModule,
    NgbPaginationModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(library: FaIconLibrary) {
    library.addIcons(faEdit, faTrashAlt, faSearch);
  }
}
