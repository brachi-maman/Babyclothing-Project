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
    public class Product_dal : IdalProduct
    {
        public async Task<List<ProductDto>> SelectAll()
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var q = await db.Products.Include(x => x.Category).Include(x => x.Company).ToListAsync();
            return Product_converter.ToListProductDto(q);
        }



        public async Task<List<ProductDto>> getByCategory(int? categoryid, int? companyId, string? gender)
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            if (categoryid != null && companyId != null && gender != null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)

                   //1
                   .Where(p => p.Gender.Equals(gender)).Where(p => p.CompanyId.Equals(companyId)).Where(p => p.CategoryId.Equals(categoryid))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //2
            else if (categoryid != null && companyId != null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.CategoryId.Equals(categoryid)).Where(p => p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //3
            else if (categoryid != null && companyId == null && gender != null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.Gender.Equals(gender)).Where(p => p.CategoryId.Equals(categoryid))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }//2
             //4
            else if (categoryid != null && companyId == null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.CategoryId.Equals(categoryid))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //5
            else if (categoryid == null && companyId != null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //6
            else if (categoryid == null && companyId == null && gender != null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.Gender.Equals(gender))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }

            //7
            else if (categoryid != null && companyId == null && gender == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.CategoryId.Equals(categoryid))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            else if (gender != null && companyId != null && categoryid == null)
            {
                var products = await db.Products.Include(x => x.Category).Include(x => x.Company)
                   .Where(p => p.Gender.Equals(gender)).Where(p => p.CompanyId.Equals(companyId))
                   .ToListAsync();
                return Product_converter.ToListProductDto(products);
            }
            //5
            else
            {
                var q = await db.Products.Include(x => x.Category).Include(y => y.Company).ToListAsync();
                return Product_converter.ToListProductDto(q);
            }

        }
        public async Task<List<ProductDto>> SelectNewsProduct()
        {

            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var q = await db.Products.ToListAsync();
            return Product_converter.ToListProductDto(q).Where(p => p.LastUpdated.HasValue).OrderByDescending(p => p.LastUpdated.Value).Take(10).ToList();
        }
        public async Task<ProductDto> AddProduct(ProductDto p)
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var product = Product_converter.ToProduct(p); // המרת DTO לאובייקט מודל
            db.Products.Add(product); // הוספת הלקוח לבסיס הנתונים
            await db.SaveChangesAsync(); // שמירת השינויים
            return Product_converter.ToProduct(product); // המרת הלקוח שנשמר בחזרה ל-DTO
        }
    }
}

