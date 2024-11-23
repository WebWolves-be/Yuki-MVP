import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";
import {CategoryTreeNode} from "../model/category-tree-node.interface";
import {Company} from "../model/company.interface";
import {CategoryPath} from "../model/category-path.interface";
import {Invoice} from "../model/invoice.interface";
import {Match} from "../model/match.interface";

@Injectable({providedIn: "root"})
export class StateService {
  private categoryTreeNodes$$ = new BehaviorSubject<CategoryTreeNode[] | null>(null);
  categoryTreeNodes$ = this.categoryTreeNodes$$.asObservable();

  private categoryPaths$$ = new BehaviorSubject<CategoryPath[] | null>(null);
  categoryPaths$ = this.categoryPaths$$.asObservable();

  private companiesWithoutRule$$ = new BehaviorSubject<Company[] | null>(null);
  companiesWithoutRule$ = this.companiesWithoutRule$$.asObservable();

  private invoicesWithoutMatch$$ = new BehaviorSubject<Invoice[] | null>(null);
  invoicesWithoutMatch$ = this.invoicesWithoutMatch$$.asObservable();

  private matchesFromCategory$$ = new BehaviorSubject<Match[] | null>(null);
  matchesFromCategory$ = this.matchesFromCategory$$.asObservable();

  setCategoryTreeNodes(categoryTreeNodes: CategoryTreeNode[]): void {
    this.categoryTreeNodes$$.next(categoryTreeNodes);
  }

  setCategoryPaths(categoryPaths: CategoryPath[]): void {
    this.categoryPaths$$.next(categoryPaths);
  }

  setCompaniesWithoutRule(companies: Company[]): void {
    this.companiesWithoutRule$$.next(companies);
  }

  setInvoicesWithoutMatch(invoices: Invoice[]): void {
    this.invoicesWithoutMatch$$.next(invoices);
  }

  setMatchesFromCategory(matches: Match[]): void {
    this.matchesFromCategory$$.next(matches);
  }
}
