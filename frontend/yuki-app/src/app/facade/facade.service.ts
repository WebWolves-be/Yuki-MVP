import {Injectable} from "@angular/core";
import {RepositoryService} from "../repository/repository.service";
import {StateService} from "../state/state.service";
import {Observable} from "rxjs";

@Injectable({providedIn: "root"})
export class FacadeService {

  categoryTreeNodes$ = this.state.categoryTreeNodes$;
  categoryPaths$ = this.state.categoryPaths$;
  companiesWithoutRule$ = this.state.companiesWithoutRule$;
  invoicesWithoutMatch$ = this.state.invoicesWithoutMatch$;
  matchesFromCategory$ = this.state.matchesFromCategory$;

  constructor(
    public repo: RepositoryService,
    public state: StateService) {
  }

  getCategoryTreeNodes(): void {
    this.repo.getCategoryTreeNodes().subscribe(categoryTreeNodes => {
      this.state.setCategoryTreeNodes(categoryTreeNodes);
    })
  }

  addCategory(name: string, parentId: number | null): Observable<boolean> {
    return this.repo.addCategory(name, parentId);
  }

  deleteCategory(categoryId: number): Observable<boolean> {
    return this.repo.deleteCategory(categoryId);
  }

  getCategoryPaths(): void {
    this.repo.getCategoryPaths().subscribe(categoryPaths => {
      this.state.setCategoryPaths(categoryPaths);
    })
  }

  getCompaniesWithoutRule(): void {
    this.repo.getCompaniesWithoutRule().subscribe(companies => {
      this.state.setCompaniesWithoutRule(companies);
    })
  }

  addRule(companyId: number, categoryId: number): Observable<boolean> {
    return this.repo.addRule(companyId, categoryId);
  }

  getInvoicesWithoutMatch(): void {
    this.repo.getInvoicesWithoutMatch().subscribe(invoices => {
      this.state.setInvoicesWithoutMatch(invoices);
    })
  }

  addMatch(invoiceId: number, categoryId: number): Observable<boolean> {
    return this.repo.addMatch(invoiceId, categoryId);
  }

  getMatchesFromCategory(categoryId: number): void {
    this.repo.getMatchesFromCategory(categoryId).subscribe(matches => {
      this.state.setMatchesFromCategory(matches);
    })
  }
}
