import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = 'https://localhost:7283/api/Order/';

  borrowBook(userId: any, bookId: any){
    return this.http.get(this.baseUrl + 'BorrowBook/' + userId + '/' + bookId, {
      responseType: 'text'
    });
  }

  myOrder(userId: any){
    return this.http.get<Order[]>(this.baseUrl + 'MyOrder/' + userId);
  }

  returnBook(orderId: any, bookId: any ){
    return this.http.get(this.baseUrl + 'ReturnBook/' + orderId + '/' + bookId);
  }

  constructor(
    private http: HttpClient
  ) { }
}
