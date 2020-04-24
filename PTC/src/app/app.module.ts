import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http'
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent }  from './app.component';
import { ProductListComponent } from './Product/product-list.component';
import { ProductService } from './Product/product.service';
import { CategoryService } from './Category/category.service';
import { ProductDetailComponent } from './Product/product-detail.component';


@NgModule({
    imports: [BrowserModule,
        AppRoutingModule,
        HttpModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        ProductListComponent,
        ProductDetailComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        ProductService,
        CategoryService
    ]
})
export class AppModule { }
