import { Product } from "./product";

export interface Order {

    id: string;
    productos: Product[];
    total: number;
    fecha: Date;
}
