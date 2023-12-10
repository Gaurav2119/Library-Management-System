import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl = 'https://localhost:7283/api/Book/';

  getAllAvailableBooks(){
    return this.http.get<Book[]>(this.baseUrl + 'GetAllAvailableBooks');
  }

  getAllAvailableBooksById(userId: any){
    return this.http.get<Book[]>(this.baseUrl + 'GetAllAvailableBooksById/' + userId);
  }

  getBookById(bookid : string){
    return this.http.get(this.baseUrl + 'GetBookById/'+ bookid);
  }

  myBooks(userId: any){
    return this.http.get<Book[]>(this.baseUrl + 'MyBooks/' + userId);
  }

  bookRating(bookid: any, rating: any){
    return this.http.get(this.baseUrl + 'BookRating/' + bookid + '/' + rating);
  }

  addBook(book: any){
    return this.http.post(this.baseUrl + 'AddBook/', book, {
      responseType: 'text'
    })
  }

  constructor(
    private http: HttpClient
  ) { }
}
