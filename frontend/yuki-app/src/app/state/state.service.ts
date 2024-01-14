import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";
import {CategoryTreeNode} from "../model/category-tree-node.interface";

@Injectable({providedIn: "root"})
export class StateService {
  private categoryTreeNodes$$ = new BehaviorSubject<CategoryTreeNode[] | null>(null);
  categoryTreeNodes$ = this.categoryTreeNodes$$.asObservable();

  setCategoryTreeNodes(categoryTreeNodes: CategoryTreeNode[]) {
    this.categoryTreeNodes$$.next(categoryTreeNodes);
  }
}
