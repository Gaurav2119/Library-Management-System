import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})

export class AddBookComponent {
  lentBookForm: FormGroup;
  responseMsg: string= '';

  get title(): FormControl {
    return this.lentBookForm.get('title') as FormControl;
  }

  get author(): FormControl {
    return this.lentBookForm.get('author') as FormControl;
  }

  get genre(): FormControl {
    return this.lentBookForm.get('genre') as FormControl;
  }

  get description(): FormControl {
    return this.lentBookForm.get('description') as FormControl;
  }

  getTitleError(){
    if (this.title.hasError('required'))  return '*Book Title is required!';
    return '';
  }

  getAuthorError(){
    if (this.author.hasError('required')) return '*Book Author is required!';
    return '';
  }

  getGenreError(){
    if (this.genre.hasError('required')) return '*Genre is required!';
    return '';
  }

  getDescriptionError(){
    if (this.description.hasError('maxLength')) return '*Maximum 20 characters allowed!';
    return '';
  }

  addBook(){
    let book = {
      id: 0,
      title: this.title.value,
      author: this.author.value,
      genre: this.genre.value,
      description: this.description.value,
      lentByUser: this.userservice.getTokenUserInfo()?.id
    };

    this.bookservice.addBook(book).subscribe({
      next: (res: any) => {
        if (res === 'Book Added'){
          this.responseMsg = '';
          this.router.navigate(['dashboard']);
        }
        else this.responseMsg = res;
      }
    })
  }

  constructor(
    private fb: FormBuilder,
    private userservice: UserService,
    private bookservice: BookService,
    private router: Router
  ){
    this.lentBookForm = fb.group({
      title: fb.control('', [Validators.required]),
      author: fb.control('', [Validators.required]),
      genre: fb.control('', [Validators.required]),
      description: fb.control('', [Validators.maxLength(2)])
    })
  }
}
