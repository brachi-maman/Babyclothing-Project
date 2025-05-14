using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idal
{
    public interface IdalOrderDetails
    {
        //CRUD- create,Read,Update<Delete מממשק תשתיתי שיכיל את פעולות היסוד
        //למחלקה שיהיו פונקציות נוספות ניצור ממשק נוסף שימממש ממשק זה ויכיל את המתודות הנוספות

        public Task<List<OrdersDetailDto>> SelectAll();

        public Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        //קבלת מוצר לפי ID
        public Task<ProductDto?> GetProductByIdAsync(int productId);
        //יצירת  orderDetails
        public Task AddOrderDetailAsync(OrdersDetailDto orderDetailDto);
        //עידכון הזמנה
        public Task UpdateOrderAsync(OrderDto orderDto);
    }

}

