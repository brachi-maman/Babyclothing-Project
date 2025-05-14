using Dal.Models;
using Dto.dto_classes;
using Ibll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Product_Bll : IproductBll
    {



        Idal.IdalProduct c;
        public Product_Bll(Idal.IdalProduct c)
        {
            this.c = c;
        }

        public async Task<List<ProductDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        public async Task<List<ProductDto>> SelectNewsProduct()
        {
            return await c.SelectNewsProduct();
        }
        public async Task<List<ProductDto>> getByCategory(int? categoryid ,int? companyId, string? gender)
        {
            return await c.getByCategory(categoryid, companyId, gender);
        }

        public async Task<ProductDto> AddProduct(ProductDto product)
        {
            return await c.AddProduct(product); // קריאה לפונקציה ב-DAL להוספת לקוח חדש
        }

    }
}

