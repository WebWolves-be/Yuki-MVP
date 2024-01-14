import {Component} from '@angular/core';
import {MatCardModule} from "@angular/material/card";

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [
    MatCardModule
  ],
  templateUrl: './companies.component.html',
  styleUrl: './companies.component.scss'
})
export class CompaniesComponent {

}
