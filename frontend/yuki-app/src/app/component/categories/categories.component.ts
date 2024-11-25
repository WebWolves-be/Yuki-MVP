import {Component, OnInit} from '@angular/core';
import {MatCardModule} from "@angular/material/card";
import {CdkTreeModule, NestedTreeControl} from "@angular/cdk/tree";
import {MatTreeModule, MatTreeNestedDataSource} from "@angular/material/tree";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {FacadeService} from "../../facade/facade.service";
import {CategoryTreeNode} from "../../model/category-tree-node.interface";
import {AsyncPipe, DecimalPipe} from "@angular/common";
import {MatDialog} from "@angular/material/dialog";
import {AddCategoryDialogComponent} from "../add-category-dialog/add-category-dialog.component";
import {MatMenuModule} from "@angular/material/menu";
import {CategoryTreeNodeComponent} from "../category-tree-node/category-tree-node.component";
import {MatDividerModule} from "@angular/material/divider";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    CdkTreeModule,
    MatCardModule,
    MatTreeModule,
    MatIconModule,
    MatButtonModule,
    AsyncPipe,
    MatMenuModule,
    CategoryTreeNodeComponent,
    MatDividerModule,
    DecimalPipe,
    MatProgressSpinnerModule
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export class CategoriesComponent implements OnInit {

  categoryTreeNodes$ = this.facade.categoryTreeNodes$;

  treeControl = new NestedTreeControl<CategoryTreeNode>((node) => node.children);
  dataSource = new MatTreeNestedDataSource<CategoryTreeNode>();

  totalAmount = 0.00;

  constructor(public facade: FacadeService, public dialog: MatDialog) {
  }

  hasChild = (_: number, node: CategoryTreeNode) =>
    !!node.children && node.children.length > 0;

  expansionKeyFn = (dataNode: CategoryTreeNode) => dataNode.id;

  trackByFn = (index: number, dataNode: CategoryTreeNode) => this.expansionKeyFn(dataNode);

  ngOnInit(): void {
    this.facade.getCategoryTreeNodes();

    this.categoryTreeNodes$.subscribe(categoryTreeNodes => {
      if (categoryTreeNodes) {
        this.dataSource.data = categoryTreeNodes;
        this.totalAmount = categoryTreeNodes.reduce((sum, node) => sum + node.totalAmount + node.totalAmountOfChildren, 0);
      }
    })
  }

  onAddCategory(parentId: number | null): void {
    this.dialog.open(AddCategoryDialogComponent, {
      data: {
        parentId: parentId,
      },
    });
  }
}
