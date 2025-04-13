import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ProductServicesService} from '../../../services/product-services.service';
import {NewInProductsService} from '../../../services/new-in-products.service';

interface NewProduct {
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture: string;
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number; // Ako ima popust, izračunavamo cijenu sa popustom
}

interface NewInProduct {
  id: number;
  name: string;
  picture: string;
  price: number;
  dateAdded: string;
}

@Component({
  selector: 'app-new-in',
  standalone: false,
  templateUrl: './new-in.component.html',
  styleUrl: './new-in.component.css'
})
export class NewInComponent {
  latestProducts: NewInProduct[] = [];

  currentIndex = 0;
  visibleCards = 4;
  cardWidth = 250;
  transformValue = 'translateX(0px)';

  constructor(private productService: NewInProductsService) {}

  ngOnInit() {
    this.loadLatestProducts();
  }

  loadLatestProducts() {
    this.productService.getLatestProducts().subscribe(data => {
      this.latestProducts = data;
    });
  }

  nextProduct() {
    const maxIndex = this.latestProducts.length - this.visibleCards;
    if (this.currentIndex < maxIndex) {
      this.currentIndex++;
      this.updateTransform();
    }
  }

  previousProduct() {
    if (this.currentIndex > 0) {
      this.currentIndex--;
      this.updateTransform();
    }
  }

  updateTransform() {
    const shift = -this.currentIndex * this.cardWidth;
    this.transformValue = `translateX(${shift}px)`;
  }
}
