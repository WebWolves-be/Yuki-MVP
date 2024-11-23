import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {AsyncPipe, NgIf} from "@angular/common";
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "@angular/material/dialog";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {MatOptionModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import {Subject, takeUntil} from "rxjs";
import {FacadeService} from "../../facade/facade.service";
import {SnackBarService} from "../../service/snack-bar.service";

@Component({
  selector: 'app-add-match-dialog',
  standalone: true,
  imports: [
    AsyncPipe,
    FormsModule,
    MatButtonModule,
    MatDialogActions,
    MatDialogClose,
    MatDialogContent,
    MatDialogTitle,
    MatFormFieldModule,
    MatIconModule,
    MatOptionModule,
    MatSelectModule,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './add-match-dialog.component.html',
  styleUrl: './add-match-dialog.component.scss'
})
export class AddMatchDialogComponent implements OnInit, OnDestroy {

  private destroyed$$ = new Subject();

  form = new FormGroup({
    categoryId: new FormControl<number | null>(null, [Validators.required])
  })

  categoryPaths$ = this.facade.categoryPaths$;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<AddMatchDialogComponent>,
    public facade: FacadeService,
    private snackBar: SnackBarService) {
  }

  ngOnInit(): void {
    this.facade.getCategoryPaths();
  }

  ngOnDestroy(): void {
    this.destroyed$$.next(null);
    this.destroyed$$.complete();
  }

  onSave(): void {
    if (this.form.controls.categoryId.value) {
      this.facade.addMatch(this.data.invoiceId, this.form.controls.categoryId.value)
        .pipe(takeUntil(this.destroyed$$))
        .subscribe(success => {
          if (success) {
            this.snackBar.openSuccess("Factuur is gelinked!")
            this.facade.getCategoryTreeNodes();
            this.facade.getCompaniesWithoutRule();
            this.facade.getInvoicesWithoutMatch();
            this.dialogRef.close();
          }
        });
    }
  }
}
