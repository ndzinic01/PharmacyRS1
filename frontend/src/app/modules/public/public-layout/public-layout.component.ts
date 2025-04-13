import {Component, HostListener} from '@angular/core';
import {Router} from '@angular/router';
import {SearchService} from '../../../services/search.service';
import {ProductServicesService} from '../../../services/product-services.service';
interface Product {
  id:number;
  name: string;
  description: string;
  price: number;
  quantityInStock: number;
  picture?: string;
  isDiscounted: boolean;
  discountPercentage: number;
  discountedPrice?: number; // ovo mi sami računamo
}
@Component({
  selector: 'app-public-layout',
  standalone: false,

  templateUrl: './public-layout.component.html',
  styleUrl: './public-layout.component.scss'
})
export class PublicLayoutComponent {
  constructor(private router:Router, private  searchService: SearchService,private productService: ProductServicesService) {
  }
  navigateToNewPage ():void {
    this.router.navigate(['./modules/auth/login']);
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    const navigation = document.querySelector('.navigation');
    if (window.scrollY > 100) {  // Kad skrolaš više od 100px od vrha
      navigation?.classList.add('sticky');
    } else {
      navigation?.classList.remove('sticky');
    }
  }

  searchQuery: string = '';
  searchResults: Product[] = [];

  /*onSearch(): void {
    const query = this.searchQuery.toLowerCase().trim();

    if (!query) {
      this.searchResults = [];
      return;
    }

    this.productService.searchProducts(query).subscribe({
      next: (products) => {
        const queryLetters = new Set(query);

        this.searchResults = products.filter(product => {
          const name = product.name.toLowerCase();
          return [...queryLetters].some(letter => name.includes(letter));
        });
      },
      error: (err) => {
        console.error('Greška prilikom učitavanja proizvoda:', err);
      }
    });
  }*/


  onSearch(): void {
    const query = this.searchQuery.toLowerCase().trim();

    if (!query) {
      this.searchResults = [];
      return;
    }

    this.productService.searchProducts(query).subscribe({
      next: (products) => {
        this.searchResults = products.filter(product => product.name.toLowerCase().includes(query));
      },
      error: (err) => {
        console.error('Greška prilikom učitavanja proizvoda:', err);
      }
    });

    // Nakon pretrage, idi na stranicu sa rezultatima
    this.goToSearchResults(query);
  }

  goToSearchResults(query: string): void {
    this.router.navigate(['/searchresults'], { queryParams: { q: query } });
  }

}
