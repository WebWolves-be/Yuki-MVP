import {Component, OnInit} from '@angular/core';
import {MatCardModule} from "@angular/material/card";
import {CdkTreeModule, NestedTreeControl} from "@angular/cdk/tree";
import {MatTreeModule, MatTreeNestedDataSource} from "@angular/material/tree";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {FacadeService} from "../../facade/facade.service";

interface FoodNode {
  name: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'Fruit',
    children: [{name: 'Apple'}, {name: 'Banana'}, {name: 'Fruit loops'}],
  },
  {
    name: 'Vegetables',
    children: [
      {
        name: 'Green',
        children: [
          {name: 'Broccoli', children: [{name: 'Test'}]},
          {name: 'Brussels sprouts'},
        ],
      },
      {
        name: 'Orange',
        children: [{name: 'Pumpkins'}, {name: 'Carrots'}],
      },
    ],
  },
];

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    CdkTreeModule,
    MatCardModule,
    MatTreeModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export class CategoriesComponent implements OnInit {
  treeControl = new NestedTreeControl<FoodNode>((node) => node.children);
  dataSource = new MatTreeNestedDataSource<FoodNode>();

  constructor(public facade: FacadeService) {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: FoodNode) =>
    !!node.children && node.children.length > 0;

  ngOnInit(): void {
    this.facade.getCategoryTreeNodes();
  }
}
