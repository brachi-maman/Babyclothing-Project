export class OrderDetail {
    constructor(
        public orderDetailId: number,
        public orderId: number,
        public productId: number,
        public quantity: number
    ) { }
}