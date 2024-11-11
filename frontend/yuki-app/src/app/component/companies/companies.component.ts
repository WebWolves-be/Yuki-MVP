import {Component, OnInit} from '@angular/core';
import {MatCardModule} from "@angular/material/card";
import {FacadeService} from "../../facade/facade.service";
import {MatListModule} from "@angular/material/list";
import {AsyncPipe, NgForOf, NgIf} from "@angular/common";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatDialog} from "@angular/material/dialog";
import {AddRuleDialogComponent} from "../add-rule-dialog/add-rule-dialog.component";
import {Company} from "../../model/company.interface";
import {MatChipsModule} from "@angular/material/chips";

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [
    MatCardModule,
    MatListModule,
    NgIf,
    AsyncPipe,
    NgForOf,
    MatIconModule,
    MatButtonModule,
    MatChipsModule
  ],
  templateUrl: './companies.component.html',
  styleUrl: './companies.component.scss'
})
export class CompaniesComponent implements OnInit {

  companiesWithoutRule$ = this.facade.companiesWithoutRule$;

  constructor(
    public facade: FacadeService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.facade.getCompaniesWithoutRule();
  }

  onLink(company: Company): void {
    this.dialog.open(AddRuleDialogComponent, {
      data: {
        companyId: company.id,
        companyName: company.name
      },
    });
  }
}
