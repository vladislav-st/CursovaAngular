import { v4 as uuidv4 } from 'uuid';

export class ProductModel {
    public id: number;
    public fullName: string;
    public description: string;
    public image: string;
    public price: number;

    constructor(fullName: string = "", description: string = "", price: number = 0, image: string = "") {
        this.id = uuidv4();
        this.fullName = fullName;
        this.description = description;
        this.image = image;
        this.price = price;
    }

    isValid(): boolean {
        if (
            this.fullName == null ||
            this.image == null ||
            this.description == null ||
            this.price == 0
            ) {
            return false;
        } else {
            return true;
        }

    }
}