import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { BeautyAndCareComponent } from './beauty-and-care/beauty-and-care.component';
import { ChildcareComponent } from './childcare/childcare.component';
import { DevicesComponent } from './devices/devices.component';
import { DiscountComponent } from './discount/discount.component';
import { InfoComponent } from './info/info.component';
import { ContactComponent } from './info/contact/contact.component';
import { NewInComponent } from './new-in/new-in.component';
import { SkinProtectionComponent } from './skin-protection/skin-protection.component';
import { YourHealthComponent } from './your-health/your-health.component';
import { PublicLayoutComponent } from './public-layout/public-layout.component';
import { HomeComponent } from './home/home.component';
import {MatIconModule} from '@angular/material/icon';
import { WishListComponent } from './wish-list/wish-list.component';
import { AdvertisementComponent } from './advertisement/advertisement.component';
import { DiscountedProductsComponent } from './discounted-products/discounted-products.component';
import { ProductsComponent } from './products/products.component';
import {FormsModule} from '@angular/forms';
import { SearchResultsComponent } from './search-results/search-results.component';


@NgModule({
  declarations: [
    BeautyAndCareComponent,
    ChildcareComponent,
    DevicesComponent,
    DiscountComponent,
    InfoComponent,
    ContactComponent,
    NewInComponent,
    SkinProtectionComponent,
    YourHealthComponent,
    PublicLayoutComponent,
    HomeComponent,
    WishListComponent,
    AdvertisementComponent,
    DiscountedProductsComponent,
    ProductsComponent,
    SearchResultsComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    MatIconModule,
    FormsModule,



  ]
})
export class PublicModule { }
