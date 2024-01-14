import {Injectable} from "@angular/core";
import {RepositoryService} from "../repository/repository.service";
import {StateService} from "../state/state.service";

@Injectable({providedIn: "root"})
export class FacadeService {

  categoryTreeNodes$ = this.state.categoryTreeNodes$;
  
  constructor(
    public repo: RepositoryService,
    public state: StateService) {
  }

  getCategoryTreeNodes(): void {
    this.repo.getCategoryTreeNodes().subscribe(categoryTreeNodes => {
      console.log(categoryTreeNodes);
      this.state.setCategoryTreeNodes(categoryTreeNodes);
    })
  }
}
