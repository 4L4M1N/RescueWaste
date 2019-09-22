export interface Promocode {
    id: number;
    name: number;
    expireDate: Date;
    discount: number;
    isActive: boolean;
    photoUrl: string;
    merchantName: string;
    coinsRequired: number;
}
