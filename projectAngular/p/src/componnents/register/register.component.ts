import { Component } from '@angular/core';
import { CustomerService } from '../../app/services/customer.service';
import { Customer } from '../../app/classes/customer';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { CartService } from '../../app/services/cart.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  allCustomers: Customer[] = [];
  customer: Customer = new Customer();
  phonePrefix: string = '';  // קידומת טלפון
  phoneNumber: string = '';  // המשך מספר
  constructor(public rc: CustomerService, public cart: CartService) { }

  registerC() {
    this.customer.phone = this.phonePrefix + this.phoneNumber;
    this.rc.register(this.customer).subscribe(
      c => {
        console.log(c);

        this.rc.currentCustomer.customerName = c.customerName;
        this.cart.currentCustomer = c;

        console.log(this.rc.currentCustomer.customerId + " current customer id");

        Swal.fire('Success', 'Customer registered successfully!', 'success');

      },
      err => {
        console.log("error: " + err.message);
      }
    );
    console.log("finished");
  }
  // רשימת הקידומות התקפות בישראל
  phonePrefixes: string[] = [
    '050', '051', '052', '053', '054', '055', '056', '057', '058', '059'
  ];
}

