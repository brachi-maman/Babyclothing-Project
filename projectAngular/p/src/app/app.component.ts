import { Component } from '@angular/core';
import { RegisterComponent } from '../componnents/register/register.component';
import { LoginComponent } from '../componnents/login/login.component';
import { FilterComponent } from '../componnents/filter/filter.component';
import { HomeComponent } from '../componnents/home/home.component';
import { RouterLink, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HomeComponent,RouterLink,RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'project';
}
