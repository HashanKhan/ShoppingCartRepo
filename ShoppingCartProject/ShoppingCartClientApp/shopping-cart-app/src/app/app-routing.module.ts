import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'shoppingCart', pathMatch: 'full'},
  { path: 'shoppingCart', loadChildren: () => import('./shopping-cart/shopping-cart.module').then(m => m.ShoppingCartModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
