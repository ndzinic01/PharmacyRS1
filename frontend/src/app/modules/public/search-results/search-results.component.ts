import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ProductServicesService} from '../../../services/product-services.service';

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture?: string; // ← bitno: isto kao u servisu
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number;
}


@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  standalone: false,
  styleUrl: './search-results.component.css'
})
export class SearchResultsComponent implements OnInit {
 /* product: Product | null = null;  // Ovdje čuvamo podatke o proizvodu

  constructor(
    private route: ActivatedRoute,  // Koristi ActivatedRoute za pristup parametrima URL-a
    private productService: ProductServicesService  // Servis za pretragu proizvoda
  ) {}

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');

    // Proveri da li je 'id' validan broj
    const id = Number(productId);

    if (!isNaN(id)) {
      // Ako je ID validan broj, učitaj proizvod
      this.productService.getProductById(id).subscribe({
        next: (result) => {
          this.product = result;
        },
        error: (err) => {
          console.error('Greška pri učitavanju proizvoda:', err);
        }
      });
    } else {
      // Ako ID nije validan, loguj grešku ili prikaži korisniku odgovarajuću poruku
      console.error('ID proizvoda nije validan:', productId);
    }
  }*/
  product: Product | null = null;
  /*
   *onstructor(
     private productService: ProductServicesService,
     private route: ActivatedRoute
   ) {}

  ngOnInit(): void {
     const productId = Number(this.route.snapshot.paramMap.get('id')); // Uzima ID iz URL-a
     if (productId) {
       this.productService.getProductById(productId).subscribe({
         next: (result) => {
           this.product = result;
         },
         error: (err) => {
           console.error('Greška pri učitavanju proizvoda:', err);
         },
       });
     } else {
       console.error('ID proizvoda nije pronađen u URL-u');
     }
   }*/



  searchQuery: string = '';
  searchResults: Product[] = [];

  constructor(
    private productService: ProductServicesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const productId = Number(this.route.snapshot.paramMap.get('id')); // Pravilno uzimanje parametra iz URL-a
    if (productId) {
      this.productService.getProductById(productId).subscribe({
        next: (result) => {
          this.product = result;
        },
        error: (err) => {
          console.error('Greška pri učitavanju proizvoda:', err);
        },
      });
    } else {
      console.error('ID proizvoda nije pronađen u URL-u');
    }
  }


  searchProducts(query: string): void {
    this.productService.searchProducts(query).subscribe({
      next: (products) => {
        this.searchResults = products;
      },
      error: (err) => {
        console.error('Greška prilikom učitavanja proizvoda:', err);
      }
    });
  }
}
