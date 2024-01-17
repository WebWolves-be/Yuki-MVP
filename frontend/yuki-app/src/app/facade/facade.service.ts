import {Injectable} from "@angular/core";
import {RepositoryService} from "../repository/repository.service";
import {StateService} from "../state/state.service";
import {Observable} from "rxjs";

@Injectable({providedIn: "root"})
export class FacadeService {

  categoryTreeNodes$ = this.state.categoryTreeNodes$;

  constructor(
    public repo: RepositoryService,
    public state: StateService) {
  }

  getCategoryTreeNodes(): void {
    this.repo.getCategoryTreeNodes().subscribe(categoryTreeNodes => {
      this.state.setCategoryTreeNodes(categoryTreeNodes);
    })
  }

  saveCategory(name: string, parentId: number | null): Observable<boolean> {
    return this.repo.saveCategory(name, parentId);
  }
}
