// "id":0,"userName":"user665","password":"password"
export class User {
  id: number;
  userName: string;
  password: string;

  constructor(id: number, userName: string, password: string) {
    this.id = id;
    this.userName = userName;
    this.password = password;
  }
}
