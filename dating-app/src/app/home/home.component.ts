import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../_models/users';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isRegisterMode = false;
  user:UserRegister ={username:"vu", email:"vu@gmail.com", password:"123" }
  constructor() { }

  ngOnInit(): void {
  }
  cancelRegisterMode(event: boolean){
    this.isRegisterMode = event;
  }
}
