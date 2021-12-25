import { Component, OnInit, Input } from '@angular/core';
import { CartItem } from '../dependencies/models/CartItem';
import { ShoppingCartServiceService } from '../dependencies/services/shopping-cart-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  @Input() state: any;

  constructor(private shoppingCartService: ShoppingCartServiceService) { }

  ngOnInit(): void {
  }

  //Remove Items from Cart
  removeItemsFromCart(item: CartItem): void {
    this.shoppingCartService.removeCartItem(item);
  }

  onSubmit(){
    this.shoppingCartService.checkout();
  }

}
