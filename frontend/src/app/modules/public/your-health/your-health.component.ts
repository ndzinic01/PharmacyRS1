import { Component, OnInit } from '@angular/core';
import { ProductServicesService } from '../../../services/product-services.service';
import { CategoryService } from '../../../services/category.service';

export interface Product {
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture?: string;
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number; // ovo mi sami računamo
}

// models/category.model.ts
export interface Category {
  id: number;
  name: string;
  description?: string;
}


@Component({
  selector: 'app-your-health',
  standalone: false,
  templateUrl: './your-health.component.html',
  styleUrls: ['./your-health.component.css']  // Ispravka ovdje
})
export class YourHealthComponent implements OnInit {
  products: Product[] = [];

  constructor(private productServices: ProductServicesService) {}

  ngOnInit(): void {
    // Specifična logika za učitavanje proizvoda iz kategorije "Your Health"
    this.productServices.getProductsByCategory(1).subscribe(products => { // ID "1" za "Your Health"
      this.products = products;
    });
  }

  getDiscountedPrice(product: Product): number {
    if (product.isDiscounted && product.discountPercentage) {
      return product.price - (product.price * product.discountPercentage / 100);
    }
    return product.price;
  }

}
