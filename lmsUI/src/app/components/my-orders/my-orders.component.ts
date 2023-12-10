import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {

  order: Order[] = []
  responseMsg: string = '';

  ngOnInit(): void {
    let userId = this.userservice.getTokenUserInfo()?.id
    
    this.orderservice.myOrder(userId).subscribe({
      next: (res: Order[]) => {
        if(res.length != 0){
          this.responseMsg = '';
          this.order = res;
        }
        else{
          this.responseMsg = 'No Book Borrowed Yet!!'
        }
      }
    })
  }

  returnBook(order: Order){
    this.orderservice.returnBook(order.orderId, order.bookId).subscribe({
      next: (res: any) => {
        if (res.message === 'Return Successfull'){
          order.is_Returned = true;
          order.returnedOn = res.returnedOn;
        }
      }
    })
  }

  constructor(
    private userservice: UserService,
    private orderservice : OrderService
  ) { }
}
