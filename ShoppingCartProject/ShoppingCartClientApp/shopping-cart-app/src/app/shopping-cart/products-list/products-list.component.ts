import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Cart } from '../dependencies/models/cart';
import { CartItem } from '../dependencies/models/CartItem';
import { Product } from '../dependencies/models/product';
import { ProductCategory } from '../dependencies/models/productCategory';
import { ShoppingCartServiceService } from '../dependencies/services/shopping-cart-service.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'price', 'add_to_cart'];
  dataSource: MatTableDataSource<Product>;
  products: Product[] = [];
  productCategories: ProductCategory[] = [];
  cartItems: Cart[] = [];
  cartState = this.shoppingCartService.state;
  dataSource1: MatTableDataSource<Cart>;
  displayedColumns1: string[] = ['productName', 'quantity', 'subTotal', 'productId', 'productCategoryId'];

  selectedValue: number;

  value: string = '';

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private shoppingCartService: ShoppingCartServiceService, public dialog: MatDialog) {
    this.getAllProductCategories();
    this.getAllCartItems();
   }

  ngOnInit(): void {
  }

  //Filter class for the search field.
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  //Get all productCategories method.
  getAllProductCategories(){
    this.shoppingCartService.getAllProductCategories().subscribe((res: any[]) => {
      this.productCategories = res;
    });
  }

  //Get all cartItems method.
  getAllCartItems(){
    this.shoppingCartService.getAllCartItems().subscribe((res: any[]) => {
      this.cartItems = res;
      this.dataSource1 = new MatTableDataSource(this.cartItems);

      this.dataSource1.sort = this.sort;
    })
  }

  //Get all products per category method.
  getAllProductsForCategory(categoryID: number){
    this.shoppingCartService.getAllProductsForCategory(categoryID).subscribe((res: any[]) => {
      this.products = res;
      this.dataSource = new MatTableDataSource(this.products);

      this.dataSource.sort = this.sort;
    });
  }

  //Add Items to Cart
  addItemToCart(item: CartItem) {
    this.shoppingCartService.addCartItem(item);
  }

  //Clear the search field.
  clear(){
    this.value='';
  }

}
