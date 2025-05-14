using Dto.dto_classes;
using Ibll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Company_Bll : ICompanyBll
    {
        Idal.IdalCompany c;
        public Company_Bll(Idal.IdalCompany c)
        {
            this.c = c;
        }

        public async Task<List<CompanyDto>> SelectAll()
        {
            return await c.SelectAll();
        }

    }
}
