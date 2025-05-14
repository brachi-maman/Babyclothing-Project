import { Routes } from '@angular/router';
import { MoreDetailsComponent } from '../componnents/more-details/more-details.component';
import { FilterComponent } from '../componnents/filter/filter.component';
import { CartComponent } from '../componnents/cart/cart.component';
import { HomeComponent } from '../componnents/home/home.component';
import { RegisterComponent } from '../componnents/register/register.component';
import { LoginComponent } from '../componnents/login/login.component';
import { UploadImageComponent } from '../componnents/upload-image/upload-image.component';
import { MapComponent } from '../componnents/map/map.component';
import { SizeComponent } from '../componnents/size/size.component';
import { ProductComponent } from '../componnents/product/product.component';

export const routes: Routes = [
    { path: '', component: FilterComponent },
    { path: 'home', component: HomeComponent, title: 'דף הבית' },
    { path: 'register', component: RegisterComponent, title: 'הרשמה' },
    { path: 'home', component: HomeComponent, title: 'דף הבית' },
    { path: 'filter', component: FilterComponent, title: 'מוצרים' },
    { path: 'more.../:productId', component: MoreDetailsComponent, title: 'פרטים נוספים' },
    { path: 'login', component: LoginComponent, title: 'התחברות' },
    { path: 'more-details/cart', component: CartComponent },
    { path: 'upload', component: UploadImageComponent, title: 'התחברות' },
    { path: 'map', component: MapComponent },
    { path: 'size', component: SizeComponent },
    { path: 'cart', component: CartComponent },
    { path: '**', component: ProductComponent }

]
