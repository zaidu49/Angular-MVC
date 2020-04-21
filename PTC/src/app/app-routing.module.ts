import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { ProductListComponent } from "./Product/product-list.component"

const routes: Routes = [
    {
        path: 'productList',
        component: ProductListComponent
    },
    {
        path: 'Product/Product',
        redirectTo: 'productList'
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }