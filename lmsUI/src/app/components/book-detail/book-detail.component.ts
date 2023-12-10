import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import { OrderService } from 'src/app/services/order.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {

  bookid: any;
  displaybook: Book[] = [];
  userRating: number = 0;

  rateResponse: string = '';
  borrowResponse: string = '';

  ngOnInit(): void {
    this.bookid = this.route.snapshot.paramMap.get('id')
    this.bookservice.getBookById(this.bookid).subscribe(
      {
        next: (res: any) => {
          this.displaybook = [];
          this.displaybook = res;
        }
      }
    )
  }

  onRatingChange(event: any) {
    this.userRating = event.target.value;
  }

  submitRating(book: Book) {
    if (this.userRating != 0) {
      this.bookservice.bookRating(book.id, this.userRating).subscribe({
        next: (res: any) => {
          if (res === 'Error while rating') this.rateResponse = res;
          else {
            this.rateResponse = res.message;
            book.rating = res.bookrating;
          }
        }
      })
    }
  }

  borrow(){
    if(!this.userservice.isLoggedIn()) this.router.navigate(['login']);
    else{
      let userId = this.userservice.getTokenUserInfo()?.id
      this.orderservice.borrowBook(userId, this.bookid).subscribe({
        next: (res: any) => {
          if (res === 'Order placed'){
            this.borrowResponse = '';
            this.router.navigate(['dashboard']);
          }
          else this.borrowResponse = res;
        }
      })
    }
  }

  constructor(
    public userservice: UserService,
    private bookservice: BookService,
    private orderservice: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
}
