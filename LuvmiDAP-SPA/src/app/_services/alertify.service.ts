import { Injectable } from "@angular/core";
import * as alertify from "alertifyjs";

@Injectable({
  providedIn: "root"
})
export class AlertifyService {
  constructor() {}

  confirm(message: String, okCallback: () => any) {
    alertify.confirm(message, (e: any) => {
      if (e) {
        okCallback();
      } else {
      }
    });
  }
  success(message:String)
  {
    alertify.success(message);
  }
  error(message:String)
  {
    alertify.error(message);
  }
  warning(message:String)
  {
    alertify.warning(message);
  }
  message(message:String)
  {
    alertify.message(message);
  }
}
