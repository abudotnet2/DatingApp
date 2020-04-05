import { Component, OnInit, Input, Output , EventEmitter} from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
@Input() valuesFromHome: any ;
@Output() cancelRegister = new EventEmitter();
  model:any={};

  constructor(private authService : AuthService, private alert: AlertifyService) { }

  ngOnInit() {
  }

  register()
  {
    console.log(this.model);
    this.authService.register(this.model).subscribe(c=>{
this.alert.success("registration successful")
    },error =>{
      this.alert.error("registration failed")
    }
    )

  }
  cancel()
  {

    this.cancelRegister.emit(false);
  }

}
