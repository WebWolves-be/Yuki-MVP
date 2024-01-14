import {Component} from '@angular/core';
import {CategoriesComponent} from "../categories/categories.component";
import {CompaniesComponent} from "../companies/companies.component";

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [
    CategoriesComponent,
    CompaniesComponent
  ],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.scss'
})
export class OverviewComponent {

}
