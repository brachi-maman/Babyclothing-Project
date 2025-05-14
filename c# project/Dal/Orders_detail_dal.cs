using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dal
{
    public class Orders_detail_dal : IdalOrderDetails
    {
        public async Task<List<OrdersDetailDto>> SelectAll()
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var q = await db.OrdersDetails.ToListAsync();
            return OrdersDetail_converter.ToListOrdersDetailDto(q);
        }

        //קבלת מוצר לפי ה ID0
        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            using (var db = new BabyClothingStoreContext())
            {
                //חיפוש המוצר לפי ה ID
                var product = await db.Products.FindAsync(productId);
                //אם מצא את המוצר
                //- ממיר לאוביקט מסוג Dto
                //אחרת מחזיר null
                return product != null ? Product_converter.ToProduct(product) : null;
            }
        }
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            using (var db = new BabyClothingStoreContext())
            {
                //המרה של האביקט מסוג של OrderDto ל -> order
                var order = Order_converter.ToOrder(orderDto);
                //הוספת ההזמנה לטבלת ההזמנות
                db.Orders.Add(order);
                //שמירת שינויים על ה db 
                await db.SaveChangesAsync();
                //החזרת order
                return Order_converter.ToOrder(order);
            }
        }
        // OrderDetail - הוספת 
        public async Task AddOrderDetailAsync(OrdersDetailDto orderDetailDto)
        {
            using (var db = new BabyClothingStoreContext())
            {
                // ממירים את ה- DTO לאובייקט Entity
                var orderDetail = new OrdersDetail
                {
                    OrdersId = orderDetailDto.OrderId,
                    ProductId = orderDetailDto.ProductId,
                    Quantity = orderDetailDto.Quantity
                };
                var product = await db.Products.FindAsync(orderDetailDto.ProductId);
                product.StockQuantity -= orderDetailDto.Quantity;
                // db מוסיפים את פרטי ההזמנה ל 
                db.OrdersDetails.Add(orderDetail);
                await db.SaveChangesAsync();
            }
        }
        //עידכון ההזמנה
        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            using (var db = new BabyClothingStoreContext())
            {
                //מציאת ההזמנה
                var order = await db.Orders.FindAsync(orderDto.OrderId);

                if (order != null)
                {
                    //עידכון פרטי ההזמנה
                    order.CustomerId = orderDto.CustomerId;
                    order.OrderDate = orderDto.OrderDate;
                    order.TotalPayment = orderDto.TotalPayment;
                    order.Note = orderDto.Note;
                    order.Paid = orderDto.Paid;

                    // שמירה ב db
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Order not found.");
                }
            }
        }
    }
}




