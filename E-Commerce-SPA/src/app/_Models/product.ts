import { Photo } from "./photo";
export interface Product {
    // ProductListDto
    id:number;
    name: string;
    description: string;
    price: string;
    dateAdded: Date;
    address: string;
    photoURL: string;
    // ProductDetailDto must Be Option 
    photos?: Photo[];
    Phone?:string;
    email?:string;
}
