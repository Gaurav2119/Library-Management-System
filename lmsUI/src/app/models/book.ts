export interface Book{
    id: number,
    title: string,
    rating: number,
    author: string,
    genre: string,
    description: string,
    lentbyusername: string,
    currentlyborrowedbyuser: number,
}