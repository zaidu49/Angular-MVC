import { Component, OnInit } from "@angular/core";
import { Product } from "./product";

@Component({
    templateUrl: "./product-detail.component.html"
})

export class ProductDetailComponent implements OnInit {
    product: Product;
    messages: string[] = [];

    ngOnInit() {
        this.product = new Product();
        this.product.price = 1;
        this.product.categoryId = 1;
        this.product.url = "http://www.fairwaytech.com"
    }

    private handleErrors(errors: any) {
        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}