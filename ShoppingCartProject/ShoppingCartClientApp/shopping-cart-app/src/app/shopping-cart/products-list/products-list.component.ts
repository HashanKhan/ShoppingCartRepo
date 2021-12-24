import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
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

  product_cat = new FormControl();

  value: string = '';

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private shoppingCartService: ShoppingCartServiceService, public dialog: MatDialog) {
    this.getAllProductCategories();
   }

  ngOnInit(): void {
  }

  //Filter class for the search field.
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    // this.dataSource.filter = filterValue.trim().toLowerCase();

    // if (this.dataSource.paginator) {
    //   this.dataSource.paginator.firstPage();
    // }
  }

  //Get all products method.
  getAllProductCategories(){
    this.shoppingCartService.getAllProductCategories().subscribe((res: any[]) => {
      console.log("Products", res);
      this.productCategories = res;
    });
  }

  //Add Items to Cart
  // addItemToCart(item: CartItem) {
  //   this.shoppingCartService.addCartItem(item);
  // }

  //Clear the search field.
  clear(){
    this.value='';
    // this.getAllBooks();
  }

}
