import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, merge, Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CartItem } from '../models/CartItem';
import { Product } from '../models/product';
import { ProductCategory } from '../models/productCategory';
import { StateTree } from '../models/stateTree';
import { scan, startWith, map, tap, combineLatest, switchMap, shareReplay, debounceTime, catchError } from 'rxjs/operators';
import { v4 as uuid } from 'uuid';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartServiceService {
  apiUrl: string;

  stateTree = new BehaviorSubject<StateTree>(null);
  checkoutTrigger = new BehaviorSubject<boolean>(false);
  cartAdd = new Subject<CartItem>();
  cartRemove = new Subject<CartItem>();

  constructor(private http: HttpClient) { 
    this.apiUrl = environment.BaseUrl;
  }

  //Get all productCategories method.
  getAllProductCategories(): Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(this.apiUrl + "products");
  }

  getAllProductsForCategory(categoryID: number): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl + "products/" + categoryID);
  }

  //The uuid package will be used to assign random ids for the items in the cart.
  //Scan the shopping cart for productItems.
  private get cartItems(): Observable<CartItem[]> {
    return merge(this.cartAdd, this.cartRemove).pipe(
      startWith([]),
      scan((acc: CartItem[], item: CartItem) => {
        if (item) {
          if (item.remove) {
            return [...acc.filter(i => i.uuid !== item.uuid)];
          }
          return [...acc, item];
        }
      })
    );
  }

  //Get the Total value.
  private get totalAmount(): Observable<any> {
    return this.cartItems.pipe(
      map(items => {
        let total = 0;
        for (const i of items) {
          total += i.price;
        }
        return total;
      }),
      map(cost => ({
        totl: cost
      })
      )
    );
  }

  //Creating the state of the shopping cart, store, total amount and checkout.
  state: Observable<StateTree> = this.stateTree.pipe(
    switchMap(() => this.getAllProductsForCategory(0).pipe(
      combineLatest([this.cartItems, this.totalAmount, this.checkoutTrigger]),
      debounceTime(0),
    )),
    map(([store, cart, tot, checkout]: any) => ({ store, cart, tot, checkout })),
    tap(state => {
      if (state.checkout) {
        this.updateShoppingCart(state.cart).subscribe(res => {
          if(res == "The Cart is Updated."){
            this.checkoutTrigger.next(false);
            
          }
          else{
            this.checkoutTrigger.next(false);
            sessionStorage.setItem('error_res', res);
          }
        });
      }
    }),
    //Just sharing only for the App.
    shareReplay(1)
  );

  //Add products to cart method.
  addCartItem(item: CartItem) {
    this.cartAdd.next({ ...item, uuid: uuid() });
  }

  //Remove products from cart method.
  removeCartItem(item: CartItem) {
    this.cartRemove.next({ ...item, remove: true });
  }

  //Trigger the checkout.
  checkout() {
    this.checkoutTrigger.next(true);
  }

  //Update the shopping Cart.
  updateShoppingCart(cart: CartItem[]): Observable<string>{
    return this.http.post(this.apiUrl + "products/" + "checkAvailability", cart, {responseType: 'text'});
  }

  //Get all cartItems method.
  getAllCartItems(): Observable<Cart[]>{
    return this.http.get<Cart[]>(this.apiUrl + "cart");
  }
}
