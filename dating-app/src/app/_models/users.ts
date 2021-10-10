export class User {
  constructor(){
    this.id = 0;
    this.username = "";
    this.email = "";
  }
  id: number;
  username: string;
  email: string;
}

export class UserToken {
  constructor(){
    this.token = "";
    this.username = "";
  }
  username: string;
  token: string;
}

export class UserRegister {
  constructor(){
    this.password = "";
    this.username = "";
    this.email = "";
  }
  password: string;
  username: string;
  email: string;
}
