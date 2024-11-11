import {Component, Inject, OnDestroy} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "@angular/material/dialog";
import {MatIconModule} from "@angular/material/icon";
import {FacadeService} from "../../facade/facade.service";
import {SnackBarService} from "../../service/snack-bar.service";
import {Subject, takeUntil} from "rxjs";
import {MatButtonModule} from "@angular/material/button";

@Component({
  selector: 'app-delete-category-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatIconModule,
    MatDialogActions,
    MatButtonModule,
    MatDialogTitle,
    MatDialogClose
  ],
  templateUrl: './delete-category-dialog.component.html',
  styleUrl: './delete-category-dialog.component.scss'
})
export class DeleteCategoryDialogComponent implements OnDestroy {

  private destroyed$$ = new Subject();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<DeleteCategoryDialogComponent>,
    public facade: FacadeService,
    private snackBar: SnackBarService) {
  }

  ngOnDestroy(): void {
    this.destroyed$$.next(null);
    this.destroyed$$.complete();
  }

  onDelete(): void {
    this.facade.deleteCategory(this.data.categoryId)
      .pipe(takeUntil(this.destroyed$$))
      .subscribe(success => {
        if (success) {
          this.snackBar.openSuccess("Categorie is verwijderd!")
          this.facade.getCategoryTreeNodes();
          this.dialogRef.close();
        }
      });
  }
}
