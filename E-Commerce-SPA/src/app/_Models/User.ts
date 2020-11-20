import { Product } from './product';

export interface User {
    id:string;
    email:string;
    username:string;
    age:number;
    gender:string;
    created:Date;
    lastActive:Date;
    city:string;
    country:string;
    interests:string;
    bio:string;
    products?:Product[];
}
