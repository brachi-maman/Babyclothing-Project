import { Injectable } from '@angular/core';
import { cartProduct } from '../classes/cartProduct';
import { Customer } from '../classes/customer';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { OrderDetail } from '../classes/orderDetails';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  totalPrice: number = 0;
  // totalQuantity: number = 0;
  public currentCustomer:Customer = new Customer();
  
  constructor(private http: HttpClient) { }

  Qu: {[key: number]: number} = {};
  //cart product 
  allProductsInCartService: cartProduct[] = [];
  //order details product that will be sent to the server for order
  allorderDetails : OrderDetail [] = [];

  //calcute total price of the cart
    calculateTotalPrice(customer: Customer, ordersDetails: OrderDetail[]): Observable<number> {

      const requestPayload = {
        customer: customer,
        ordersDetails: ordersDetails,
      };
    //the link to the server to the function that will calculate the total price of the cart
      return this.http.post<number>("https://localhost:7145/api/OrderDetails/CalculateTotalPrice", requestPayload);
    }
}
