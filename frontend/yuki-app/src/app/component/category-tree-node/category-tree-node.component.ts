import {Component, Input} from '@angular/core';
import {MatIconModule} from "@angular/material/icon";
import {MatMenuModule} from "@angular/material/menu";
import {MatButtonModule} from "@angular/material/button";
import {CategoryTreeNode} from "../../model/category-tree-node.interface";
import {DecimalPipe, NgClass, NgIf} from "@angular/common";
import {AddCategoryDialogComponent} from "../add-category-dialog/add-category-dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {DeleteCategoryDialogComponent} from "../delete-category-dialog/delete-category-dialog.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-category-tree-node',
  standalone: true,
  imports: [
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    NgIf,
    DecimalPipe,
    NgClass
  ],
  templateUrl: './category-tree-node.component.html',
  styleUrl: './category-tree-node.component.scss'
})
export class CategoryTreeNodeComponent {
  @Input() categoryTreeNode!: CategoryTreeNode;
  @Input() expandable!: boolean;

  constructor(public dialog: MatDialog, public router: Router) {
  }

  onDetail(id: number, name: string): void {
    void this.router.navigate(['/matches/', name, id]);
  }

  onAdd(): void {
    this.dialog.open(AddCategoryDialogComponent, {
      data: {
        parentId: this.categoryTreeNode.id,
        name: this.categoryTreeNode.name
      },
    });
  }

  onDelete(): void {
    this.dialog.open(DeleteCategoryDialogComponent, {
      data: {
        categoryId: this.categoryTreeNode.id,
        name: this.categoryTreeNode.name
      },
    });
  }
}
