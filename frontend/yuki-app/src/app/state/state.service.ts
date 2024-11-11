import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";
import {CategoryTreeNode} from "../model/category-tree-node.interface";
import {Company} from "../model/company.interface";
import {CategoryPath} from "../model/category-path.interface";
import {Invoice} from "../model/invoice.interface";

@Injectable({providedIn: "root"})
export class StateService {
  private categoryTreeNodes$$ = new BehaviorSubject<CategoryTreeNode[] | null>(null);
  categoryTreeNodes$ = this.categoryTreeNodes$$.asObservable();

  private categoryPaths$$ = new BehaviorSubject<CategoryPath[] | null>(null);
  categoryPaths$ = this.categoryPaths$$.asObservable();

  private companiesWithoutRule$$ = new BehaviorSubject<Company[] | null>(null);
  companiesWithoutRule$ = this.companiesWithoutRule$$.asObservable();

  private invoices$$ = new BehaviorSubject<Invoice[] | null>(null);
  invoices$ = this.invoices$$.asObservable();

  setCategoryTreeNodes(categoryTreeNodes: CategoryTreeNode[]): void {
    this.categoryTreeNodes$$.next(categoryTreeNodes);
  }

  setCategoryPaths(categoryPaths: CategoryPath[]): void {
    this.categoryPaths$$.next(categoryPaths);
  }

  setCompaniesWithoutRule(companies: Company[]): void {
    this.companiesWithoutRule$$.next(companies);
  }

  setInvoices(invoices: Invoice[]): void {
    this.invoices$$.next(invoices);
  }
}
