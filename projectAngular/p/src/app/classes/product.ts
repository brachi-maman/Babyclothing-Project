export class Product {
    public productId!: number;
    public productName!: string;
    public cName!: string;
    public companyId!: number;
    public descriptionProducts?: string;
    public price!: number;
    public imageUrl!: string;
    public stockQuantity!: number;
    public lastUpdated!: string;
    public company!: string;
    public season!: string;
    public size!: string;
    public gender!: string;
    public compName!: string;
    public ordersDetails?: [];

    constructor(product?: Product,) {
        if(product){
        this.productId = product.productId;
        this.productName = product.productName;
        this.cName = product.cName;
        this.companyId = product.companyId;
        this.descriptionProducts = product.descriptionProducts;
        this.price = product.price;
        this.imageUrl = product.imageUrl;
        this.stockQuantity = product.stockQuantity;
        this.lastUpdated = product.lastUpdated;
        this.company = product.company;
        this.season = product.season;
        this.size = product.size;
        this.gender = product.gender;
        this.compName = product.compName;
        this.ordersDetails = product.ordersDetails;
    }
}

}
