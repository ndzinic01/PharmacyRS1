import { Component, OnInit } from '@angular/core';
import {DiscountedProductsService} from '../../../services/discounted-products.service';
import { HttpClient } from '@angular/common/http';

interface DiscountedProduct {
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture: string;
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number; // ovo mi sami računamo
}


@Component({
  selector: 'app-discounted-products',
  templateUrl: './discounted-products.component.html',
  standalone: false,
  styleUrls: ['./discounted-products.component.css']
})
export class DiscountedProductsComponent implements OnInit {
  //discountedProducts: any[] = []; // Lista sniženih proizvoda
  discountedProducts: DiscountedProduct[] = [];

  constructor(private productService: DiscountedProductsService) {}

  ngOnInit() {
    this.loadDiscountedProducts();
  }

 /* loadDiscountedProducts() {
    this.productService.getDiscountedProducts().subscribe(data => {
      this.discountedProducts = data;
    });
  }*/
  loadDiscountedProducts() {
    this.productService.getDiscountedProducts().subscribe((data: any[]) => {
      this.discountedProducts = data.map(product => {
        const discountedPrice = product.isDiscounted && product.discountPercentage
          ? product.price - (product.price * product.discountPercentage / 100)
          : product.price;

        return {
          ...product,
          discountedPrice
        } as DiscountedProduct;
      });
    });
  }






  currentIndex = 0;
  visibleCards = 4; // koliko ih se prikazuje odjednom
  cardWidth = 250; // mora odgovarati širini jednog product-card sa marginama
  transformValue = 'translateX(0px)';

  nextProduct() {
    const maxIndex = this.discountedProducts.length - this.visibleCards;
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






