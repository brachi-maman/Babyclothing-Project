using Dto.dto_classes;
using Ibll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Order_details_Bll : IOrdersDetailBll
    {
        Idal.IdalOrderDetails c;
        public Order_details_Bll(Idal.IdalOrderDetails c)
        {
            this.c = c;
        }

        public async Task<List<OrdersDetailDto>> SelectAll()
        {
            return await c.SelectAll();
        }

        public async Task<double> TotalPriceAsync(CustomerDto c1, OrdersDetailDto[] ordersDetails)
        {
            double totalPrice = 0;

            var orderDto = new OrderDto
            {
                CustomerId = c1.CustomerId,
                OrderDate = DateTime.Now,
                TotalPayment = 0,
                Paid = false
            };
            //יצירת הזמנה
            var createdOrder = await c.CreateOrderAsync(orderDto);
            //עוברים על הסל  - 
            //עוברים על כל מערך שבו כל איבר מכיל - קוד מוצר וכמות 
            foreach (var o in ordersDetails)
            {
                //מציאת המוצר
                var product = await c.GetProductByIdAsync(o.ProductId.Value);
                //אם קיים במלאי הכמות שהלקוח רוצה
                if (product != null && o.Quantity < product.StockQuantity)
                {
                    //חישוב המחיר
                    totalPrice += product.Price * o.Quantity;
                    //הורדת מהמלאי הכמות שנקנתה
                    product.StockQuantity -= o.Quantity;
                    //יצירת אוביקט הזמנה
                    var orderDetails = new OrdersDetailDto
                    {
                        OrderId = createdOrder.OrderId,
                        ProductId = o.ProductId,
                        Quantity = o.Quantity
                    };

                    // במקום לקרוא ל-AddOrderDetailAsync על ה- CustomerDto
                    //הוספה orderDetails
                    await c.AddOrderDetailAsync(orderDetails);

                }
            }
            //אם יש ללקוח יש הנחת יום הולדת
            if (c1.BirthDate != null && c1.BirthDate.Value.Month == DateTime.Now.Month)
            {
                totalPrice -= totalPrice / 10;
            }
            //של ההזמנה TotalPayment  עידכון ה    
            createdOrder.TotalPayment = totalPrice;
            //של ההזמנה Paid עידכון ה 
            createdOrder.Paid = true;
            //שמירת ההזמנה המעודכנת
            await c.UpdateOrderAsync(createdOrder);
            return totalPrice;
        }
    }
}
        
    
