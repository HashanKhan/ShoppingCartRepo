export interface CartItem {
    id: number;
    name: string;
    price: number;
    productCategoryID: number;
    uuid?: any;
    remove?: boolean;
}