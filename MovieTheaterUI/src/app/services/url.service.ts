import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  url :string = 'https://p2movietheatergroupapi.azurewebsites.net/api/'

  constructor() { }
}
