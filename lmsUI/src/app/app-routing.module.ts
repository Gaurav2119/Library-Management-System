import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { MyBooksComponent } from './components/my-books/my-books.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { BookDetailComponent } from './components/book-detail/book-detail.component';
import { authenticationGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: 'dashboard',
    redirectTo: '',
  },
  {
    path: '',
    component: DashboardComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'mybooks',
    component: MyBooksComponent,
    canActivate: [authenticationGuard]
  },
  {
    path: 'myorders',
    component: MyOrdersComponent,
    canActivate: [authenticationGuard]
  },
  {
    path: 'addbook',
    component: AddBookComponent,
    canActivate: [authenticationGuard]
  },
  {
    path: 'bookdetail/:id',
    component: BookDetailComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
