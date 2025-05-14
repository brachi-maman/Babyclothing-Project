import { Component } from '@angular/core';
import { Product } from '../../app/classes/product';
import { ProductService } from '../../app/services/product.service';
import { Category } from '../../app/classes/category';
import { Company } from '../../app/classes/company';
import { CategoryService } from '../../app/services/category.service';
import { CompanyService } from '../../app/services/company.service';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { PricePipe } from '../../app/price.pipe';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [FormsModule, RouterOutlet, PricePipe, NgClass],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css'
})
export class FilterComponent {
  // אובייקט לסינון עם ערכי ברירת מחדל
  filterCriteria = {
    categoryId: null,
    companyId: null,
    gender: null
  };
  ChoosenSeason = "all";
  ChoosenSize = "all";
  minPrice = 0; 
  maxPrice = 0;
  selectedPriceRange: number = this.maxPrice;

  // מערכים לשמירת נתונים שהתקבלו מהשרת
  categories: Category[] = [];
  companies: Company[] = [];
  allProducts: Product[] = [];
  seasons: string[] = ['summer', 'winter' , 'trans'];
  sizes: string[] = ['0-3', '03-6', '0-9','0-2y','0-9','09-12','	1-2y','NB'];


  // הכנסת השירותים דרך ה-Constructor
  constructor(
    public productService: ProductService,
    public categoryService: CategoryService,
    public companyService: CompanyService,
    public r: Router

  
  ) { }

  // פונקציה שמופעלת ברגע שהקומפוננט נטען
  ngOnInit(): void {
      // קבלת קטגוריות מהשירות ושמירתן במשתנה
      this.categoryService.getAllCategories().subscribe(
        data => this.categories = data,
        err => console.error('Error fetching categories:', err.message)
      );
  
      // קבלת חברות מהשירות ושמירתן במשתנה
      this.companyService.getAllCompanies().subscribe(
        data => this.companies = data,
        err => console.error('Error fetching companies:', err.message)
      );
  
      // קבלת כל המוצרים
      this.productService.getAllProduct().subscribe(
        products => {
          console.log('Products:', products);
          this.allProducts = products;
          this.minPrice = Math.min(...this.allProducts.map(p => p.price));
          this.maxPrice = Math.max(...this.allProducts.map(p => p.price));
        },
        err => console.error('Error fetching products:', err.message)
      )
  }
 
  // פונקציה לסינון מוצרים בהתאם לקריטריונים שנבחרו
  filterProducts() {
    console.log('Applying filters:', this.filterCriteria);
    this.productService.getByFilters(this.filterCriteria).subscribe(
      filteredProducts => {
        console.log('Filtered products:', filteredProducts);
        this.allProducts = filteredProducts;
        if (this.ChoosenSeason && this.ChoosenSeason !== "all") {
        this.allProducts = this.allProducts.filter(p => p.season === this.ChoosenSeason);
        }
        if (this.ChoosenSize && this.ChoosenSize !== "all") {
          this.allProducts = this.allProducts.filter(p => p.size === this.ChoosenSize);
          }
      this.allProducts = this.allProducts.filter(p => p.price <= this.selectedPriceRange);
      },
      err =>
        console.error('Error filtering products:', err.message)
    );
  }
  
  filterBySeason() {
    if (this.ChoosenSeason) {
    // Add your logic here to filter products by season
    this.allProducts = this.allProducts.filter(p => p.season === this.ChoosenSeason);
    }
    else{
      this.allProducts = this.allProducts;
    }

  }

  getAllSeasons(){
    this.seasons = ['summer', 'winter', 'trans'];
    return this.seasons;  
    
  }
 
  more(p:Product)
  {
    console.log(p.productId);
     this.r.navigate(['more.../'+p.productId])
  }
  toCart()
  {
       this.r.navigate(['more-details/cart/'])
  }
}

