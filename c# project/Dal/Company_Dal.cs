using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  

        public class Company_Dal : IdalCompany
        {
            public async Task<List<CompanyDto>> SelectAll()
            {
                BabyClothingStoreContext db = new BabyClothingStoreContext();
                var q = await db.Companies.ToListAsync();
                return Company_converter.ToListCompanyDto(q);
            }
        }
    }
    

