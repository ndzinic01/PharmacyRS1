import { Component, OnInit } from '@angular/core';
import {CurrencyPipe} from '@angular/common';

// Definišemo interfejs za stavke na wishlisti
interface WishlistItem {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
}

@Component({
  /*imports: [
    CurrencyPipe
  ],*/
  selector: 'app-wish-list',
  standalone: false,
  styleUrl: './wish-list.component.scss',
  templateUrl: './wish-list.component.html'
})
export class WishListComponent implements OnInit {
  // Inicijalizujemo listu želja
  wishlist: WishlistItem[] = [];

  constructor() {}

  ngOnInit(): void {
    this.loadWishlist(); // Učitavamo podatke na inicijalizaciji
  }

  // Metoda za učitavanje liste želja
  loadWishlist(): void {
    this.wishlist = [
      {
        id: 1,
        name: 'Product 1',
        description: 'This is a sample product.',
        price: 29.99,
        imageUrl: 'https://via.placeholder.com/150'
      },
      {
        id: 2,
        name: 'Product 2',
        description: 'Another sample product.',
        price: 49.99,
        imageUrl: 'https://via.placeholder.com/150'
      }
    ];
  }

  // Metoda za uklanjanje stavki sa liste želja
  removeFromWishlist(itemId: number): void {
    this.wishlist = this.wishlist.filter(item => item.id !== itemId);
  }
}
