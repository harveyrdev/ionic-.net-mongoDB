import { Product } from "./product";

export interface Order {

    id?: string;
    orderItems: Product[];
    totalAmount: number;
    orderDate?: Date;
    customerName:string;
}
