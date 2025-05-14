import { Customer } from "./customer";
export class cartProduct {
    constructor(
      public productId: number,
      public productName: string,
      public price: number,
      public quantity: number,
      public description?: string,
      public addedDate?: Date,
      public imageUrl?: string,
      public customerId? : Customer
    ) {}
  }
  
