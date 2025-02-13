"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var app_routing_module_1 = require("./app-routing.module");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var product_list_component_1 = require("./Product/product-list.component");
var product_service_1 = require("./Product/product.service");
var category_service_1 = require("./Category/category.service");
var product_detail_component_1 = require("./Product/product-detail.component");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule,
                app_routing_module_1.AppRoutingModule,
                http_1.HttpModule,
                forms_1.FormsModule
            ],
            declarations: [
                app_component_1.AppComponent,
                product_list_component_1.ProductListComponent,
                product_detail_component_1.ProductDetailComponent
            ],
            bootstrap: [
                app_component_1.AppComponent
            ],
            providers: [
                product_service_1.ProductService,
                category_service_1.CategoryService
            ]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map