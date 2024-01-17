import {HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {SnackBarService} from "../service/snack-bar.service";

@Injectable({providedIn: "root"})
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private snackBar: SnackBarService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    //todo: implement unhandled errors
    return next.handle(req);
  }
}
