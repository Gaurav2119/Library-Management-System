export interface Order {
    orderId: number;
    userId: number;
    bookId: number;
    bookName: string;
    bookAuthor: string;
    borrowedOn: string;
    returnedOn: string;
    is_Returned: boolean;
  }