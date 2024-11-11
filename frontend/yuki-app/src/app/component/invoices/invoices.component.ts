import {Component, OnInit} from '@angular/core';
import {AsyncPipe, DatePipe, DecimalPipe, NgForOf, NgIf} from "@angular/common";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from "@angular/material/icon";
import {MatListModule} from "@angular/material/list";
import {FacadeService} from "../../facade/facade.service";
import {MatTableModule} from "@angular/material/table";
import {Invoice} from "../../model/invoice.interface";
import {MatMenuModule} from "@angular/material/menu";
import {Router} from "@angular/router";
import {MatChipsModule} from "@angular/material/chips";

@Component({
  selector: 'app-invoices',
  standalone: true,
  imports: [
    AsyncPipe,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatListModule,
    NgForOf,
    NgIf,
    MatTableModule,
    DecimalPipe,
    DatePipe,
    MatMenuModule,
    MatChipsModule
  ],
  templateUrl: './invoices.component.html',
  styleUrl: './invoices.component.scss'
})
export class InvoicesComponent implements OnInit {
  invoices$ = this.facade.invoices$;

  displayedColumns: string[] = ['company', 'subject', 'amount', 'date', 'actions'];

  constructor(
    public facade: FacadeService,
    public router: Router) {
  }

  ngOnInit(): void {
    this.facade.getInvoices();
  }

  onLink(invoice: Invoice): void {

  }

  onShow(invoice: Invoice): void {
    window.open(`https://webwolves.yukiworks.be/domain/purchase/aspx/Document.aspx?ID=${invoice.yukiKey}`, '_blank');
  }
}
