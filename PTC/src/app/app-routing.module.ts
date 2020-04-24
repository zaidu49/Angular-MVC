import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { ProductListComponent } from "./Product/product-list.component"
import { ProductDetailComponent } from './Product/product-detail.component';

const routes: Routes = [
    {
        path: 'productList',
        component: ProductListComponent
    },
    {
        path: 'Product/Product',
        redirectTo: 'productList'
    },
    {
        path: 'productDetail/:id',
        component: ProductDetailComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }