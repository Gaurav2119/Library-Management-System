import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.css']
})
export class MyBooksComponent implements OnInit {
  books: Book[] = [];
  responseMsg: string = '';

  ngOnInit(): void {
    let userId = this.userservice.getTokenUserInfo()?.id;
    this.bookservice.myBooks(userId).subscribe({
      next: (res: Book[]) => {
        if (res.length == 0) this.responseMsg = 'No Book Lented Yet!';
        else{
          this.responseMsg = '';
          this.books = res;
        }
      }
    })
    
  }

  constructor(
    private userservice: UserService,
    private bookservice: BookService,
    private router: Router
  ) { }

}
