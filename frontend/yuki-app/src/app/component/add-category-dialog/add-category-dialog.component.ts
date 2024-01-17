import {Component, Inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {FacadeService} from "../../facade/facade.service";
import {SnackBarService} from "../../service/snack-bar.service";

@Component({
  selector: 'app-add-category-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    NgIf,
  ],
  templateUrl: './add-category-dialog.component.html',
  styleUrl: './add-category-dialog.component.scss'
})
export class AddCategoryDialogComponent {

  form = new FormGroup({
    name: new FormControl<string>("", [Validators.required, Validators.maxLength(100)])
  })

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<AddCategoryDialogComponent>,
    public facade: FacadeService,
    private snackBar: SnackBarService) {
  }

  onSave(): void {
    if (this.form.controls.name.value) {
      this.facade.saveCategory(this.form.controls.name.value, this.data.parentId).subscribe(success => {
        if (success) {
          this.snackBar.openSuccess("Categorie is toegevoegd!")
          this.facade.getCategoryTreeNodes();
          this.dialogRef.close();
        }
      });
    }
  }
}
