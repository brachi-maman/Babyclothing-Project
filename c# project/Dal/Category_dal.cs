using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dal;
using Idal;


namespace Dal
{
    public class Category_dal : IdalCategory
    {
        public async Task<List<CategoryDto>> SelectAll()
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var q = await db.Categories.ToListAsync();
            return Category_converter.ToListCategoryDto(q);
        }
    }

}