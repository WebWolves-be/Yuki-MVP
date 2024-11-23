import {Routes} from '@angular/router';
import {OverviewComponent} from "./component/overview/overview.component";
import {MatchesComponent} from "./component/matches/matches.component";

export const routes: Routes = [
  {
    path: "",
    component: OverviewComponent
  },
  {
    path: "matches/:categoryName/:categoryId",
    component: MatchesComponent
  }
];
