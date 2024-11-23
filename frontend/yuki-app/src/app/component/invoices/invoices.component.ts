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
import {MatChipsModule} from "@angular/material/chips";
import {MatDialog} from "@angular/material/dialog";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {AddMatchDialogComponent} from "../add-match-dialog/add-match-dialog.component";

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
    MatChipsModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './invoices.component.html',
  styleUrl: './invoices.component.scss'
})
export class InvoicesComponent implements OnInit {
  invoicesWithoutMatch$ = this.facade.invoicesWithoutMatch$;

  displayedColumns: string[] = ['company', 'subject', 'amount', 'date', 'actions'];

  constructor(
    public facade: FacadeService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.facade.getInvoicesWithoutMatch();
  }

  onLink(invoice: Invoice): void {
    this.dialog.open(AddMatchDialogComponent, {
      data: {
        invoiceId: invoice.id,
        invoiceSubject: invoice.subject
      },
    });
  }

  onShow(invoice: Invoice): void {
    window.open(`https://webwolves.yukiworks.be/domain/purchase/aspx/Document.aspx?ID=${invoice.yukiKey}`, '_blank');
  }
}
