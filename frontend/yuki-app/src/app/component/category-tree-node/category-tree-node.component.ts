import {Component, Input} from '@angular/core';
import {MatIconModule} from "@angular/material/icon";
import {MatMenuModule} from "@angular/material/menu";
import {MatButtonModule} from "@angular/material/button";
import {CategoryTreeNode} from "../../model/category-tree-node.interface";
import {NgIf} from "@angular/common";
import {AddCategoryDialogComponent} from "../add-category-dialog/add-category-dialog.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-category-tree-node',
  standalone: true,
  imports: [
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    NgIf
  ],
  templateUrl: './category-tree-node.component.html',
  styleUrl: './category-tree-node.component.scss'
})
export class CategoryTreeNodeComponent {
  @Input() categoryTreeNode!: CategoryTreeNode;
  @Input() expandable!: boolean;

  constructor(public dialog: MatDialog) {
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

  }
}
