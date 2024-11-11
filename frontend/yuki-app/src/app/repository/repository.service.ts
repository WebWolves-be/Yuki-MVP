import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, of} from "rxjs";
import {CategoryTreeNode} from "../model/category-tree-node.interface";
import {SnackBarService} from "../service/snack-bar.service";
import {Company} from "../model/company.interface";
import {CompanyResponse} from "../model/company-reponse.interface";
import {CategoryPath} from "../model/category-path.interface";
import {CategoryPathResponse} from "../model/category-path-response.interface";
import {Invoice} from "../model/invoice.interface";
import {InvoicesResponse} from "../model/invoices-response.interface";

@Injectable({providedIn: "root"})
export class RepositoryService {
  private baseUrl = "http://localhost:5005/api";

  constructor(
    public httpClient: HttpClient,
    private snackBar: SnackBarService) {
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

  addCategory(name: string, parentId: number | null): Observable<boolean> {
    return this.httpClient.post(`${this.baseUrl}/categories`, {name: name, parentId: parentId})
      .pipe(
        map(response => {
          return true
        }),
        catchError(() => {
          //todo: show form validation messages
          return of(false);
        })
      );
  }

  deleteCategory(categoryId: number): Observable<boolean> {
    //todo: also delete the rule if any
    return this.httpClient.delete(`${this.baseUrl}/categories/${categoryId}`)
      .pipe(map(response => {
        return true
      }), catchError(() => {
        return of(false);
      }))
  }

  getCategoryPaths(): Observable<CategoryPath[]> {
    return this.httpClient.get<CategoryPathResponse>(`${this.baseUrl}/categories/paths`)
      .pipe(
        map(response => response.categoryPaths as CategoryPath[]),
        catchError(err => {
          alert("OOPS, HTTP ALERT!");
          return of([]);
        })
      )
  }

  getCompaniesWithoutRule(): Observable<Company[]> {
    return this.httpClient.get<CompanyResponse>(`${this.baseUrl}/companies/without-rule`)
      .pipe(
        map(response => response.companies as Company[]),
        catchError(err => {
          alert("OOPS, HTTP ALERT!");
          return of([]);
        }))
  }

  addRule(companyId: number, categoryId: number): Observable<boolean> {
    return this.httpClient.post(`${this.baseUrl}/rules`, {companyId: companyId, categoryId: categoryId})
      .pipe(
        map(response => {
          return true
        }),
        catchError(() => {
          //todo: show form validation messages
          return of(false);
        })
      );
  }

  getInvoices(): Observable<Invoice[]> {
    return this.httpClient.get<InvoicesResponse>(`${this.baseUrl}/invoices`).pipe(
      map(response => response.invoices as Invoice[]),
      catchError(err => {
        alert("OOPS, HTTP ALERT!");
        return of([]);
      })
    );
  }
}
