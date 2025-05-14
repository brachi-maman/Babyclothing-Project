using Dto.dto_classes;
using Ibll;

namespace Bll
{
    public class Order_Bll : IorderBll
    {
        Idal.IdalOrder c;
        public Order_Bll(Idal.IdalOrder c)
        {
            this.c = c;
        }

        public async Task<List<OrderDto>> SelectAll()
        {
            return await c.SelectAll();
        }
    }
}
