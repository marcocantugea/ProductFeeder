import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MenuComponent } from './main/menu/menu.component';
import { SuppliersComponent } from './pages/suppliers/suppliers.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ErrorComponent } from './main/error/error.component'
import { AppRoutingModule } from './app-routing.module';
import { BrandsComponent } from './pages/brands/brands.component';
import { ProductsComponent } from './pages/products/products.component';
import { FeedsComponent } from './pages/feeds/feeds.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SuppliersComponent,
    DashboardComponent,
    ErrorComponent,
    BrandsComponent,
    ProductsComponent,
    FeedsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
