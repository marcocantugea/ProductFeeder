import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ErrorComponent } from './main/error/error.component';
import { SuppliersComponent } from './pages/suppliers/suppliers.component';
import { BrandsComponent } from './pages/brands/brands.component';
import { ProductsComponent } from './pages/products/products.component';
import { FeedsComponent } from './pages/feeds/feeds.component';


const appRoutes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'suppliers', component: SuppliersComponent },
  { path: 'brands', component: BrandsComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'feeds', component: FeedsComponent },
  { path: '**', component: ErrorComponent }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ]
})
export class AppRoutingModule { }
