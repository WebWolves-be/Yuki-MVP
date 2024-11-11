import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "@angular/material/dialog";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {FacadeService} from "../../facade/facade.service";
import {SnackBarService} from "../../service/snack-bar.service";
import {Subject, takeUntil} from "rxjs";
import {MatSelectModule} from "@angular/material/select";
import {AsyncPipe, NgForOf, NgIf} from "@angular/common";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";

@Component({
  selector: 'app-add-rule-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatDialogTitle,
    MatIconModule,
    MatButtonModule,
    MatDialogClose,
    MatSelectModule,
    MatInputModule,
    AsyncPipe,
    NgIf,
    NgForOf,
    ReactiveFormsModule
  ],
  templateUrl: './add-rule-dialog.component.html',
  styleUrl: './add-rule-dialog.component.scss'
})
export class AddRuleDialogComponent implements OnInit, OnDestroy {

  private destroyed$$ = new Subject();

  form = new FormGroup({
    categoryId: new FormControl<number | null>(null, [Validators.required])
  })

  categoryPaths$ = this.facade.categoryPaths$;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<AddRuleDialogComponent>,
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
      this.facade.addRule(this.data.companyId, this.form.controls.categoryId.value)
        .pipe(takeUntil(this.destroyed$$))
        .subscribe(success => {
          if (success) {
            this.snackBar.openSuccess("Bedrijf is gelinked!")
            this.facade.getCategoryTreeNodes();
            this.facade.getCompaniesWithoutRule();
            this.dialogRef.close();
          }
        });
    }
  }
}
