import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model:any ={};

  constructor(public authService : AuthService, private alert: AlertifyService) { }

  ngOnInit() {
  }

  login()
  {
   this.authService.login(this.model).subscribe(next=>{
    this.alert.success("logged in successfully");
   },error =>{
    this.alert.error("failed to login");
   }
   );
  }

  loggedIn()
  {
    return this.authService.loggedIn();
  }
  logout()
  {
    localStorage.removeItem("token");
    console.log("logged out");
  }
}
