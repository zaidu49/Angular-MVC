import { Component, OnInit } from "@angular/core";
import { Product } from "./product";
import { CategoryService } from "../Category/category.service";
import { Category } from "../Category/Category";
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { ProductService } from './product.service';

@Component({
    templateUrl: "./product-detail.component.html"
})

export class ProductDetailComponent implements OnInit {
    product: Product;
    messages: string[] = [];
    categories: Category[] = [];

    constructor(
        private categotyService: CategoryService,
        private productService: ProductService,
        private route: ActivatedRoute,
        private location: Location) { }

    ngOnInit() {
        this.route.params.forEach((params: Params) => {
            if (params['id'] !== undefined) {
                if (params['id'] != -1) {
                    this.productService.getProduct(params['id'])
                        .subscribe(product => this.product = product,
                            errors => this.handleErrors(errors));
                }
                else {
                    this.product = new Product();
                    this.product.price = 1;
                    this.product.categoryId = 1;
                    this.product.url = "http://www.example.com";
                }
            }
        });

        this.getCategories();
    }

    getCategories() {
        this.categotyService.getCategories()
            .subscribe(categories => this.categories = categories,
                errors => this.handleErrors(errors));
    }

    goBack() {
        this.location.back();
    }

    private updateProduct(product: Product) {
        this.productService.updateProduct(product)
            .subscribe(() => this.goBack(),
                errors => this.handleErrors(errors));
    }

    private addProduct(product: Product) {
        this.productService.addProduct(product)
            .subscribe(() => this.goBack(),
                errors => this.handleErrors(errors));
    }

    saveProduct() {
        if (this.product) {
            if (this.product.productId) {
                this.updateProduct(this.product);
            }
            else {
                this.addProduct(this.product);
            }
        }
    }

    private handleErrors(errors: any) {
        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}