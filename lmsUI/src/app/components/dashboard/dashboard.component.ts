import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  books: Book[] = [];
  responseMsg: string = '';
  searchValue: string = '';

  ngOnInit(): void {
    if (!this.userservice.isLoggedIn()) {
      this.bookservice.getAllAvailableBooks().subscribe(
        {
          next: (res: Book[]) => {
            if (res.length != 0) {
              this.responseMsg = '';
              this.books = []
              for (var book of res) {
                this.books.push(book);
              }
            }
            else this.responseMsg = 'No Book Available!';
          }
        }
      )
    }

    else if (this.userservice.isLoggedIn()) {
      let userId = this.userservice.getTokenUserInfo()?.id
      this.bookservice.getAllAvailableBooksById(userId).subscribe({
        next: (res: Book[]) => {
          if (res.length != 0) {
            this.responseMsg = '';
            this.books = []
            for (var book of res) {
              this.books.push(book);
            }
          }
          else this.responseMsg = 'No Book Available!';
        }
      })
    }
  }

  get filteredBooks() {
    const value = this.searchValue.toLowerCase();
    return this.books.filter(
      (book) =>
        book.title.toLowerCase().includes(value) ||
        book.author.toLowerCase().includes(value) ||
        book.genre.toLowerCase().includes(value)
    );
  }

  bookDetail(id: number) {
    this.router.navigate(['bookdetail', id]);
  }

  constructor(
    private userservice: UserService,
    private bookservice: BookService,
    private router: Router
  ) { }

}
