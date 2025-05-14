import { Component, NgModule, OnInit } from '@angular/core';
import { ProductService } from '../../app/services/product.service';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import { Product } from '../../app/classes/product';
import { Customer } from '../../app/classes/customer';
import { CartService } from '../../app/services/cart.service';
import { FormsModule, ɵInternalFormsSharedModule } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Location } from '@angular/common';
import { ChangeColorByAmountDirective } from '../../app/directive/change-color-by-amount.directive';
import { BtnComponent } from '../btn/btn.component';
import { PricePipe } from '../../app/price.pipe';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-more-details',
  standalone: true,
  imports: [FormsModule, ChangeColorByAmountDirective, RouterOutlet, BtnComponent, PricePipe],
  templateUrl: './more-details.component.html',
  styleUrl: './more-details.component.css',

})
export class MoreDetailsComponent implements OnInit {
  constructor(public ps: ProductService, public ar: ActivatedRoute, public r: Router, public cart: CartService
    , public location: Location
  ) {

    this.ps.getAllProduct().pipe(
      map(products => products.find(p => p.productId == this.productId))
    ).subscribe(c => {
      if (c) {
        this.current = c;
      } else {
        alert("כתובת שגויה");
      }
    });
  }
  productId: number = 0;
  current: Product = new Product();
  currentCustomer: Customer = new Customer();
  allProducts: Product[] = [];
  amount: number = 0; // default amount to add to cart is 1


  ngOnInit(): void {
    console.log(this.productId);

    this.getAllProducts()
    this.ar.params.subscribe(params => {
      this.productId = Number(params['productId']); // המרה למספר בצורה בטוחה
      console.log(this.productId);

      let product = this.allProducts.find(p => p.productId === this.productId)
      if (product) {
        this.current = product;
        console.log('Product details:', this.current)
      } else {
        console.log('Product not found')
      }
    });
  }




  getAllProducts() {
    this.ps.getAllProduct().subscribe(
      p => {
        console.log(p);

        this.allProducts = p
      },
      err => {
        console.log("Error: " + err.message)
      }
    )
    console.log("Finished fetching products")
  }
  addToCart(p: Product, amount: number) {

    if (!this.cart.Qu[p.productId])
      this.cart.Qu[p.productId] = 0
    this.cart.Qu[p.productId] += amount
    if(this.amount > 0){
    Swal.fire('Success', 'Product added to cart successfully!', 'success');
    }
    console.log(this.cart.Qu);
  }
  goBack() {
    this.location.back();
  }

}

