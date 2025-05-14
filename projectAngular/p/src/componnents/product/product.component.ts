import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../app/services/product.service';
import { Product } from '../../app/classes/product';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  constructor(public ps: ProductService , public r: Router) { }

  ngOnInit(): void {
    this.getAllProducts();
  }

  allProducts: Array<Product> = new Array<Product>();

  getAllProducts() {
    this.ps.getAllNewsProduct().subscribe(
      p => {
        console.log(p);
        this.allProducts = p;
      },
      err => {
        console.log("Error: " + err.message);
      }
    );
    console.log("Finished fetching products");
  }
  more(p:Product)
{
  this.r.navigate(['more.../'+p.productId])

  // this.model=true
  // this.r.navigate(['allProducts/more-details.../'+p.productId])
}
}
