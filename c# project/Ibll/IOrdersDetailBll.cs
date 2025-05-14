using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibll
{
    public interface IOrdersDetailBll
    {
        public Task<List<OrdersDetailDto>> SelectAll();
        public Task<double> TotalPriceAsync(CustomerDto c, OrdersDetailDto[] o);

    }
}
