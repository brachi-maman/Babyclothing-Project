using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class Category_converter
    {
        public static Dto.dto_classes.CategoryDto ToCategoryDto(Models.Category c)
        {
            Dto.dto_classes.CategoryDto cNew = new Dto.dto_classes.CategoryDto();
            cNew.CategoryId = c.CategoryId;
            cNew.CategoryName = c.CategoryName;

            return cNew;
        }
        public static List<Dto.dto_classes.CategoryDto> ToListCategoryDto(List<Models.Category> lc)
        {
            List<Dto.dto_classes.CategoryDto> lnew = new List<Dto.dto_classes.CategoryDto>();
            foreach (Models.Category c in lc)
            {
                lnew.Add(ToCategoryDto(c));
            }
            return lnew;
        }

        public static Models.Category ToCategory(Models.Category c)
        {
            Models.Category cNew = new Models.Category();
            cNew.CategoryName = c.CategoryName;
            cNew.CategoryId= c.CategoryId;
            return cNew;
        }
    }
}
