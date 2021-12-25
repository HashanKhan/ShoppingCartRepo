import { CartItem } from './CartItem';
import { Product } from './product';
import { Total } from './total';

export interface StateTree {
    store: Product[];
    cart: CartItem[];
    tot: Total;
    checkout: boolean;
};