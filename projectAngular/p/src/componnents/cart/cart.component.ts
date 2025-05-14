import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../app/classes/product';
import { Customer } from '../../app/classes/customer';
import { CartService } from '../../app/services/cart.service';
import { cartProduct } from '../../app/classes/cartProduct';
import { CustomerService } from '../../app/services/customer.service';
import Swal from 'sweetalert2';
import { OrderDetail } from '../../app/classes/orderDetails';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {
  constructor(public ps: ProductService, public ar: ActivatedRoute, public cart: CartService, public cc: CustomerService) { }

  productId: number = 0;
  current: Product = new Product();
  currentCustomer: Customer = new Customer();
  allProducts: Product[] = [];
  allProductsInCart: cartProduct[] = [];

  ngOnInit(): void {
    this.getAllProducts().then(() => {
      console.log('All products:', this.allProducts);
      this.cartV(); // קרא ל-cartV לאחר טעינת המוצרים
      this.populateOrderDetails();
    })
  }

  getAllProducts(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.ps.getAllProduct().subscribe(
        p => {
          console.log(p);
          this.allProducts = p;
          resolve(); // סיים את הבטחה
        },
        err => {
          console.log("Error: " + err.message);
          reject(err); // החזר שגיאה אם יש
        }
      )
    })
  }


  add1(p: cartProduct) {
    if (!this.cart.Qu[p.productId]) {
      this.cart.Qu[p.productId] = 0;
    }
    this.cart.Qu[p.productId]++;
    this.populateOrderDetails(); // עדכן את allorderDetails לאחר השינוי
    Swal.fire('Success', 'Product added to cart successfully!', 'success');
    console.log(this.cart.Qu);
  }

  les1(p: cartProduct) {
    if (this.cart.Qu[p.productId] > 0) {
      Swal.fire({
        title: 'Are you sure you want to delete this product from the cart?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'yes, delete',
        cancelButtonText: 'no'
      }).then((result) => {
        if (result.isConfirmed) {
          // כאן מבצעים את הפעולה אם המשתמש לחץ על "אישור"
          Swal.fire('Deleted!', '  the product deleted.', 'success');
          this.cart.Qu[p.productId]--;
        }
      });

      if (this.cart.Qu[p.productId] === 0) {
        delete this.cart.Qu[p.productId]; // מחיקת מוצר מה-Qu אם הכמות היא 0
      }
    }
    this.populateOrderDetails(); // עדכן את allorderDetails לאחר השינוי
    console.log(this.cart.Qu);
  }


  cartV(): cartProduct[] {



    for (let productId in this.cart.Qu) {
      const numericProductId = Number(productId); // המרת productId למספר
      console.log('Checking productId:', numericProductId);
      const product = this.allProducts.find(
        p => p.productId === numericProductId
      );

      if (product) {
        console.log('Product found:', product);
        this.allProductsInCart.push(
          new cartProduct(
            product.productId,
            product.productName,
            product.price,
            this.cart.Qu[productId] || 0,
            product.descriptionProducts || 'No description',
            new Date(),
            product.imageUrl || 'No image',
            this.cc.currentCustomer
          )
        );
        if (this.cart.Qu[productId]) {
          console.log("Found quantity for productId:", productId);
        } else {
          console.error("ProductId not found:", productId);
        }



      } else {
        console.error(`Product ID ${productId} not found in allProducts.`);
      }
    }


    console.log('allProductsInCart:', this.allProductsInCart);



    return this.allProductsInCart;
  }


  populateOrderDetails(): void {
    // איפוס הרשימה כדי למנוע כפילויות
    this.cart.allorderDetails = [];
    for (let productId in this.cart.Qu) {
      const quantity = this.cart.Qu[productId]; // כמות עבור המוצר הנוכחי
      const numericProductId = Number(productId); // המרת productId למספר

      if (quantity > 0) {
        // יצירת אובייקט OrderDetail והוספתו לרשימה
        const orderDetail = new OrderDetail(
          0, // orderDetailId (placeholder)
          0, // orderId (placeholder)
          numericProductId,
          quantity
        );
        this.cart.allorderDetails.push(orderDetail);
        console.log('Added OrderDetail:', orderDetail);
      }
    }

    console.log('Final allorderDetails:', this.cart.allorderDetails);
  }
  checkout() {
    console.log(this.cart.allorderDetails);
    this.cart.calculateTotalPrice(this.cart.currentCustomer, this.cart.allorderDetails)
      .subscribe({
        next: (price) => {
          this.cart.totalPrice = price;
          Swal.fire('Success', `Payment successful! Total Price: ${price}`, 'success');
          this.cart.allorderDetails = [];
          this.cart.Qu = {};
          this.allProductsInCart = [];
        },
        error: (error) => {
          console.error('Error:', error);
          Swal.fire('Error', 'Payment failed!', 'error');
        }
      });
  }



}

