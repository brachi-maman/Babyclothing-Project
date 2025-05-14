using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class Product_converter
    {
        //המרה ל dto
        public static Dto. dto_classes.ProductDto ToProduct(Models.Product c)
        {
            Dto.dto_classes.ProductDto cNew = new Dto.dto_classes.ProductDto();
            cNew.ProductId = c.ProductId;
            cNew.ProductName = c.ProductName;
            cNew.CategoryId = c.CategoryId;
            cNew.CompanyId = c.CompanyId;
            cNew.DescriptionProducts = c.DescriptionProduct;
            cNew.Price = c.Price;
            cNew.ImageUrl = c.ImageUrl;
            cNew.StockQuantity = c.StockQuantity;
            cNew.LastUpdated = c.LastUpdated;
            cNew.Season = c.Season;
            cNew.Size = c.Size;
            cNew.Gender = c.Gender;
            if(c.Company != null)
                cNew.CompanyName = c.Company.CompanyName;
            if (c.Category != null)
                cNew.CName = c.Category.CategoryName;

            //ונקבל את ערכה תוך שימוש בשדה הניווט Dtoהשדה הבא קיים רק במחלקה מסוג ה
            //if (c.Depart != null)
            //    //פה אנחנו נהנות משדה הניווט שלא דרש קש"ג מסובך אלא אפשר גישה ישירה לשדות טבלת המפתח זר
            //    //Depart = null אחרת שדה הinclude חובה בשלב השליפה לדאוג לבצע פעולת 
            //    cNew.DepartName = c.Depart.Name;
            return cNew;
        }
        public static List<Dto.dto_classes.ProductDto> ToListProductDto(List<Models.Product> lc)
        {
            List<Dto.dto_classes.ProductDto> lnew = new List<Dto.dto_classes.ProductDto>();
            foreach (Models.Product c in lc)
            {
                lnew.Add(ToProduct(c));
            }
            return lnew;
        }

        //המרה לmodel
        public static Models.Product ToProduct(Dto.dto_classes.ProductDto c)
        {
            Models.Product cNew = new Models.Product();
            //מאחר והשדה הוא מספור אוטומטי אין טעם ואפילו יגרום לשגיאה לעדכן אותו
            //    cNew.Courseid = c.Courseid;
            cNew.ProductId = c.ProductId;
            cNew.ProductName = c.ProductName;
            cNew.CategoryId = c.CategoryId;
            cNew.CompanyId = c.CompanyId;
            cNew.DescriptionProduct = c.DescriptionProducts;
            cNew.Price = c.Price;
            cNew.ImageUrl = c.ImageUrl;
            cNew.StockQuantity = c.StockQuantity;
            cNew.LastUpdated = c.LastUpdated;
            cNew.Season = c.Season;
            cNew.Size = c.Size;
            cNew.Gender = c.Gender;
            return cNew;
        }
    
}
}
