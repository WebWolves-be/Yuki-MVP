import {Component, OnDestroy, OnInit} from '@angular/core';
import {AsyncPipe, DatePipe, DecimalPipe, NgIf} from "@angular/common";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatChipsModule} from "@angular/material/chips";
import {MatIconModule} from "@angular/material/icon";
import {MatMenuModule} from "@angular/material/menu";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatTableModule} from "@angular/material/table";
import {FacadeService} from "../../facade/facade.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Subject, takeUntil} from "rxjs";
import {MatDialogClose} from "@angular/material/dialog";
import {Match} from "../../model/match.interface";

@Component({
  selector: 'app-matches',
  standalone: true,
  imports: [
    AsyncPipe,
    DatePipe,
    DecimalPipe,
    MatButtonModule,
    MatCardModule,
    MatChipsModule,
    MatIconModule,
    MatMenuModule,
    MatProgressSpinnerModule,
    MatTableModule,
    NgIf,
    MatDialogClose
  ],
  templateUrl: './matches.component.html',
  styleUrl: './matches.component.scss'
})
export class MatchesComponent implements OnInit, OnDestroy {

  private destroyed$$ = new Subject();

  matchesFromCategory$ = this.facade.matchesFromCategory$;

  displayedColumns: string[] = ['company', 'subject', 'amount', 'date', 'exception', 'actions'];
  categoryName = '';

  constructor(
    private facade: FacadeService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    this.route.params.pipe(takeUntil(this.destroyed$$)).subscribe(params => {
      this.facade.getMatchesFromCategory(params['categoryId']);
      this.categoryName = params['categoryName'];
    });
  }

  ngOnDestroy(): void {
    this.destroyed$$.next(null);
    this.destroyed$$.complete();
  }

  goBack(): void {
    void this.router.navigate([""])
  }

  goToYuki(match: Match): void {
    window.open(`https://webwolves.yukiworks.be/domain/purchase/aspx/Document.aspx?ID=${match.invoiceYukiKey}`, '_blank');
  }
}
