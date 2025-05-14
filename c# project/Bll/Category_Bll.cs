using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ibll;



namespace Bll
{
    public class Category_Bll: IcategoryBll
    {
        Idal.IdalCategory c;
        public Category_Bll(Idal.IdalCategory c)
        {
            this.c = c;
        }

        public async Task<List<CategoryDto>> SelectAll()
        {   
            return await c.SelectAll();
        }

    }


}



