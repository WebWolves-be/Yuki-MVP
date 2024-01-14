import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, of} from "rxjs";
import {CategoryTreeNode} from "../model/category-tree-node.interface";

@Injectable({providedIn: "root"})
export class RepositoryService {
  private baseUrl = "http://localhost:5005/api";

  constructor(public httpClient: HttpClient) {

  }

  getCategoryTreeNodes(): Observable<CategoryTreeNode[]> {
    return this.httpClient.get<CategoryTreeNode[]>(`${this.baseUrl}/categories/tree-view`)
      .pipe(
        map(response => response as CategoryTreeNode[]),
        catchError(err => {
          alert("OOPS, HTTP ALERT!");
          return of([]);
        })
      )
  }
}
